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
   
    public partial class PageChoisirMode : Page
    {
        public PageChoisirMode()
        {
            InitializeComponent();
            DataContext = new Identifiant();
        }

        private void Btnretour_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageJouer1());
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radiobouton = (RadioButton)sender;

            if (radiobouton == Btnlocal)
            {
                local.IsEnabled = true;
                IA.IsEnabled = false;
                ligne.IsEnabled = false;
            }
            else if (radiobouton == BtnIA)
            {
                IA.IsEnabled = true;
                local.IsEnabled = false;
                ligne.IsEnabled = false;
            }
            else if (radiobouton == Btnligne)
            {
                ligne.IsEnabled = true;
                IA.IsEnabled = false;
                local.IsEnabled = false;
            }
        }

        private void VerifEtat(object sender, RoutedEventArgs e)
        {
            bool nomsaisit =!string.IsNullOrWhiteSpace(nom1.Text) &&
                !string.IsNullOrWhiteSpace(nom2.Text);

            bool modeChoisi = facile.IsChecked == true || moyen.IsChecked == true || difficile.IsChecked == true;

            Btnvalide.IsEnabled = nomsaisit || modeChoisi;
        }

        private void Btnconnecter_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Connexion());
        }

        private void Btninscrit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Inscription());
        }

        private void Btnvalide_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Jouer2());
        }
    }
}
