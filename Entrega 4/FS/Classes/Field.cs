using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FS
{
    class Field
    {
        public List<Minions> CardsInField = new List<Minions>();
        public int CurrentMinions = 0;
        public int MinionLimit = 7;
        public Boolean WeaponTrue = false;




        public void CheckMinionsLife()
        {
            foreach (var n in CardsInField)
            {
                if (n.CurrentLife <= 0)
                {
                    Console.WriteLine("\n" + n.GetName() + " fue eliminado del juego!");
                }
            }
            CardsInField.RemoveAll(x => x.CurrentLife <= 0);
        }



        public int GetCurrentMinions()
        {
            return CurrentMinions;

        }
        public void AddCurrentMinions(Minions m)
        {
            CardsInField.Add(m);
            CurrentMinions++;
        }

        public void TurnBegin()
        {
            foreach (var n in CardsInField)
            {
                n.AttackRest = true;
            }
        }



    }
}

