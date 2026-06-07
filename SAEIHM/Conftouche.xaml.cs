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
    /// Logique d'interaction pour Conftouche.xaml
    /// </summary>
    public partial class Conftouche : Page
    {
        public Conftouche()
        {
            InitializeComponent();
        }
        private void Btnretour_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Confpartie());
        }

        private void clavier_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radiobouton = (RadioButton)sender;
            if (radiobouton == clavier)
            {
                clavierlabel.IsEnabled = true;
            }
            else
            {
                clavierlabel.IsEnabled=false;
            }
        }
        private void VerifEtat(object sender, RoutedEventArgs e)
        {
            bool modeChoisi = souris.IsChecked == true || clavier.IsChecked == true || tactile.IsChecked == true;

            Btnvalide.IsEnabled = modeChoisi;
        }
    }
}
