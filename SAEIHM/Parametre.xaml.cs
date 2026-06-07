using ClassIdentifiant;
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
    public partial class Parametre : Page
    {
        public Parametre()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
        private void Btnretour_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Menu());
        }

        private double taillePolice = 18;
        private void BtnAugmenter_Click(object sender, RoutedEventArgs e)
        {
            if (taillePolice < 40)
            {
                taillePolice++;
                MettreAJourPolice();
            }
        }
        private void BtnDiminuer_Click(object sender, RoutedEventArgs e)
        {
            if (taillePolice > 8)
            {
                taillePolice--;
                MettreAJourPolice();
            }
        }
        private void MettreAJourPolice()
        {
            TxtFontSize.Text = taillePolice.ToString();
        }

        private void Btnvalide_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Menu());
        }
    }
}
