
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
    /// <summary>
    /// Logique d'interaction pour Inscription.xaml
    /// </summary>
    public partial class Inscription : Page
    {
        public Inscription()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
        private void Btnretour_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageChoisirMode());
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
        private void VerifEtat(object sender, RoutedEventArgs e)
        {

            bool identifiantsaisit = !string.IsNullOrWhiteSpace(ID.Text);
            bool pseudosaisit = !string.IsNullOrWhiteSpace(pseudo.Text);
            bool mdpsaisit = !string.IsNullOrWhiteSpace(MDP.Password);

            Btninscrire.IsEnabled = identifiantsaisit && mdpsaisit && pseudosaisit;
        }

        private void Btninscrire_Click(object sender, RoutedEventArgs e)
        {
            MainViewModel vm = (MainViewModel)this.DataContext;
            Identifiant I = vm.IdentifiantVM;
            if (MDP.Password.Length < 6)
            {
                MessageBox.Show("Mot de passe doit contenir 6 caractères");
                return;
            }

            if (ID.Text == I.IdentifiantValue)
            {
                MessageBox.Show("Identifiant déjà utilisé");
                return;
            }

            NavigationService.Navigate(new Jouer2());
        }
    }
}
