using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using Systeme.Jeu.Systeme.Jeu;

namespace Systeme.Jeu
{

    public class Grille
    {
        public int Lignes { get; set; }
        public int Colonnes { get; set; }

        public ObservableCollection<Cellule> Cellules { get; set; }

        public Grille(int lignes, int colonnes)
        {
            Lignes = lignes;
            Colonnes = colonnes;

            Cellules = new ObservableCollection<Cellule>();

            for (int y = 0; y < lignes; y++)
            {
                for (int x = 0; x < colonnes; x++)
                {
                    Cellules.Add(new Cellule
                    {
                        X = x,
                        Y = y,
                        Etat = 0
                    });
                }
            }
        }

        public Cellule GetCell(int x, int y)
        {
            return Cellules.First(c => c.X == x && c.Y == y);
        }
    }
}
