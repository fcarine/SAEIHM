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

    public partial class Menu : Page
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Btnaide_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageAide());
        }

        private void Btnhisto_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageHisto());
        }

        private void Btnjouer_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageJouer1());
        }

        private void Btnquitter_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }

        private void Btnpara_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Parametre());
        }
    }
}


