namespace classPARA
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;

    public class GridOption
    {
        public string Label { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }

        public GridOption(string label, int rows, int columns)
        {
            Label = label;
            Rows = rows;
            Columns = columns;
        }

        public override string ToString() => Label;
    }
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
