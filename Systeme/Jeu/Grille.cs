using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using Systeme.Jeu.Systeme.Jeu;

namespace Systeme.Jeu
{

    public class Grille
    {
        public int Lignes { get; }
        public int Colonnes { get; }
        public ObservableCollection<Cellule> Cellules { get; }

        public Grille(int lignes, int colonnes)
        {
            Lignes = lignes;
            Colonnes = colonnes;
            Cellules = new ObservableCollection<Cellule>();
            for (int y = 0; y < lignes; y++)
                for (int x = 0; x < colonnes; x++)
                    Cellules.Add(new Cellule { X = x, Y = y, Etat = 0 });
        }

        public Cellule GetCell(int x, int y)
            => Cellules.First(c => c.X == x && c.Y == y);

        // Place un pion par gravité, retourne la ligne ou -1 si pleine
        public int PlacerPion(int col, int joueur)
        {
            for (int y = Lignes - 1; y >= 0; y--)
            {
                var c = GetCell(col, y);
                if (c.Etat == 0) { c.Etat = joueur; return y; }
            }
            return -1;
        }

        public List<int> ColonnesJouables()
        {
            var list = new List<int>();
            for (int x = 0; x < Colonnes; x++)
                if (GetCell(x, 0).Etat == 0) list.Add(x);
            return list;
        }

        public bool EstPleine() => ColonnesJouables().Count == 0;

        public bool VerifierVictoire(int joueur)
        {
            // Horizontal
            for (int y = 0; y < Lignes; y++)
                for (int x = 0; x <= Colonnes - 4; x++)
                    if (Enumerable.Range(0, 4).All(k => GetCell(x + k, y).Etat == joueur)) return true;
            // Vertical
            for (int x = 0; x < Colonnes; x++)
                for (int y = 0; y <= Lignes - 4; y++)
                    if (Enumerable.Range(0, 4).All(k => GetCell(x, y + k).Etat == joueur)) return true;
            // Diagonale \
            for (int x = 0; x <= Colonnes - 4; x++)
                for (int y = 0; y <= Lignes - 4; y++)
                    if (Enumerable.Range(0, 4).All(k => GetCell(x + k, y + k).Etat == joueur)) return true;
            // Diagonale /
            for (int x = 0; x <= Colonnes - 4; x++)
                for (int y = 3; y < Lignes; y++)
                    if (Enumerable.Range(0, 4).All(k => GetCell(x + k, y - k).Etat == joueur)) return true;
            return false;
        }

        // Copie pour simulation IA
        public Grille Clone()
        {
            var g = new Grille(Lignes, Colonnes);
            foreach (var c in Cellules) g.GetCell(c.X, c.Y).Etat = c.Etat;
            return g;
        }
    }
}
