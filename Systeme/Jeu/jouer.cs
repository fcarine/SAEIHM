using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Linq;
using Systeme.Grid;
using System.ComponentModel;
using System.Windows;

namespace Systeme.Jeu
{

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

            private GridOption currentOption;

            public GameViewModel(GridViewModel selector)
            {
                selector.GridChanged += OnGridChanged;
                OnGridChanged(selector.SelectedGrid);
            }

            private void OnGridChanged(GridOption option)
            {
                currentOption = option;
                Grille = new Grille(option.Rows, option.Cols);
                CurrentPlayer = 1;
            }

            public void Reset()
            {
                if (currentOption != null)
                    OnGridChanged(currentOption);
            }

            public bool Play(int column)
            {
                if (Grille == null) return false;

                for (int y = Grille.Lignes - 1; y >= 0; y--)
                {
                    var cell = Grille.GetCell(column, y);
                    if (cell.Etat == 0)
                    {
                        cell.Etat = CurrentPlayer;
                        if (CheckWin(column, y))
                            return true; // victoire

                        SwitchPlayer();
                        return false;
                    }
                }
                return false; // colonne pleine
            }

            private void SwitchPlayer() => CurrentPlayer = CurrentPlayer == 1 ? 2 : 1;

            private bool CheckWin(int x, int y)
                => CheckDirection(x, y, 1, 0)
                || CheckDirection(x, y, 0, 1)
                || CheckDirection(x, y, 1, 1)
                || CheckDirection(x, y, 1, -1);

            private bool CheckDirection(int x, int y, int dx, int dy)
            {
                int count = 1 + Count(x, y, dx, dy) + Count(x, y, -dx, -dy);
                return count >= 4;
            }

            private int Count(int x, int y, int dx, int dy)
            {
                int player = CurrentPlayer, c = 0;
                x += dx; y += dy;
                while (x >= 0 && x < Grille.Colonnes && y >= 0 && y < Grille.Lignes)
                {
                    if (Grille.GetCell(x, y).Etat == player) { c++; x += dx; y += dy; }
                    else break;
                }
                return c;
            }

            public event PropertyChangedEventHandler PropertyChanged;
            private void OnPropertyChanged(string name)
                => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
