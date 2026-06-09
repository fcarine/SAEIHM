using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using Systeme.Grid;
using Systeme.IA;
using Systeme.Joueur;

namespace Systeme.Jeu
{
    public class GameViewModel : INotifyPropertyChanged
    {
        private Grille grille;
        public Grille Grille
        {
            get => grille;
            set { grille = value; OnPropertyChanged(nameof(Grille)); }
        }

        private int currentPlayer = 1;
        public int CurrentPlayer
        {
            get => currentPlayer;
            set { currentPlayer = value; OnPropertyChanged(nameof(CurrentPlayer)); }
        }

        public bool PartieTerminee { get; private set; }
        public bool MatchNul { get; private set; }
        public int? Vainqueur { get; private set; }

        private readonly Para parametres;
        public bool ModeIA => parametres.Mode == "IA";

        private readonly AlgorithmeIA ia = new AlgorithmeIA(ia: 2, adversaire: 1);
        private GridOption currentOption;

        public GameViewModel(GridViewModel selector, Para para)
        {
            parametres = para;
            selector.GridChanged += OnGridChanged;
            OnGridChanged(selector.SelectedGrid);
        }

        private void OnGridChanged(GridOption option)
        {
            currentOption = option;
            Grille = new Grille(option.Rows, option.Cols, parametres); // ← parametres ajouté
            CurrentPlayer = 1;
            PartieTerminee = false;
            MatchNul = false;
            Vainqueur = null;
        }

        public void Reset() => OnGridChanged(currentOption);

        public bool Play(int col)
        {
            if (Grille == null || PartieTerminee) return false;
            if (Grille.PlacerPion(col, CurrentPlayer) == -1) return false;

            if (Grille.VerifierVictoire(CurrentPlayer))
            {
                Vainqueur = CurrentPlayer; PartieTerminee = true;
                OnPropertyChanged(nameof(PartieTerminee));
                return true;
            }
            if (Grille.EstPleine())
            {
                MatchNul = true; PartieTerminee = true;
                OnPropertyChanged(nameof(PartieTerminee));
                return false;
            }

            CurrentPlayer = CurrentPlayer == 1 ? 2 : 1;

            if (ModeIA && CurrentPlayer == 2) JouerIA();
            return false;
        }

        public void JouerIA()
        {
            if (PartieTerminee) return;
            int col = ia.ChoisirCoup(Grille);
            if (col == -1) return;
            Grille.PlacerPion(col, 2);

            if (Grille.VerifierVictoire(2))
            {
                Vainqueur = 2; PartieTerminee = true;
                OnPropertyChanged(nameof(PartieTerminee));
                return;
            }
            if (Grille.EstPleine())
            {
                MatchNul = true; PartieTerminee = true;
                OnPropertyChanged(nameof(PartieTerminee));
                return;
            }
            CurrentPlayer = 1;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
