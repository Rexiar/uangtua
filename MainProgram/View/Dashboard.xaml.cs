using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace MainProgram
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        string vStrConnection = "Server=localhost; port=5432; user id=postgres; password=admin; database=uangtuaDB ;";
        NpgsqlConnection vCon;
        NpgsqlCommand vCommand;

        private void connection()
        {
            vCon = new NpgsqlConnection();
            vCon.ConnectionString = vStrConnection;
            if(vCon.State == ConnectionState.Closed)
            {
                vCon.Open();
            }
        }

        public DataTable getData(string sql)
        {
            DataTable dt = new DataTable();
            connection();
            vCommand.Connection = vCon;
            vCommand.CommandText = sql;

            NpgsqlDataReader dr = vCommand.ExecuteReader();
            dt.Load(dr);


            return dt;
        }


    }
}
