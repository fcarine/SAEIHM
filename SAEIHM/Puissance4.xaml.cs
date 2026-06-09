using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using Systeme.Grid;
using Systeme.Jeu;
using Systeme.Joueur;

namespace SAEIHM
{
    public partial class Puissance4 : Page
    {
        private GameViewModel vm;
        private readonly Para parametres;
        private readonly GridViewModel gridVM;

        // Constructeur par défaut (JvsJ, grille 6x7)
        public Puissance4() : this(new Para(), new GridViewModel()) { }

        // Constructeur avec paramètres transmis depuis la page précédente
        public Puissance4(Para para, GridViewModel gvm)
        {
            InitializeComponent();
            parametres = para;
            gridVM = gvm;

            vm = new GameViewModel(gridVM, parametres);
            vm.PropertyChanged += (s, e) => Dispatcher.Invoke(RefreshUI);

            RefreshGrille();
            RefreshUI();
        }

        // ── Clic sur une cellule ─────────────────────────────────────────────
        private void Cellule_Click(object sender, RoutedEventArgs e)
        {
            if (vm.PartieTerminee) return;
            if (vm.ModeIA && vm.CurrentPlayer == 2) return;
            if (sender is Button btn && btn.Tag is int col)
            {
                bool victoire = vm.Play(col);

                if (vm.PartieTerminee)
                {
                    string msg = vm.MatchNul
                        ? "Match nul !"
                        : vm.ModeIA && vm.Vainqueur == 2
                            ? "L'IA gagne !"
                            : $"Joueur {vm.Vainqueur} gagne !";

                    MessageBox.Show(msg, "Fin de partie",
                        MessageBoxButton.OK, MessageBoxImage.None);
                    BtnMenu.IsEnabled = true;
                }
            }
        }

        // ── Rejouer ──────────────────────────────────────────────────────────
        private void BtnValider_Click(object sender, RoutedEventArgs e) => vm.Reset();

        private void BtnPause_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Partie en pause.", "Pause",
                MessageBoxButton.OKCancel, MessageBoxImage.None);
            // OK = reprendre (on ne fait rien), Cancel = recommencer
            if (result == MessageBoxResult.Cancel) vm.Reset();
        }

        // ── Mise à jour du header ────────────────────────────────────────────
        private void RefreshUI()
        {
            if (vm.PartieTerminee)
                TbJoueur.Text = vm.MatchNul ? "Match nul !" : $"Joueur {vm.Vainqueur} gagne !";
            else if (vm.ModeIA && vm.CurrentPlayer == 2)
                TbJoueur.Text = "Tour de l'IA...";
            else
                TbJoueur.Text = $"Tour : Joueur {vm.CurrentPlayer}";

            if (GrilleUI.ItemsSource != vm.Grille?.Cellules)
                RefreshGrille();
        }

        // ── Reconstruction de la grille ──────────────────────────────────────
        private void RefreshGrille()
        {
            if (vm.Grille == null) return;
            GrilleUI.ItemsSource = vm.Grille.Cellules;
            GrilleUI.UpdateLayout();
            var ug = TrouverUniformGrid(GrilleUI);
            if (ug != null) { ug.Rows = vm.Grille.Lignes; ug.Columns = vm.Grille.Colonnes; }
        }

        private static UniformGrid TrouverUniformGrid(DependencyObject d)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(d); i++)
            {
                var child = VisualTreeHelper.GetChild(d, i);
                if (child is UniformGrid ug) return ug;
                var found = TrouverUniformGrid(child);
                if (found != null) return found;
            }
            return null;
        }

        private void BtnMenu_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Menu());
        }
    }
}