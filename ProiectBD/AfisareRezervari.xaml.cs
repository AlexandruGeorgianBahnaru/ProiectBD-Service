using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace ProiectBD
{
    /// <summary>
    /// Interaction logic for AfisareRezervari.xaml
    /// </summary>
    public partial class AfisareRezervari : Page
    {
        DataBaseHandler dataBaseHandler;
        public AfisareRezervari()
        {
            InitializeComponent();
            dataBaseHandler = new DataBaseHandler();
            using (OracleConnection connection = new OracleConnection(dataBaseHandler.connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM REZERVARI ORDER BY DATA_PROGRAMARII ASC";

                        OracleDataAdapter adapter = new OracleDataAdapter(query, connection);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                       dataGrid.ItemsSource = dataTable.DefaultView;

                }
                catch (Exception e)
                {
                    MessageBox.Show("Eroare la obtinerea rezervarilor: " + e.Message);
                }
            }
        }
    }
}
