using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace SAEIHM
{
    /// <summary>
    /// Logique d'interaction pour Menu.xaml
    /// </summary>
    public partial class Menu : Page
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btnaide_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageAide());
        }

        private void btnhisto_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageHisto());
        }

        private void btnjouer_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageJouer1());
        }

        private void btnquitter_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }
    }
}


