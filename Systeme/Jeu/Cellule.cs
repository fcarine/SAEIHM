using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Systeme.Joueur;

namespace Systeme.Jeu
{

    using System.ComponentModel;

    namespace Systeme.Jeu
    {
        public class Cellule : INotifyPropertyChanged
        {
            public int X { get; set; }
            public int Y { get; set; }

            public string Couleur1 { get; set; }
            public string Couleur2 { get; set; }

            public string Couleur => Etat == 1 ? Couleur1 : Etat == 2 ? Couleur2 : "Transparent";

            private int etat;
            public int Etat
            {
                get => etat;
                set { etat = value; OnPropertyChanged(nameof(Etat)); OnPropertyChanged(nameof(Couleur)); }
            }

            public event PropertyChangedEventHandler PropertyChanged;
            protected void OnPropertyChanged(string name)
                => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
