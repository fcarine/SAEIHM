using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Systeme.Grid
{
    public class GridOption : INotifyPropertyChanged
    {
        private string label;
        private int rows;
        private int cols;

        public string Label
        {
            get => label;
            set { label = value; OnPropertyChanged(nameof(Label)); }
        }

        public int Rows
        {
            get => rows;
            set { rows = value; OnPropertyChanged(nameof(Rows)); }
        }

        public int Cols
        {
            get => cols;
            set { cols = value; OnPropertyChanged(nameof(Cols)); }
        }

        public GridOption(string label, int rows, int cols)
        {
            Label = label;
            Rows = rows;
            Cols = cols;
        }

        public override string ToString() => Label;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
