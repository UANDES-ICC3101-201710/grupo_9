using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FS
{
    class Minions:Cards
    {
        public int TotalLife;
        public int CurrentLife;
        public int Attack;
        public Boolean AttackRest = false;
        public int Tribe;


        public int GetTotalLife()
        {
            return TotalLife;
        }
        public int GetCurrentLife()
        {
            return CurrentLife;
        }
        public int GetAttack()
        {
            return Attack;
        }
        public int GetTribe()
        {
            return Tribe;
        }

        public void ReceiveDamage(int dmg)
        {
            Console.WriteLine("\nMinion " + name + " recibio " + dmg + " de daño.");
            CurrentLife -= dmg;
            Console.WriteLine("\nAl minion " + name + " le queda " + CurrentLife + " de vida.");
        }

        public void PAttack(Player enemy)
        {
            int dmg = Attack;
            if (AttackRest)
            {
                Console.WriteLine("\n" + name + " atacó con " + dmg + " al Heroe enemigo");
                enemy.ReceiveDamage(dmg);
                AttackRest = false;
            }
            else { Console.WriteLine("\n" + name + " no puede atacar este turno."); }
        }
        public void MAttack(Minions em)
        {
            int dmg = Attack;
            if (AttackRest)
            {
                Console.WriteLine("\n" + name + " atacó a " + em.name + " con " + dmg + " de daño");
                em.ReceiveDamage(dmg);
                this.ReceiveDamage(em.Attack);
                AttackRest = false;
            }
            else { Console.WriteLine("\n" + name + " no puede atacar este turno."); }
        }

        public Minions(string name, int Cost, int Rarity, int Class, int Life, int Attack, int Tribe)
        {
            this.name = name;
            this.cost = Cost;
            this.rarity = Rarity;
            this.Class = Class;
            this.TotalLife = Life;
            this.Attack = Attack;
            this.Tribe = Tribe;

            CurrentLife = TotalLife;
        }
    }
}

