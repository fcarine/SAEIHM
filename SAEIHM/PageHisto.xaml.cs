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

namespace SAEIHM
{
    /// <summary>
    /// Logique d'interaction pour PageHisto.xaml
    /// </summary>
    public partial class PageHisto : Page
    {
        public PageHisto()
        {
            InitializeComponent();
        }

        private void btnretour_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Menu());
        }
    }
}
