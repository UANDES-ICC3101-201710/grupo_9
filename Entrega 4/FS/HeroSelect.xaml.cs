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

namespace FS
{
    /// <summary>
    /// Interaction logic for HeroSelect.xaml
    /// </summary>
    public partial class HeroSelect : Page
    {
        int c1;
        int c2;
        int PlayerCheck = 0;
        string NameA;
        string NameB;

        public HeroSelect()
        {
            InitializeComponent();
            nameA.Visibility = Visibility.Visible;
            nameB.Visibility = Visibility.Hidden;
        }

        
        Game g = new Game();
        Field FieldOne = new Field();
        Field FieldTwo = new Field();
        List<Cards> DeckOne = new List<Cards>();
        List<Cards> DeckTwo = new List<Cards>();

        

        private void Warrior_Click(object sender, RoutedEventArgs e)
        {
            if (PlayerCheck == 0)
            {
                DeckOne = g.ShuffleList(g.CreateDeck(DeckOne));
                c1 = 1;
                NameA = nameA.Text;
                nameB.Visibility = Visibility.Visible;
                nameA.Visibility = Visibility.Hidden;
                Label1.Content = "Jugador 2 ingrese su nombre";
                PlayerCheck += 1;
            }
            else if (PlayerCheck==1)
            {
                DeckTwo = g.ShuffleList(g.CreateDeck(DeckTwo));
                c2 = 1;
                NameB = nameB.Text;
                nameB.Visibility = Visibility.Hidden;
                Label1.Content = "Presione Game Start";
                Label2.Visibility = Visibility.Hidden;
                PlayerCheck += 1;
            }

        }

        private void Chaman_Click(object sender, RoutedEventArgs e)
        {
            if (PlayerCheck == 0)
            {
                DeckOne = g.ShuffleList(g.CreateDeck(DeckOne));
                c1 = 2;
                NameA = nameA.Text;
                nameB.Visibility = Visibility.Visible;
                nameA.Visibility = Visibility.Hidden;
                Label1.Content = "Jugador 2 ingrese su nombre";
                PlayerCheck += 1;
            }
            else if (PlayerCheck == 1)
            {
                DeckTwo = g.ShuffleList(g.CreateDeck(DeckTwo));
                c2 = 2;
                NameB = nameB.Text;
                nameB.Visibility = Visibility.Hidden;
                Label1.Content = "Presione Game Start";
                Label2.Visibility = Visibility.Hidden;
                PlayerCheck += 1;
            }

        }

        private void Picaro_Click(object sender, RoutedEventArgs e)
        {
            if (PlayerCheck == 0)
            {
                DeckOne = g.ShuffleList(g.CreateDeck(DeckOne));
                c1 = 3;
                NameA = nameA.Text;
                nameB.Visibility = Visibility.Visible;
                nameA.Visibility = Visibility.Hidden;
                Label1.Content = "Jugador 2 ingrese su nombre";
                PlayerCheck += 1;
            }
            else if (PlayerCheck == 1)
            {
                DeckTwo = g.ShuffleList(g.CreateDeck(DeckTwo));
                c2 = 3;
                NameB = nameB.Text;
                nameB.Visibility = Visibility.Hidden;
                Label1.Content = "Presione Game Start";
                Label2.Visibility = Visibility.Hidden;
                PlayerCheck += 1;
            }

        }

        private void Paladin_Click(object sender, RoutedEventArgs e)
        {
            if (PlayerCheck == 0)
            {
                DeckOne = g.ShuffleList(g.CreateDeck(DeckOne));
                c1 = 4;
                NameA = nameA.Text;
                nameB.Visibility = Visibility.Visible;
                nameA.Visibility = Visibility.Hidden;
                Label1.Content = "Jugador 2 ingrese su nombre";
                PlayerCheck += 1;
            }
            else if (PlayerCheck == 1)
            {
                DeckTwo = g.ShuffleList(g.CreateDeck(DeckTwo));
                c2 = 4;
                NameB = nameB.Text;
                nameB.Visibility = Visibility.Hidden;
                Label1.Content = "Presione Game Start";
                Label2.Visibility = Visibility.Hidden;
                PlayerCheck += 1;
            }

        }

        private void Hunter_Click(object sender, RoutedEventArgs e)
        {
            if (PlayerCheck == 0)
            {
                DeckOne = g.ShuffleList(g.CreateDeck(DeckOne));
                c1 = 5;
                NameA = nameA.Text;
                nameB.Visibility = Visibility.Visible;
                nameA.Visibility = Visibility.Hidden;
                Label1.Content = "Jugador 2 ingrese su nombre";
                PlayerCheck += 1;
            }
            else if (PlayerCheck == 1)
            {
                DeckTwo = g.ShuffleList(g.CreateDeck(DeckTwo));
                c2 = 5;
                NameB = nameB.Text;
                nameB.Visibility = Visibility.Hidden;
                Label1.Content = "Presione Game Start";
                Label2.Visibility = Visibility.Hidden;
                PlayerCheck += 1;
            }

        }

        private void Druida_Click(object sender, RoutedEventArgs e)
        {
            if (PlayerCheck == 0)
            {
                DeckOne = g.ShuffleList(g.CreateDeck(DeckOne));
                c1 = 6;
                NameA = nameA.Text;
                nameB.Visibility = Visibility.Visible;
                nameA.Visibility = Visibility.Hidden;
                Label1.Content = "Jugador 2 ingrese su nombre";
                PlayerCheck += 1;
            }
            else if (PlayerCheck == 1)
            {
                DeckTwo = g.ShuffleList(g.CreateDeck(DeckTwo));
                c2 = 6;
                NameB = nameB.Text;
                nameB.Visibility = Visibility.Hidden;
                Label1.Content = "Presione Game Start";
                Label2.Visibility = Visibility.Hidden;
                PlayerCheck += 1;
            }

        }

        private void Witcher_Click(object sender, RoutedEventArgs e)
        {
            if (PlayerCheck == 0)
            {
                DeckOne = g.ShuffleList(g.CreateDeck(DeckOne));
                c1 = 7;
                NameA = nameA.Text;
                nameB.Visibility = Visibility.Visible;
                nameA.Visibility = Visibility.Hidden;
                Label1.Content = "Jugador 2 ingrese su nombre";
                PlayerCheck += 1;
            }
            else if (PlayerCheck == 1)
            {
                DeckTwo = g.ShuffleList(g.CreateDeck(DeckTwo));
                c2 = 7;
                NameB = nameB.Text;
                nameB.Visibility = Visibility.Hidden;
                Label1.Content = "Presione Game Start";
                Label2.Visibility = Visibility.Hidden;
                PlayerCheck += 1;
            }

        }

        private void Wizard_Click(object sender, RoutedEventArgs e)
        {
            if (PlayerCheck == 0)
            {
                DeckOne = g.ShuffleList(g.CreateDeck(DeckOne));
                c1 = 8;
                NameA = nameA.Text;
                nameB.Visibility = Visibility.Visible;
                nameA.Visibility = Visibility.Hidden;
                Label1.Content = "Jugador 2 ingrese su nombre";
                PlayerCheck += 1;
            }
            else if (PlayerCheck == 1)
            {
                DeckTwo = g.ShuffleList(g.CreateDeck(DeckTwo));
                c2 = 8;
                NameB = nameB.Text;
                nameB.Visibility = Visibility.Hidden;
                Label1.Content = "Presione Game Start";
                Label2.Visibility = Visibility.Hidden;
                PlayerCheck += 1;
            }

        }

        private void Priest_Click(object sender, RoutedEventArgs e)
        {
            if (PlayerCheck == 0)
            {
                DeckOne = g.ShuffleList(g.CreateDeck(DeckOne));
                c1 = 9;
                NameA = nameA.Text;
                nameB.Visibility = Visibility.Visible;
                nameA.Visibility = Visibility.Hidden;
                Label1.Content = "Jugador 2 ingrese su nombre";
                PlayerCheck += 1;
            }
            else if (PlayerCheck == 1)
            {
                DeckTwo = g.ShuffleList(g.CreateDeck(DeckTwo));
                c2 = 9;
                NameB = nameB.Text;
                nameB.Visibility = Visibility.Hidden;
                Label1.Content = "Presione Game Start";
                Label2.Visibility = Visibility.Hidden;
                PlayerCheck += 1;
            }

        }

        private void ToBG(object sender, RoutedEventArgs e)
        {
            if (PlayerCheck == 2)
            {
                Player Player1 = new Player(NameA, c1, DeckOne, FieldOne);
                Player Player2 = new Player(NameB, c2, DeckTwo, FieldTwo);
                g.SelectTurns(Player1, Player2);
                BF p2 = new BF(Player1, Player2, g);
                MainFrame.Navigate(p2);
            }
            
        }

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }
    }
}
