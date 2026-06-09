using System;
using System.Collections.Generic;
using System.Text;

namespace Systeme.Joueur
{
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
