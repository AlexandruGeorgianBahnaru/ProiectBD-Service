using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ProiectBD
{
    /// <summary>
    /// Interaction logic for AnulareModificareProgramare.xaml
    /// </summary>
    public partial class AnulareModificareProgramare : Page
    {
        DataBaseHandler dataBaseHandler;
        public AnulareModificareProgramare()
        {
            InitializeComponent();
            dataBaseHandler = new DataBaseHandler();
            datePickerRezervare.DisplayDateStart = DateTime.Now;
        }

        private void anulareButton_Click(object sender, RoutedEventArgs e)
        {
            if (txtId.Text != null && txtId.Text.All(char.IsDigit))
                dataBaseHandler.AnulareRezervare(Convert.ToInt32(txtId.Text.Trim()));
            else
                MessageBox.Show("Introduceti un id valid:");
        }

        private void actualizareButton_Click(object sender, RoutedEventArgs e)
        {
            string selectedDate = datePickerRezervare.Text;
            if (txtId.Text != null && txtId.Text.All(char.IsDigit))
                dataBaseHandler.ModificareRezervare(Convert.ToInt32(txtId.Text.Trim()), selectedDate);
            else
                MessageBox.Show("Introduceti un id valid:");
        }
    }
}
