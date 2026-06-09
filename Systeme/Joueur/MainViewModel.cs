using System;
using System.Collections.Generic;
using System.Text;
using Systeme.Grid;

namespace Systeme.Joueur
{
    public class MainViewModel
    {
        public Identifiant IdentifiantVM { get; set; }
        public NationaliteViewModel NationaliteVM { get; set; }
        public Para ParaVM { get; set; }
        public GridViewModel Grid { get; set; }
        private static MainViewModel _instance;
        public static MainViewModel Instance => _instance ??= new MainViewModel();

        public MainViewModel()
        {
            IdentifiantVM = new Identifiant();
            NationaliteVM = new NationaliteViewModel();
            ParaVM = new Para();
            Grid = new GridViewModel();
        }
    }
}
