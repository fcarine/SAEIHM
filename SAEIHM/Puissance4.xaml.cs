using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SAEIHM
{
    public partial class Puissance4 : Page
    {
        private int[,] plateau = new int[6, 7];
        private Ellipse[,] cases = new Ellipse[6, 7];
        private bool joueurRouge = true;


        public Puissance4()
        {
            InitializeComponent();
            CreerGrille();
        }

        private void CreerGrille()
        {
            for (int ligne = 0; ligne < 6; ligne++)
            {
                for (int colonne = 0; colonne < 7; colonne++)
                {
                    Border bordure = new Border
                    {
                        BorderBrush = Brushes.Black,
                        BorderThickness = new Thickness(1),
                        Background = Brushes.Blue,
                        Margin = new Thickness(2)
                    };

                    Ellipse cercle = new Ellipse
                    {
                        Fill = Brushes.White,
                        Margin = new Thickness(5)
                    };

                    bordure.Child = cercle;

                    bordure.Tag = new Point(ligne, colonne);
                    bordure.MouseLeftButtonDown += CaseCliquee;

                    cases[ligne, colonne] = cercle;
                    GrilleJeu.Children.Add(bordure);
                }
            }
        }
        private void JouerColonne(int colonne)
        {
            for (int ligne = 5; ligne >= 0; ligne--)
            {
                if (plateau[ligne, colonne] == 0)
                {
                    plateau[ligne, colonne] = joueurRouge ? 1 : 2;

                    cases[ligne, colonne].Fill =
                        joueurRouge ? Brushes.Red : Brushes.Yellow;

                    joueurRouge = !joueurRouge;
                    break;
                }
            }
        }
        private void CaseCliquee(object sender,
    System.Windows.Input.MouseButtonEventArgs e)
        {
            Border caseCliquee = (Border)sender;
            Point p = (Point)caseCliquee.Tag;

            int colonne = (int)p.Y;

            JouerColonne(colonne);
        }


    }
}