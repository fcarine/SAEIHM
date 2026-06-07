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
    /// Logique d'interaction pour Jouer2.xaml
    /// </summary>
    public partial class Jouer2 : Page
    {
        public Jouer2()
        {
            InitializeComponent();
        }
        private void Btnretour_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageChoisirMode());
        }

        private void Btnmode_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Confinterface());
        }
    }
}
