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
        public class CombinedData
        {
            public DateTime Date { get; set; }
            public double Income { get; set; }
            public double Expense { get; set; }
            public double Net => Income - Expense;
        }
        public DashboardPage()
        {
            InitializeComponent();
            updateDashboard();
            var incomeData = TransactionService.GetTransactions(true, "Income");
            var expenseData = TransactionService.GetTransactions(true, "Expense");

            ChartValues<double> values = new ChartValues<double>();
            List<string> labels = new List<string>();

            var combinedData = new Dictionary<DateTime, CombinedData>();

            foreach (var point in incomeData)
            {
                var date = point.Date.Date;
                if (!combinedData.ContainsKey(date))
                    combinedData[date] = new CombinedData { Date = date };

                combinedData[date].Income += point.Amount;
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

        void updateDashboard()
        {
            int incomeAmount = 0;
            int expenseAmount = 0;
            List<Transaction> incomes = TransactionService.GetTransactions(true, "Income");
            List<Transaction> expenses = TransactionService.GetTransactions(true, "Expense");
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
    }
}
