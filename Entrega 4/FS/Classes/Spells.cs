using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FS
{
    class Spells : Cards
    {
        public void Effect(Player p)
        {
            if (p.CurrentMana < 10)
            {
                p.CurrentMana++;
            }
            else
            {
                Console.WriteLine("No puedes jugar esta carta, pues tienes el máximo de maná");
            }
        }
        public Spells(string name, int cost, int rarity, int Class)
        {
            this.name = name;
            this.cost = cost;
            this.rarity = rarity;
            this.Class = Class;
        }
    }
}
