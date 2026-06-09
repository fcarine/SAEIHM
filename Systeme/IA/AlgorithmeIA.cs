using System;
using System.Collections.Generic;
using System.Text;
using Systeme.Jeu;

namespace Systeme.IA
{
    internal class AlgorithmeIA
    {
        private readonly int joueurIA;
        private readonly int joueurAdv;
        private const int PROFONDEUR = 6; // augmente pour plus de difficulté

        public AlgorithmeIA(int ia, int adversaire)
        {
            joueurIA = ia;
            joueurAdv = adversaire;
        }

        public int ChoisirCoup(Grille grille)
        {
            var coups = grille.ColonnesJouables();
            if (coups.Count == 0) return -1;

            int meilleureCol = coups[0];
            int meilleurScore = int.MinValue;

            foreach (int col in OrdonnerCoups(coups, grille.Colonnes))
            {
                var copie = grille.Clone();
                copie.PlacerPion(col, joueurIA);
                int score = Minimax(copie, PROFONDEUR - 1, int.MinValue, int.MaxValue, false);
                if (score > meilleurScore)
                {
                    meilleurScore = score;
                    meilleureCol = col;
                }
            }
            return meilleureCol;
        }

        // Joue les colonnes du centre vers les bords (meilleure exploration)
        private IEnumerable<int> OrdonnerCoups(List<int> coups, int nbCols)
        {
            return coups.OrderBy(c => Math.Abs(c - nbCols / 2));
        }

        private int Minimax(Grille g, int profondeur, int alpha, int beta, bool maximise)
        {
            if (g.VerifierVictoire(joueurIA)) return 100000 + profondeur;
            if (g.VerifierVictoire(joueurAdv)) return -100000 - profondeur;
            if (g.EstPleine() || profondeur == 0) return Evaluer(g);

            var coups = OrdonnerCoups(g.ColonnesJouables(), g.Colonnes).ToList();

            if (maximise)
            {
                int score = int.MinValue;
                foreach (int col in coups)
                {
                    var copie = g.Clone();
                    copie.PlacerPion(col, joueurIA);
                    score = Math.Max(score, Minimax(copie, profondeur - 1, alpha, beta, false));
                    alpha = Math.Max(alpha, score);
                    if (alpha >= beta) break; // élagage
                }
                return score;
            }
            else
            {
                int score = int.MaxValue;
                foreach (int col in coups)
                {
                    var copie = g.Clone();
                    copie.PlacerPion(col, joueurAdv);
                    score = Math.Min(score, Minimax(copie, profondeur - 1, alpha, beta, true));
                    beta = Math.Min(beta, score);
                    if (alpha >= beta) break; // élagage
                }
                return score;
            }
        }

        private int Evaluer(Grille g)
        {
            int score = 0;
            int centre = g.Colonnes / 2;

            // Bonus colonne centrale
            for (int y = 0; y < g.Lignes; y++)
            {
                int etat = g.GetCell(centre, y).Etat;
                if (etat == joueurIA) score += 4;
                else if (etat == joueurAdv) score -= 4;
            }

            // Fenêtres de 4 dans les 4 directions
            int[][] dirs = { new[] { 1, 0 }, new[] { 0, 1 }, new[] { 1, 1 }, new[] { 1, -1 } };
            foreach (var d in dirs)
                for (int y = 0; y < g.Lignes; y++)
                    for (int x = 0; x < g.Colonnes; x++)
                        score += ScoreFenetre(g, x, y, d[0], d[1]);

            return score;
        }

        private int ScoreFenetre(Grille g, int x, int y, int dx, int dy)
        {
            int nbIA = 0, nbAdv = 0, nbVide = 0;
            for (int k = 0; k < 4; k++)
            {
                int nx = x + k * dx, ny = y + k * dy;
                if (nx < 0 || nx >= g.Colonnes || ny < 0 || ny >= g.Lignes) return 0;
                int e = g.GetCell(nx, ny).Etat;
                if (e == joueurIA) nbIA++;
                else if (e == joueurAdv) nbAdv++;
                else nbVide++;
            }

            if (nbIA == 4) return 100;
            if (nbAdv == 4) return -100;
            if (nbIA == 3 && nbVide == 1) return 10;
            if (nbIA == 2 && nbVide == 2) return 2;
            if (nbAdv == 3 && nbVide == 1) return -15;
            return 0;
        }
    }
}
