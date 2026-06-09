using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;

namespace Systeme.Joueur
{
    public class Para : INotifyPropertyChanged
    {
        private string forme;
        public string Forme
        {
            get => forme;
            set
            {
                forme = value;
                OnPropertyChanged(nameof(Forme));
            }
        }

        private string mode;
        public string Mode
        {
            get => mode;
            set
            {
                mode = value;
                OnPropertyChanged(nameof(Mode));
            }
        }

        private string couleur1;
        public string Couleur1
        {
            get => couleur1;
            set
            {
                couleur1 = value;
                OnPropertyChanged(nameof(Couleur1));
            }
        }

        private string couleur2;
        public string Couleur2
        {
            get => couleur2;
            set
            {
                couleur2 = value;
                OnPropertyChanged(nameof(Couleur2));
            }
        }

        public Para()
        {
            Forme = "rond";
            Mode = "";
            Couleur1 = "Rouge";
            Couleur2 = "Jaune";
        }
       
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
