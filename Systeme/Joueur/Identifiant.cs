using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Systeme.Joueur
{
    public class Identifiant : INotifyPropertyChanged
    {
        private string nom1;
        private string nom2;
        private string identifiant;
        private string mdp;

        public Identifiant()
        {
            this.nom1 = "";
            this.nom2 = "";

            this.identifiant = "blablabla";
            this.mdp = "123456";
        }

        public string Nom1
        {
            get { return this.nom1; }
            set { this.nom1 = value; OnPropertyChanged(nameof(Nom1)); }
        }

        public string Nom2
        {
            get { return this.nom2; }
            set { this.nom2 = value; OnPropertyChanged(nameof(Nom2)); }
        }

        public string IdentifiantValue
        {
            get { return this.identifiant; }
            set { this.identifiant = value; OnPropertyChanged(nameof(IdentifiantValue)); }
        }

        public string Mdp
        {
            get { return this.mdp; }
            set { this.mdp = value; OnPropertyChanged(nameof(Mdp)); }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
