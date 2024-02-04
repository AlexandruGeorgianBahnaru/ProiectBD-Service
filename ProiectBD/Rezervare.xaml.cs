using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for Rezervare.xaml
    /// </summary>
    public partial class Rezervare : Page
    {
        DataBaseHandler dataBaseHandler;
        public Rezervare()
        {
            InitializeComponent();
            dataBaseHandler = new DataBaseHandler();
            datePickerAnFabricatie.DisplayDateEnd = DateTime.Now;
            datePickerRezervare.DisplayDateStart = DateTime.Now;
        }

        private void rezervareButton_CLick(object sender, RoutedEventArgs e)
        {
            string pattern = @"^[a-zA-Z]{2} \d{1,3} [a-zA-Z]{3}$";
            string selectedDate = datePickerAnFabricatie.Text;
            if(!txtNume.Text.All(char.IsLetter) || !txtPrenume.Text.All(char.IsLetter) || !Regex.IsMatch(txtNrInmatriculare.Text, pattern) 
                || txtNume.Text == null || txtPrenume.Text == null || txtNrInmatriculare.Text == null || txtMarca.Text == null)
                MessageBox.Show("Introduceti datele corect");
            else
            { 
                dataBaseHandler.InsertMasina(txtNrInmatriculare.Text, txtMarca.Text, selectedDate);
                dataBaseHandler.InsertPersoana(txtNume.Text, txtPrenume.Text);
                int persoanaId = dataBaseHandler.GetPersoanaId();
                int masinaId = dataBaseHandler.GetMasinaId();
                selectedDate = datePickerRezervare.Text;
                dataBaseHandler.InsertRezervare(selectedDate, persoanaId, masinaId);
                int rezervareId = dataBaseHandler.GetRezervareId();
                MessageBox.Show("Id-ul rezervarii dumneavoastra este : " + rezervareId);
            }
        }
    }
}
