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
    /// Logique d'interaction pour Confinterface.xaml
    /// </summary>
    public partial class Confinterface : Page
    {
        public Confinterface()
        {
            InitializeComponent();
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
    }
}
