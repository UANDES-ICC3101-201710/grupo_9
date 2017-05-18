using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hearthstone
{
    class Program
    {

        static void Main(string[] args)
        {


            Console.WriteLine("Ahora empezara el cachipun... \nES BROMA!");

            Game g = new Game();
            Console.WriteLine("Bienvenido a Fakestone! \nJugador A, ingrese su nombre: ");
            string NameA = Console.ReadLine();
            int Bowl = 1;
            try
            {
                Console.WriteLine("\nElija su clase: \n1 para Warrior \n2 para Hunter");
                Bowl = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("\nInvalido, Sera Warrior por Default");
                
            }


            




            var DeckOne = g.ShuffleList(g.CreateDeck());


            Console.WriteLine("\nJugador B ingrese su nombre: ");
            string NameB = Console.ReadLine();
            int Bowl2 = 2;
            try
            {
                Console.WriteLine("\nElija su clase: \n1 para Warrior \n2 para Hunter");
                Bowl2 = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("\nInvalido, Sera Hunter por Default");

            }


            var DeckTwo = g.ShuffleList(g.CreateDeck());


            Field FieldOne = new Field();
            Field FieldTwo = new Field();

            Player Player1 = new Player(NameA, Bowl, DeckOne, FieldOne);
            Player Player2 = new Player(NameB, Bowl2, DeckTwo, FieldTwo);


            
            
            g.Turn(Player1, Player2);

            Console.Write("\nGracias por Jugar! Presione cualquier Tecla para terminar el juego.");
            Console.ReadLine();




        }
    }
}

