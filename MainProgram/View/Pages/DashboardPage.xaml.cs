using Npgsql;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MainProgram.Service;
using MainProgram.Config;
using MainProgram.Model;
using System.Diagnostics;
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Wpf.Charts.Base;

namespace MainProgram.View.Pages
{
    /// <summary>
    /// Interaction logic for DashboardPage.xaml
    /// </summary>
    public partial class DashboardPage : Page
    {
        private User loggedInUser;
        public class CombinedData
        {
            public DateTime Date { get; set; }
            public double Income { get; set; }
            public double Expense { get; set; }
            public double Net => Income - Expense;
        }
        public DashboardPage(User user)
        {
            InitializeComponent();
            loggedInUser = user;
            welcomeLabel.Text = $"Welcome {loggedInUser.Username}";

            updateDashboard();
            DisplayPieChart();
            int userID = loggedInUser.UserID;
            var incomeData = TransactionService.GetTransactions(userID, true, "Income");
            var expenseData = TransactionService.GetTransactions(userID, true, "Expense");

            DataContext = this;
            ChartValues<double> values = new ChartValues<double>();
            List<string> labels = new List<string>();

            var combinedData = new Dictionary<DateTime, CombinedData>();

            foreach (var point in incomeData)
            {
                var date = point.Date.Date;
                if (!combinedData.ContainsKey(date))
                    combinedData[date] = new CombinedData { Date = date };

                combinedData[date].Income += point.Amount;
                Debug.WriteLine(incomeData[0].Date.ToString());
            }

            foreach (var point in expenseData)
            {
                var date = point.Date.Date;
                if (!combinedData.ContainsKey(date))
                    combinedData[date] = new CombinedData { Date = date };

                combinedData[date].Expense += point.Amount;
            }
            foreach (var entry in combinedData.OrderBy(e => e.Key))
            {
                values.Add(entry.Value.Net);
                labels.Add(entry.Key.ToString("d"));
            }

            MyChart.Series = new SeriesCollection
        {
            new LineSeries
            {
                Values = values,
                PointGeometry = null
            }
        };

            MyChart.AxisX.Clear();
            MyChart.AxisX.Add(new Axis
            {
                Title = "Date",
                Labels = labels
            });

            MyChart.AxisY.Clear();
            MyChart.AxisY.Add(new Axis
            {
                Title = "Value",
                LabelFormatter = value => value.ToString("N")
            });
        }

        public Func<ChartPoint, string> PointLabel { get; set; }
        private void updateDashboard()
        {
            int userID = loggedInUser.UserID;
            int incomeAmount = 0;
            int expenseAmount = 0;
            List<Transaction> incomes = TransactionService.GetTransactions(userID, true, "Income");
            List<Transaction> expenses = TransactionService.GetTransactions(userID, true, "Expense");
            for (int i = 0; i < incomes.Count; i++)
            {
                incomeAmount += incomes[i].Amount;
            }
            for (int i = 0; i < expenses.Count; i++)
            {
                expenseAmount += expenses[i].Amount;
            }
            
            incomeLabel.Content = "Rp" + incomeAmount.ToString();
            expenseLabel.Content = "Rp" + expenseAmount.ToString();
        }

        private void DisplayPieChart()
        {
            TransactionService transactionService = new TransactionService();
            int userID = loggedInUser.UserID;
            Dictionary<string, double> expenseData = transactionService.GetByCategoriesDistributions("Expense", userID);
            Dictionary<string, double> incomeData = transactionService.GetByCategoriesDistributions("Income", userID);

            SeriesCollection expenseDistributions = new SeriesCollection();
            SeriesCollection incomeDistributions = new SeriesCollection();

            double totalExpense = expenseData.Values.Sum();
            double totalIncome = incomeData.Values.Sum();

            foreach (var dataPoint in expenseData)
            {
                expenseDistributions.Add(new PieSeries
                {
                    Title = dataPoint.Key,
                    Values = new ChartValues<double> { dataPoint.Value/totalExpense },
                    DataLabels = true,
                    LabelPoint = point => $"{point.Y:P}"  
                });
            }

            foreach (var dataPoint in incomeData)
            {
                incomeDistributions.Add(new PieSeries
                {
                    Title = dataPoint.Key,
                    Values = new ChartValues<double> { dataPoint.Value/totalIncome },
                    DataLabels = true,
                    LabelPoint = point => $"{point.Y:P}"
                });
            }

            expensePieChart.Series = expenseDistributions;
            expensePieChart.LegendLocation = LegendLocation.Bottom;
            expensePieChart.Hoverable = false;
            expensePieChart.DataTooltip = null;


            incomePieChart.Series = incomeDistributions;
            incomePieChart.LegendLocation = LegendLocation.Bottom;
            incomePieChart.Hoverable = false;
            incomePieChart.DataTooltip = null;
        }
    }
}
