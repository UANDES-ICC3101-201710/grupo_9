using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hearthstone
{
    class Player:  IAtacable
    {
        public string pname;
        public string name;
        public int TotalHealth = 30;
        public int CurrentHealth = 30;
        public int TotalMana = 1;
        public int CurrentMana = 1;
        public int Armor = 0;
        public int Class;
        public int PlayerNumber = 0;
        public int CurrentAttack = 0;
        public Boolean AttackRest = false;
        public Boolean PowerRest = true;
        public int fatigue = 0;
        public Boolean CurrentTurn = false;
        public List<Cards> MyHand = new List<Cards>();
        public List<Cards> MyDeck;
        public Field MyField;
        public int CardsInHand = 0;

        public Player(string p, int c, List<Cards> d, Field f)
        {
            pname = p;
            Class = c;
            MyDeck = d;
            MyField = f;
            if (c == 1)
            {
                name = "Warrior";
            }
            else if (c == 2)
                {
                name = "Hunter";
            }
        }

        public void PAttack(int dmg, Player enemy)
        {
            if (AttackRest)
            { 
                enemy.ReceiveDamage(dmg);
                AttackRest = false;
            }
            else { Console.WriteLine("No puedes atacar este turno."); }
        }

        public void MAttack(int dmg, Minions em)
        {
            if (AttackRest)
            {
                Console.WriteLine("Atacaste a " + em.name + " con " + dmg + " de daño");
                em.ReceiveDamage(dmg);
                this.ReceiveDamage(em.Attack);
                AttackRest = false;
            }
            else { Console.WriteLine("No puedes atacar este turno."); }
        }

        public void ReceiveDamage(int dmg)
        {
            Console.WriteLine("\n"+pname+" recibio " + dmg + " de daño.");
            if (Armor > 0)
            {
                Armor = Armor - dmg;
                if (Armor < 0)
                {
                    CurrentHealth = CurrentHealth + Armor;
                    Armor = 0;
                    Console.WriteLine("\nA " + name +" "+ pname + " le queda " + CurrentHealth + " de vida.");
                }
                else if (Armor > 0)
                {
                    Console.WriteLine("\nA " +name+ " "+ pname + " le queda " + CurrentHealth + " de vida y " + Armor + " de armadura.");
                }
            }
            else
            {
                CurrentHealth = CurrentHealth - dmg;
                Console.WriteLine("\nA " + name +" "+ pname + " le queda " + CurrentHealth + " de vida.");
            }

        }

        public void HeroPower(Player Enemy)
        {
            if (this.CurrentMana > 2)
            {
                if (Class == 1)
                {
                    Console.WriteLine("\nARMOR UP \n+2 Armor");
                    Armor = Armor + 2;
                    Console.WriteLine("\nArmadura Actual: " + Armor);
                }
                else if (Class == 2)
                {
                    Console.WriteLine("\nSTEADY SHOT \nHiciste 2 de daño");
                    Enemy.ReceiveDamage(2);
                }
                CurrentMana = CurrentMana - 2;
            }
            else { Console.WriteLine("No tienes Mana suficiente para utilizar tu Hero Power"); }
        }

        public void DrawFromDeck()
        {
            if (MyDeck.Count() > 0)
            {
                var carta = MyDeck.First();
                if (carta != null)
                {
                    Console.WriteLine("\nSacaste del mazo la carta: " + carta.GetName());
                    if (CardsInHand < 10)
                    {
                        MyHand.Add(carta);
                        CardsInHand += 1;
                    }
                    else { Console.WriteLine("\nHas superado el limite de cartas en tu mano. Carta quemada."); }
                }
                MyDeck.RemoveAt(0);
            }
            else
            {
                fatigue += 1;
                Console.WriteLine("\nNo te quedan mas cartas, recibes " + fatigue + " de daño fatiga.");
                this.ReceiveDamage(fatigue);
            }
            

        }

        public void PlayCard()
        {
            int select=100;
            var count = 0;
            Console.WriteLine("\nSeleccione su carta para jugar");

            foreach (var n in MyHand)
            {
                if (n is Minions)
                {
                    Minions a = n as Minions;
                    Console.WriteLine((count+1) + ".- " + a.GetName() + " cuesta: " + a.GetCost() + " tiene " + a.GetAttack() + " de ataque y " + a.GetCurrentLife() + " de vida.");
                }
                else if(n is Spells)
                {
                    Spells a = n as Spells;
                    Console.WriteLine((count+1) + ".- " + a.GetName() + "  y cuesta " + a.GetCost());
                }
                count += 1;
            }
            try
            {
                select = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("\nOpción Invalida.");
            }

            if (select <= MyHand.Count)
            {
                var card = MyHand[select - 1];
                if (card == null)
                {
                    Console.WriteLine("Comando invalido");
                }
                else if (card is Minions)
                {
                    Minions pcard = card as Minions;
                    Console.WriteLine("\nVas a jugar la carta: " + pcard.GetName());
                    if (pcard.GetCost() > CurrentMana)
                    {
                        Console.WriteLine("No tienes la mana suficiente.");
                    }
                    else
                    {
                        int cm = MyField.GetCurrentMinions();
                        if (cm < 7)
                        {
                            MyField.AddCurrentMinions(pcard);
                            CurrentMana -= card.GetCost();
                            MyHand.RemoveAt(select-1);
                            CardsInHand -= 1;
                        }
                        else { Console.WriteLine("\nNo puedes agregar mas cartas en el campo"); }
                    }
                }
                else if (card is Spells)
                {
                    Spells pcard = card as Spells;
                    Console.WriteLine("\nVas a jugar la carta: " + pcard.GetName());
                    pcard.Effect(this);
                    MyHand.RemoveAt(select - 1);
                }
            }
            else { Console.WriteLine("Comando Invalido"); }        
        }

        public void FirstTurn()
        {
            
            List<Cards> FirstHand = new List<Cards>();
            if (PlayerNumber == 1)
            {

                Console.WriteLine("\nTus cartas son: ");
                for (int num = 1; num < 4; num++)
                {
                    var carta = MyDeck.First();
                    Console.WriteLine(num + ".- " + carta.GetName());
                    FirstHand.Add(carta);
                    MyDeck.RemoveAt(0);

                }
            }

            else if (PlayerNumber == 2)
            {
                Console.WriteLine("\nTus cartas son: ");
                for (int num2 = 1; num2 < 5; num2++)
                {
                    var carta = MyDeck.First();
                    Console.WriteLine(num2 + ".- " + carta.GetName());
                    FirstHand.Add(carta);
                    MyDeck.RemoveAt(0);
                }
            }

            var chuk = true;
            while (chuk)
            {
                Console.WriteLine("\nOprime el numero de la carta que deseas cambiar, sino presiona 0:");

                int slct = 100;             
                try
                {
                    slct = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("\nOpción invalida");
                }


                if (slct == 0)
                {
                    chuk = false;
                }
                else if (slct <= FirstHand.Count())
                {
                    var cardxchng = FirstHand[slct - 1];

                    MyDeck.Add(cardxchng);
                    FirstHand.RemoveAt(slct - 1);
                    MyHand.Add(MyDeck.First());
                    CardsInHand++;
                    MyDeck.RemoveAt(0);
                    Console.WriteLine("\nCarta cambiada.\nSelecciona otra o presiona 0.");
                    var temp = 1;
                    foreach (var n in FirstHand)
                    {
                        Console.WriteLine(temp + ".- " + n.GetName());
                        temp++;
                    }
                }


                else { Console.WriteLine("\nComando no valido. \nIngrese de nuevo");
                    var temp = 1;
                    foreach (var n in FirstHand)
                    {
                        Console.WriteLine(temp + ".- " + n.GetName());
                        temp++;
                    }
                }
            
        
                
                
            }
            Console.WriteLine("\nTus nuevas cartas son: ");
            foreach (var n in FirstHand)
            {
                MyHand.Add(n);
                CardsInHand++;
            }
            foreach (var n in MyHand)
            {
                Console.WriteLine(n.GetName());
            }

        }

        public void EndTurn(Player Enemy)
        {
            Console.WriteLine("Jugador " + PlayerNumber + " ha terminado su turno. \nEs tu turno Jugador " + Enemy.PlayerNumber);
            CurrentTurn = false;
            Enemy.CurrentTurn = true;
            if (Enemy.TotalMana < 10)
            {
                Enemy.TotalMana++;
            }
            Enemy.CurrentMana = TotalMana;
            Enemy.MyField.TurnBegin();
        }


    }
}
