using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace Systeme.Joueur
{
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

}
