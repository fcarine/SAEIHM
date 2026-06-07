using System.ComponentModel;

namespace ClassIdentifiant
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using static System.Net.Mime.MediaTypeNames;

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
            set { this.nom1 = value; OnPropertyChanged(nameof(Nom1));}
        }

        public string Nom2
        {
            get { return this.nom2; }
            set { this.nom2 = value; OnPropertyChanged(nameof(Nom2));}
        }

        public string IdentifiantValue
        {
            get { return this.identifiant; }
            set { this.identifiant = value; OnPropertyChanged(nameof(IdentifiantValue));}
        }

        public string Mdp
        {
            get { return this.mdp; }
            set { this.mdp = value; OnPropertyChanged(nameof(Mdp));}
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


    public class Nationalite
    {
        public string Pays { get; set; }
        public Nationalite(string pays)
        {
            Pays = pays;
        }
    }

    public class NationaliteViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Nationalite> collection;
        public NationaliteViewModel()
        {
            Collection = new ObservableCollection<Nationalite>();
            Collection.Add(new Nationalite("Français"));
            Collection.Add(new Nationalite("English"));
            Collection.Add(new Nationalite("Español"));

        }

        public ObservableCollection<Nationalite> Collection
        {
            get { return collection; }
            set { collection = value; OnPropertyChanged(nameof(Collection)); }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

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
            Forme = "";
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

    public class MainViewModel
    {
        public Identifiant IdentifiantVM { get; set; }
        public NationaliteViewModel NationaliteVM { get; set; }
        public Para ParaVM { get; set; }

        public MainViewModel()
        {
            IdentifiantVM = new Identifiant();
            NationaliteVM = new NationaliteViewModel();
            ParaVM = new Para();
        }
    }



}


