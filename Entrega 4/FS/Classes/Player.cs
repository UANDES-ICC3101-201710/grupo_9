using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FS
{
    class Player
    {
        public string pname;
        public string name;
        public int TotalHealth = 30;
        public int CurrentHealth = 30;
        public int TotalMana = 1;
        public int CurrentMana = 10;
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
                name = "Shaman";
            }
            else if (c == 3)
            {
                name = "Rogue";
            }
            else if (c == 4)
            {
                name = "Paladin";
            }
            else if (c == 5)
            {
                name = "Hunter";
            }
            else if (c == 6)
            {
                name = "Druid";
            }
            else if (c == 7)
            {
                name = "Warlock";
            }
            else if (c == 8)
            {
                name = "Mage";
            }
            else if (c == 9)
            {
                name = "Priest";
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
            Console.WriteLine("\n" + pname + " recibio " + dmg + " de daño.");
            if (Armor > 0)
            {
                Armor = Armor - dmg;
                if (Armor < 0)
                {
                    CurrentHealth = CurrentHealth + Armor;
                    Armor = 0;
                    Console.WriteLine("\nA " + name + " " + pname + " le queda " + CurrentHealth + " de vida.");
                }
                else if (Armor > 0)
                {
                    Console.WriteLine("\nA " + name + " " + pname + " le queda " + CurrentHealth + " de vida y " + Armor + " de armadura.");
                }
            }
            else
            {
                CurrentHealth = CurrentHealth - dmg;
                Console.WriteLine("\nA " + name + " " + pname + " le queda " + CurrentHealth + " de vida.");
            }

        }

        public void HeroPower(Player Enemy)
        {
            if (this.PowerRest == true)
            {
                if (this.CurrentMana > 2)
                {
                    if (Class == 1)
                    {
                        Armor = Armor + 2;

                    }
                    else if (Class == 2) // Shaman //
                    {
                        Minions Tottem = new Minions("Tottem", 0, 0, 0, 2, 0, 0);
                        MyField.CardsInField.Add(Tottem);
                    }
                    else if (Class == 3) // Picaro //
                    {


                    }
                    else if (Class == 4) // Paladin //
                    {
                        Minions SilverHandRecruit = new Minions("Silver Hand Recruit", 0, 0, 0, 1, 1, 0);
                        MyField.CardsInField.Add(SilverHandRecruit);
                    }

                    else if (Class == 5) // Hunter //
                    {
                        Enemy.ReceiveDamage(2);
                    }
                    else if (Class == 6) // Druida //
                    {
                        AttackRest = true;
                        CurrentAttack = CurrentAttack + 1;
                        Armor = Armor + 1;
                    }
                    else if (Class == 7) // Warlock //
                    {
                        CurrentHealth -= 2;
                        DrawFromDeck();
                    }
                    else if (Class == 8) // Wizard //
                    {

                    }
                    else if (Class == 9) // Priest //
                    {
                        CurrentHealth += 2;
                    }
                    CurrentMana = CurrentMana - 2;
                    PowerRest = false;
                }
                else {
                    //No tienes mana//
                }
            }
            //ya se uso este turno //
        }

        public void DrawFromDeck()
        {
            if (MyDeck.Count() > 0)
            {
                var carta = MyDeck.First();
                if (carta != null)
                {
                    
                    if (CardsInHand < 10)
                    {
                        MyHand.Add(carta);
                        CardsInHand += 1;
                    }
                    else { //Carta quemada//
                    }
                }
                MyDeck.RemoveAt(0);
            }
            else
            {
                //Fatiga//
                fatigue += 1;
                this.ReceiveDamage(fatigue);
            }


        }
        public Boolean CardPlayable(int slct)
        {
            if (slct < CardsInHand)
            {
                Cards card = this.MyHand[slct];
                if (card is Minions)
                {
                    Minions pcard = card as Minions;
                    if (pcard.GetCost() > CurrentMana)
                    {
                        return false;
                    }
                    else
                    {
                        int cm = MyField.GetCurrentMinions();
                        if (cm < 7)
                        {
                            return true;
                        }
                        else { return false; }
                    }
                }
                else if (card is Spells)
                {
                    return true;
                }
                else { return false; }

            }
            else { return false; }
        }

        public Cards PlayCard(int select)
        {
                Cards card = this.MyHand[select];
                if (card is Minions)
                {
                            Minions pcard = card as Minions;
                            MyField.AddCurrentMinions(pcard);
                            CurrentMana -= card.GetCost();
                            MyHand.RemoveAt(select);
                            CardsInHand -= 1;
                        }
                else if (card is Spells)
                {
                    Spells pcard = card as Spells;
                    pcard.Effect(this);
                    MyHand.RemoveAt(select);
                }
                return card;
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


                else
                {
                    Console.WriteLine("\nComando no valido. \nIngrese de nuevo");
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
