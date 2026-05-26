using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Logique d'interaction pour PageHisto.xaml
    /// </summary>
    public partial class PageHisto : Page
    {
        // Liste dynamique des scores
        public static ObservableCollection<ScorePartie> HistoriqueScores
            = new ObservableCollection<ScorePartie>();

        public PageHisto()
        {
            InitializeComponent();

            // Relie le DataGrid à la liste
            TableauScore.ItemsSource = HistoriqueScores;
        }

        private void btnretour_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Menu());
        }
    }
}
