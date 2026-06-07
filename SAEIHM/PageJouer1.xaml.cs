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
    /// Logique d'interaction pour PageJouer1.xaml
    /// </summary>
    public partial class PageJouer1 : Page
    {
        public PageJouer1()
        {
            InitializeComponent();
            int partieSauvegarde = 0;
            if (partieSauvegarde==0)
            {
                Btnreprendre.IsEnabled = false;
            }

        }

        private void Btnretour_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Menu());
        }

        private void Btnnouvelle_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageChoisirMode());
        }
    }
}
