
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
using Systeme;
using Systeme.Grid;

namespace SAEIHM
{
    public partial class Confpartie : Page
    {
        public Confpartie()
        {
            InitializeComponent();
            DataContext = new GridViewModel();

        }
        private void Btnretour_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Confinterface());
        }

        private double jeton = 4;
        private double temps = 30;
        private void BtnAugmenter_Click(object sender, RoutedEventArgs e)
        {
            if (jeton < 7)
            {
                jeton++;
                MettreAJourPolice();
            }
        }
        private void BtnAugmenter1_Click(object sender, RoutedEventArgs e)
        {
            if (temps < 60)
            {
                temps++;
                MettreAJourPolice();
            }
        }
        private void BtnDiminuer_Click(object sender, RoutedEventArgs e)
        {
            if (jeton > 4)
            {
                jeton--;
                MettreAJourPolice();
            }
        }
        private void BtnDiminuer1_Click(object sender, RoutedEventArgs e)
        {
            if (temps > 30)
            {
                temps--;
                MettreAJourPolice();
            }
        }
        private void MettreAJourPolice()
        {
            Txtjeton.Text = jeton.ToString();
            Txttemps.Text = temps.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Txtjeton.Text = "4";
            Txttemps.Text = "30";

            grille.SelectedIndex = 0;
        }

        private void Btnvalide_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Conftouche());
        }
    }
}
