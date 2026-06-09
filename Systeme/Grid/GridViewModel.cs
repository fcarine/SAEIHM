using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Systeme;
using Systeme.Jeu;

namespace Systeme.Grid
{
    public class GridViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<GridOption> Collection { get; set; }

        public GridViewModel()
        {
            Collection = new ObservableCollection<GridOption>
        {
            new GridOption("6x7", 6, 7),
            new GridOption("7x7", 7, 7),
            new GridOption("7x8", 7, 8)
        };

            SelectedGrid = Collection[0];
        }

        private GridOption selectedGrid;
        public GridOption SelectedGrid
        {
            get { return selectedGrid; }
            set
            {
                selectedGrid = value;
                OnPropertyChanged(nameof(SelectedGrid));

                GridChanged?.Invoke(selectedGrid); 
            }
        }
        public event Action<GridOption> GridChanged;

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

}
