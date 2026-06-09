using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace Systeme.Grid
{
    public class GridViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<GridOption> collection;

        public GridViewModel()
        {
            Collection = new ObservableCollection<GridOption>();

            Collection.Add(new GridOption("6x7", 6, 7));
            Collection.Add(new GridOption("7x7", 7, 7));
            Collection.Add(new GridOption("7x8", 7, 8));
        }

        public ObservableCollection<GridOption> Collection
        {
            get { return collection; }
            set
            {
                collection = value;
                OnPropertyChanged(nameof(Collection));
            }
        }

        private GridOption selectedGrid;
        public GridOption SelectedGrid
        {
            get { return selectedGrid; }
            set
            {
                selectedGrid = value;
                OnPropertyChanged(nameof(SelectedGrid));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
