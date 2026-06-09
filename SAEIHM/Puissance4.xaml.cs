using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Systeme;
using Systeme.Joueur;

namespace SAEIHM
{
    /// <summary>
    /// Logique d'interaction pour Puissance4.xaml
    /// </summary>
    public partial class Puissance4 : Page
    {
        public Puissance4()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }


    }
}
