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
    public partial class Connexion : Page
    {
        public Connexion()
        {
            InitializeComponent();
            this.DataContext = new Identifiant();
        }

        private void Btnretour_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageChoisirMode());
        }
        private void VerifEtat(object sender, RoutedEventArgs e)
        {
            bool idsaisit = !string.IsNullOrWhiteSpace(ID.Text);
            bool mdpsaisit = !string.IsNullOrWhiteSpace(MDP.Password);
            if (idsaisit && mdpsaisit)
            {
                Btnconnextion.IsEnabled = true;
            }
            else
            {
                Btnconnextion.IsEnabled=false;
            }
            
        }

        private void Btnvoirmdp_Click(object sender, RoutedEventArgs e)
        {
            if (MDP.Visibility == Visibility.Visible)
            {
                txtMDP.Text = MDP.Password;

                MDP.Visibility = Visibility.Collapsed;
                txtMDP.Visibility = Visibility.Visible;
            }
            else
            {
                MDP.Password = txtMDP.Text;

                txtMDP.Visibility = Visibility.Collapsed;
                MDP.Visibility = Visibility.Visible;
            }
        }

        private void Btnconnextion_Click(object sender, RoutedEventArgs e)
        {
            Identifiant I = (Identifiant)this.DataContext;
            if (ID.Text != I.IdentifiantValue || MDP.Password != I.Mdp)
            {
                MessageBox.Show("Erreur:\nIdentifiant incorrecte ou \nmot de passe incorrecte.\nRéessayez !");
                NavigationService.Navigate(new Connexion());
            }
            else
            {
                NavigationService.Navigate(new Jouer2());
            }
        }
    }
}
