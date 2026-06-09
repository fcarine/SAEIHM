
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
   
    public partial class PageChoisirMode : Page
    {
        public PageChoisirMode()
        {
            InitializeComponent();
            DataContext = MainViewModel.Instance;
        }

        private void Btnretour_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageJouer1());
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radiobouton = (RadioButton)sender;
            MainViewModel vm = (MainViewModel)this.DataContext;
            Para P = vm.ParaVM;
            Console.WriteLine($"Sender: {radiobouton.Name}, DataContext: {vm.GetHashCode()}, Para: {P.GetHashCode()}");

            if (radiobouton == Btnlocal)
            {
                local.IsEnabled = true;
                IA.IsEnabled = false;
                ligne.IsEnabled = false;
                P.Mode = "local";
            }
            else if (radiobouton == BtnIA)
            {
                IA.IsEnabled = true;
                local.IsEnabled = false;
                ligne.IsEnabled = false;
                P.Mode = "IA";
            }
            else if (radiobouton == Btnligne)
            {
                ligne.IsEnabled = true;
                IA.IsEnabled = false;
                local.IsEnabled = false;
                P.Mode = "ligne";
            }
            Console.WriteLine($"Mode après: {P.Mode}");
        }

        private void VerifEtat(object sender, RoutedEventArgs e)
        {
            MainViewModel vm = (MainViewModel)this.DataContext;
            Identifiant I = vm.IdentifiantVM;
            I.Nom1 = n1.Text;
            I.Nom2 = n2.Text;


            bool nomsaisit =!string.IsNullOrWhiteSpace(n1.Text) &&
                !string.IsNullOrWhiteSpace(n2.Text);

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
