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
using Systeme.Joueur;

namespace SAEIHM
{
    public partial class Confinterface : Page
    {
        public Confinterface()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
        private void Btnretour_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageChoisirMode());
        }
        private void VerifEtat(object sender, RoutedEventArgs e)
        {
            bool forme = rond.IsChecked == true || caree.IsChecked == true || etoile.IsChecked == true;
            bool couleur = rouge.IsChecked == true || bleu.IsChecked == true || rose.IsChecked == true;
            Btnvalide.IsEnabled = couleur && forme;
        }

        private void Btnvalide_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Confpartie());
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radiobouton = (RadioButton)sender;
            MainViewModel vm = (MainViewModel)this.DataContext;
            Para P = vm.ParaVM;


            // 1. Vérification des couleurs
            if (radiobouton == rouge) { P.Couleur1 = "rouge"; P.Couleur2 = "jaune"; return; }
            if (radiobouton == bleu) { P.Couleur1 = "bleu"; P.Couleur2 = "vert"; return; }
            if (radiobouton == rose) { P.Couleur1 = "rose"; P.Couleur2 = "noir"; return; }

            // 2. Vérification des formes
            if (radiobouton == rond) { P.Forme = "rond"; return; }
            if (radiobouton == caree) { P.Forme = "caree"; return; }
            if (radiobouton == etoile) { P.Forme = "etoile"; return; }

        }

    }
}
