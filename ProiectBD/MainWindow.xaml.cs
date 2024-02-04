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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            
        }
        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void programareButton_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Rezervare();
        }

        private void anulareButton_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new AnulareModificareProgramare();
        }

        private void feedbackButton_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new FeedbackRezervare();
        }

        private void rezervariButton_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new AfisareRezervari();
        }
    }
}
