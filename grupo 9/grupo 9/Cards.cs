using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hearthstone
{
    class Cards
    {   public string name;
        public int cost;
        public int rarity;
        public int Class;


        public string GetName()
        {
            return name;
        }
        public int GetCost()
        {
            return cost;
        }
        public int GetRarity()
        {
            return rarity;
        }
        public int GetClass()
        {
            return Class;
        }
    }
}
