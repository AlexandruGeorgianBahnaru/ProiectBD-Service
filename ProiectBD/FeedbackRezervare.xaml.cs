using System;
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

namespace ProiectBD
{
    /// <summary>
    /// Interaction logic for FeedbackRezervare.xaml
    /// </summary>
    public partial class FeedbackRezervare : Page
    {
        DataBaseHandler dataBaseHandler;
        public FeedbackRezervare()
        {
            InitializeComponent();
            dataBaseHandler = new DataBaseHandler();
        }

        private void feedbackButton_click(object sender, RoutedEventArgs e)
        {
            if (txtIdPersoana.Text != null && txtFeedback.Text != null && txtIdRezervare.Text != null)
            {
                if (txtIdRezervare.Text.All(char.IsDigit) && txtIdPersoana.Text.All(char.IsDigit) && Convert.ToInt32(txtFeedback.Text) >= 0 && Convert.ToInt32(txtFeedback.Text) <= 5)
                {
                    dataBaseHandler.InsertFeedback(Convert.ToInt32(txtIdRezervare.Text), Convert.ToInt32(txtIdPersoana.Text), Convert.ToInt32(txtFeedback.Text));
                    MessageBox.Show("Multumim pentru feedback!");
                }
                else
                    MessageBox.Show("Introduceti datele si feedbac-ul corect!");
            }
        }
    }
}
