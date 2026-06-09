using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Systeme.Grid
{
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
}
