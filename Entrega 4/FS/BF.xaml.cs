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
        private Gaming game;
        private Player Player1;
        private Player Player2;
        private Game g;
        int turna = 1;
        int turnb = 1;


        internal BF(Player a, Player b, Game d, Gaming game)
        {
            Player1 = a;
            Player2 = b;
            g = d;
            this.game = game;
            InitializeComponent();
            BFgrid.Children.Add(game);

            



        }

        private void Endbtn_Click(object sender, RoutedEventArgs e)
        {
            if (Player1.CurrentTurn)
            {
                Player1.EndTurn(Player2);
                game.GenerateBMana(turnb);
                turnb += 1;
                UpdateHandA(Player1);
            }
            else if (Player2.CurrentTurn)
            {
                Player2.EndTurn(Player1);
                game.GenerateAMana(turna);
                turna += 1;
                UpdateHandA(Player1);
            }

        }

        private void UpdateHandA(Player a)
        {
            foreach (Cards card in a.MyHand)
            {
                if (card != null)
                {
                    string stringPath = "Images/" + card.name + ".png";
                    Uri imageUri = new Uri(stringPath, UriKind.Relative);
                    BitmapImage imageBitmap = new BitmapImage(imageUri);
                    Image myImage = new Image();
                    this.game.Ahand1.Source = imageBitmap;
                }
            }
        }
    }
}
