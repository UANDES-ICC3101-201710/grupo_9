using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hearthstone
{
    class Game
    {


        public List<Cards> CreateDeck()
        {
            Minions Wisp = new Minions("Wisp", 0, 0, 0, 1, 1, 0); Minions Wisp2 = new Minions("Wisp", 0, 0, 0, 1, 1, 0); Minions Wisp3 = new Minions("Wisp", 0, 0, 0, 1, 1, 0);
            Minions BOgre = new Minions("Boulderfist Ogre", 6, 0, 0, 7, 6, 0); Minions BOgre2 = new Minions("Boulderfist Ogre", 6, 0, 0, 7, 6, 0); Minions BOgre3 = new Minions("Boulderfist Ogre", 6, 0, 0, 7, 6, 0);
            Minions WGolem = new Minions("War Golem", 7, 0, 0, 7, 7, 0); Minions WGolem2 = new Minions("War Golem", 7, 0, 0, 7, 7, 0); Minions WGolem3 = new Minions("War Golem", 7, 0, 0, 7, 7, 0);
            Minions CHound = new Minions("Core Hound", 7, 0, 0, 5, 9, 0); Minions CHound2 = new Minions("Core Hound", 7, 0, 0, 5, 9, 0); Minions CHound3 = new Minions("Core Hound", 7, 0, 0, 5, 9, 0);
            Minions magma_rager = new Minions("Magma Rager", 3, 0, 0, 1, 5, 0); Minions magma_rager2 = new Minions("Magma Rager", 3, 0, 0, 1, 5, 0); Minions magma_rager3 = new Minions("Magma Rager", 3, 0, 0, 1, 5, 0);
            Minions chidwind_yeti = new Minions("Childwind Yeti", 4, 0, 0, 5, 4, 0); Minions chidwind_yeti2 = new Minions("Childwind Yeti", 4, 0, 0, 5, 4, 0); Minions chidwind_yeti3 = new Minions("Childwind Yeti", 4, 0, 0, 5, 4, 0);
            Minions oasis_snapjaw = new Minions("Oasis Snapjaw", 4, 0, 0, 7, 2, 0); Minions oasis_snapjaw2 = new Minions("Oasis Snapjaw", 4, 0, 0, 7, 2, 0); Minions oasis_snapjaw3 = new Minions("Oasis Snapjaw", 4, 0, 0, 7, 2, 0);
            Minions MurlocRaider = new Minions("Murloc Raider", 1, 0, 0, 1, 2, 1); Minions MurlocRaider2 = new Minions("Murloc Raider", 1, 0, 0, 1, 2, 1); Minions MurlocRaider3 = new Minions("Murloc Raider", 1, 0, 0, 1, 2, 1);
            Minions BloodfenRaptor = new Minions("Bloodfen Raptor", 2, 0, 0, 2, 3, 3); Minions BloodfenRaptor2 = new Minions("Bloodfen Raptor", 2, 0, 0, 2, 3, 3); Minions BloodfenRaptor3 = new Minions("Bloodfen Raptor", 2, 0, 0, 2, 3, 3);
            Minions RiverCrocolisk = new Minions("River Crocolisk", 2, 0, 0, 3, 2, 3); Minions RiverCrocolisk2 = new Minions("River Crocolisk", 2, 0, 0, 3, 2, 3); Minions RiverCrocolisk3 = new Minions("River Crocolisk", 2, 0, 0, 3, 2, 3);

            List<Cards> FirstList = new List<Cards>();

            FirstList.Add(Wisp); FirstList.Add(Wisp2); FirstList.Add(Wisp3);
            FirstList.Add(BOgre); FirstList.Add(BOgre2); FirstList.Add(BOgre3);
            FirstList.Add(CHound); FirstList.Add(CHound2); FirstList.Add(CHound3);
            FirstList.Add(RiverCrocolisk); FirstList.Add(RiverCrocolisk2); FirstList.Add(RiverCrocolisk3);
            FirstList.Add(oasis_snapjaw); FirstList.Add(oasis_snapjaw2); FirstList.Add(oasis_snapjaw3);
            FirstList.Add(chidwind_yeti); FirstList.Add(chidwind_yeti2); FirstList.Add(chidwind_yeti3);
            FirstList.Add(WGolem); FirstList.Add(WGolem2); FirstList.Add(WGolem3);
            FirstList.Add(magma_rager); FirstList.Add(magma_rager2); FirstList.Add(magma_rager3);
            FirstList.Add(MurlocRaider); FirstList.Add(MurlocRaider2); FirstList.Add(MurlocRaider3);
            FirstList.Add(BloodfenRaptor); FirstList.Add(BloodfenRaptor2); FirstList.Add(BloodfenRaptor3);

            return FirstList;
        }

        public List<Cards> ShuffleList<Cards>(List<Cards> CardsInDeck)
        {
            List<Cards> shuffledList = new List<Cards>();

            Random r = new Random();
            int randomIndex = 0;
            while (CardsInDeck.Count > 0)
            {
                randomIndex = r.Next(0, CardsInDeck.Count);
                shuffledList.Add(CardsInDeck[randomIndex]);
                CardsInDeck.RemoveAt(randomIndex);
            }

            return shuffledList;
        }

        public void SelectTurns(Player p1, Player p2)
        {
            Console.WriteLine("\nAhora se procedera a elegir los turnos.");
            Spells ManaCard = new Spells("Mana Coin", 0, 0, 0);
            Random r = new Random();
            int n = r.Next(1, 3);
            p1.PlayerNumber = n;
            if (n == 1)
            {
                Console.WriteLine("\n" + p1.pname + " es el primero en comenzar.\n" + p2.pname + " sera el segundo y recibira la Moneda de Mana.");
                p2.PlayerNumber = 2;
                p2.MyHand.Add(ManaCard);
                p2.CardsInHand++;
                Console.WriteLine("\nAhora " + p1.pname + " elegira su mano inicial.");
                p1.FirstTurn();
                Console.WriteLine("\nAhora " + p2.pname + " elegira su mano inicial.");
                p2.FirstTurn();
                p1.CurrentTurn = true;
            }
            else
            {
                Console.WriteLine("\n" + p2.pname + " es el primero en comenzar.\n" + p1.pname + " sera el segundo y recibira la Moneda de Mana.");
                p2.PlayerNumber = 1;
                p1.MyHand.Add(ManaCard);
                p1.CardsInHand++;
                Console.WriteLine("\nAhora " + p2.pname + " elegira su mano inicial.");
                p2.FirstTurn();
                Console.WriteLine("\nAhora " + p1.pname + " elegira su mano inicial.");
                p1.FirstTurn();
                p2.CurrentTurn = true;
            }
        }

        public void Turn(Player p1, Player p2)
        {

            SelectTurns(p1, p2);
            Console.WriteLine("\nEl juego empezara ahora.\n\n   Que Gane el Mejor!");

            Boolean chuk = true;
            while (chuk)
            {
                if (p1.CurrentTurn)
                {
                    Console.WriteLine("\n " + p1.name + " " + p1.pname + " es tu turno.");
                    Console.WriteLine("\nTe queda " + p1.CurrentHealth + " de vida y tiene " + p1.CurrentMana + " de mana para utilizar y " + p1.Armor + " de Armadura. Te quedan " + p1.MyDeck.Count() + " cartas en el mazo.");
                    p1.DrawFromDeck();
                }
                if (p1.CurrentHealth <= 0)
                {
                    chuk = false;
                    break;
                }
                while (p1.CurrentTurn)
                {

                    Console.WriteLine("\nElija su opción: \n1.- Jugar Una Carta \n2.- Atacar\n3.- Hero Power\n4.- Vida actual y Mana Disponible\n5.- Terminar tu Turno");


                    int slction = 100;
                    try
                    {
                        slction = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("\nOpción invalida");
                    }

                    if (slction == 1)
                    {
                        p1.PlayCard();
                    }
                    else if (slction == 2)
                    {
                        if (p1.MyField.CardsInField.Count > 0)
                        {
                            Console.WriteLine("\nElija la carta con la que quiere atacar");
                            var asdf = 1;
                            foreach (var n in p1.MyField.CardsInField)
                            {
                                Console.WriteLine(asdf + ".- " + n.GetName() + " tiene " + n.Attack + " de ataque y le queda " + n.CurrentLife + " de vida.");
                                asdf++;
                            }
                            int attacker = 100;
                            try
                            {
                                attacker = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("\n Comando Invalido.");
                            }
                            if (attacker <= p1.MyField.CardsInField.Count)
                            {
                                Console.WriteLine("\nElija su objetivo \n0.- " + p2.pname);
                                if (p2.MyField.CardsInField.Count > 0)
                                {
                                    int asdf2 = 1;
                                    foreach (var n in p2.MyField.CardsInField)
                                    {
                                        Console.WriteLine(asdf2 + ".- " + n.GetName() + " tiene " + n.Attack + " de ataque y le queda " + n.CurrentLife + " de vida.");
                                        asdf2++;
                                    }
                                }
                                int attacked = 100;
                                try
                                {
                                    attacked = Convert.ToInt32(Console.ReadLine());
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("\nOpción invalida");
                                }
                                if (attacked == 0)
                                {
                                    p1.MyField.CardsInField[attacker - 1].PAttack(p2);
                                }
                                else if (attacked <= p2.MyField.CardsInField.Count)
                                {
                                    p1.MyField.CardsInField[attacker - 1].MAttack(p2.MyField.CardsInField[attacked - 1]);
                                }
                                else { Console.WriteLine("\nOpción invalida"); }

                            }
                            else { Console.WriteLine("\nOpción invalida"); }


                        }
                        else { Console.WriteLine("No tiene cartas en el campo."); }
                        p1.MyField.CheckMinionsLife();
                        p2.MyField.CheckMinionsLife();
                        if (p1.CurrentHealth <= 0)
                        {
                            chuk = false;
                            break;
                        }
                        if (p2.CurrentHealth <= 0)
                        {
                            chuk = false;
                            break;
                        }

                    }
                    else if (slction == 3)
                    {
                        p1.HeroPower(p2);
                        if (p2.CurrentHealth <= 0)
                        {
                            chuk = false;
                            break;
                        }
                    }
                    else if (slction == 4)
                    {
                        Console.WriteLine("\nTe queda " + p1.CurrentHealth + " de vida y tiene " + p1.CurrentMana + " de mana para utilizar y " + p1.Armor + " de Armadura. Te quedan " + p1.MyDeck.Count() + " cartas en el mazo.");
                    }
                    else if (slction == 5)
                    {
                        p1.EndTurn(p2);
                    }
                    else
                    {
                        Console.WriteLine("\nOpción invalida");
                    }

                }
                if (p2.CurrentHealth <= 0)
                {
                    chuk = false;
                    break;
                }
                while (p2.CurrentTurn)
                {

                    Console.WriteLine("\n " + p2.name + " " + p2.pname + " es tu turno.");
                    Console.WriteLine("\nTe queda " + p2.CurrentHealth + " de vida y tiene " + p2.CurrentMana + " de mana para utilizar y " + p2.Armor + " de Armadura. Te quedan " + p2.MyDeck.Count() + " cartas en el mazo.");
                    p2.DrawFromDeck();
                    if (p2.CurrentHealth <= 0)
                    {
                        chuk = false;
                        break;
                    }
                    while (p2.CurrentTurn)
                    {

                        Console.WriteLine("\nElija su opción: \n1.- Jugar Una Carta \n2.- Atacar \n3.- Hero Power\n4.- Vida actual y Mana Disponible\n5.- Terminar tu Turno");

                        int slction2 = 100;
                        try
                        {
                            slction2 = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("\nOpción invalida");
                        }

                        if (slction2 == 1)
                        {
                            p2.PlayCard();
                        }
                        else if (slction2 == 2)
                        {
                            if (p2.MyField.CardsInField.Count > 0)
                            {
                                Console.WriteLine("\nElija la carta con la que quiere atacar");
                                var asdf3 = 1;
                                foreach (var n in p2.MyField.CardsInField)
                                {
                                    Console.WriteLine(asdf3 + ".- " + n.GetName() + " tiene " + n.Attack + " de ataque y le queda " + n.CurrentLife + " de vida.");
                                    asdf3++;
                                }
                                int attacker = 100;
                                try
                                {
                                    attacker = Convert.ToInt32(Console.ReadLine());
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("\nOpción invalida");
                                }
                                if (attacker <= p2.MyField.CardsInField.Count)
                                {
                                    Console.WriteLine("\nElija su objetivo \n0.- " + p1.pname);
                                    if (p1.MyField.CardsInField.Count > 0)
                                    {
                                        int asdf4 = 1;
                                        foreach (var n in p1.MyField.CardsInField)
                                        {
                                            Console.WriteLine(asdf4 + ".- " + n.GetName() + " tiene " + n.Attack + " de ataque y le queda " + n.CurrentLife + " de vida.");
                                            asdf4++;
                                        }
                                    }
                                    int attacked = 100;
                                    try
                                    {
                                        attacked = Convert.ToInt32(Console.ReadLine());
                                    }
                                    catch (Exception)
                                    {
                                        Console.WriteLine("\nOpción invalida");
                                    }
                                    if (attacked == 0)
                                    {
                                        p2.MyField.CardsInField[attacker - 1].PAttack(p1);
                                    }
                                    else if (attacked <= p2.MyField.CardsInField.Count)
                                    {
                                        p2.MyField.CardsInField[attacker - 1].MAttack(p1.MyField.CardsInField[attacked - 1]);
                                    }
                                    else { Console.WriteLine("\nOpción invalida"); }

                                }
                                else { Console.WriteLine("\nOpción invalida"); }


                            }
                            else { Console.WriteLine("No tiene cartas en el campo."); }
                            p1.MyField.CheckMinionsLife();
                            p2.MyField.CheckMinionsLife();
                            if (p1.CurrentHealth <= 0)
                            {
                                chuk = false;
                                break;
                            }
                            if (p2.CurrentHealth <= 0)
                            {
                                chuk = false;
                                break;
                            }
                        }
                        else if (slction2 == 3)
                        {
                            p2.HeroPower(p1);
                            if (p1.CurrentHealth <= 0)
                            {
                                chuk = false;
                                break;
                            }
                        }
                        else if (slction2 == 4)
                        {
                            Console.WriteLine("Te queda " + p2.CurrentHealth + " de vida y tiene " + p2.CurrentMana + " de mana para utilizar y " + p2.Armor + " de Armadura. Te quedan " + p2.MyDeck.Count() + " cartas en el mazo.");
                        }
                        else if (slction2 == 5)
                        {
                            p2.EndTurn(p1);
                        }
                        else
                        {
                            Console.WriteLine("\nOpción invalida");
                        }

                    }

                }
                if (p1.CurrentHealth <= 0)
                {
                    Console.WriteLine("\n  " + p1.name + " " + p1.pname + " fue herido de muerte! Gana " + p2.name + " " + p2.pname + "!");
                }
                else if (p2.CurrentHealth <= 0)
                {
                    Console.WriteLine("\n  " + p2.name + " " + p2.pname + " fue herido de muerte! Gana " + p1.name + " " + p1.pname + "!");
                }
            }
        }
    }
}

    


        
    

