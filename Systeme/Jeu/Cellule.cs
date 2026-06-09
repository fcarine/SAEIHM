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

            private int etat;
            public int Etat
            {
                get => etat;
                set { etat = value; OnPropertyChanged(nameof(Etat)); }
            }

            public event PropertyChangedEventHandler PropertyChanged;
            protected void OnPropertyChanged(string name)
                => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
