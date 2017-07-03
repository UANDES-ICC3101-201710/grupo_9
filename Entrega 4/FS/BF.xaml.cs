using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Interop;

namespace FS
{
    /// <summary>
    /// Interaction logic for BF.xaml
    /// </summary>
    public partial class BF : Page
    {
        Grid grid = new Grid();
        private Gaming game;
        private Player Player1;
        private Player Player2;
        private Game g;
        
        

        internal BF(Player a, Player b, Game d)
        {
            Player1 = a;
            Player2 = b;
            g = d;
            InitializeComponent();
            
            


        }

        private void StartBoard()
        {
            Content = grid;

            this.MinHeight = 800;
            this.MinWidth = 1280;
            this.Height = 800;
            this.Width = 1280;

            game = new Gaming();
            grid.Children.Add(game);            
        }
        
    }
}
