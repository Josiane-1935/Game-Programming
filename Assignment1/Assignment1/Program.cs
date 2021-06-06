using System;
using System.Collections.Generic;

namespace Assignment1
{
    enum Colors { Blue, Green, Yellow, White, Red};
    enum Nationalities { Norvegian, Dane, Swede, German, Brit};
    enum Cigarettes { Dunhill, Pall_Mall, Prince, Blue_Master, Blends };
    enum Pets {  cats, dogs, horses, birds, fish};
    enum Drinks { water, tea, coffee, milk, beer }
    class Program
    {
        static void Main(string[] args)
        {
            DateTime begin = DateTime.Now;
            string position = "12345"; // there are five houses
            string[] combinations = Combinations(position);
            int solutions = 0;
                
            for (int nationality = 0; nationality < combinations.Length; nationality++ )
            {
                if (Check_Rules(9, combinations[nationality]) == true)
                {


                    for (int color = 0; color < combinations.Length; color++)
                    {
                        if ((Check_Rules(1, combinations[nationality], combinations[color]) == true) &&
                            (Check_Rules(4, combinations[nationality], combinations[color]) == true) &&
                            (Check_Rules(14, combinations[nationality], combinations[color]) == true))
                        {


                            for (int drink = 0; drink < combinations.Length; drink++)
                            {
                                if ((Check_Rules(5, combinations[nationality], combinations[color], combinations[drink]) == true) &&
                                    (Check_Rules(3, combinations[nationality], combinations[color], combinations[drink]) == true) &&
                                    (Check_Rules(8, combinations[nationality], combinations[color], combinations[drink]) == true))
                                {

                                    for (int cigarette = 0; cigarette < combinations.Length; cigarette++)
                                    {
                                        if ((Check_Rules(7, combinations[nationality], combinations[color], combinations[drink], combinations[cigarette]) == true) &&
                                            (Check_Rules(12, combinations[nationality], combinations[color], combinations[drink], combinations[cigarette]) == true) &&
                                            (Check_Rules(13, combinations[nationality], combinations[color], combinations[drink], combinations[cigarette]) == true) &&
                                            (Check_Rules(15, combinations[nationality], combinations[color], combinations[drink], combinations[cigarette]) == true))
                                        {


                                            for (int pet = 0; pet < combinations.Length; pet++)
                                            {
                                                if ((Check_Rules(2, combinations[nationality], combinations[color], combinations[drink], combinations[cigarette], combinations[pet]) == true) &&
                                                    (Check_Rules(6, combinations[nationality], combinations[color], combinations[drink], combinations[cigarette], combinations[pet]) == true) &&
                                                    (Check_Rules(10, combinations[nationality], combinations[color], combinations[drink], combinations[cigarette], combinations[pet]) == true) &&
                                                    (Check_Rules(11, combinations[nationality], combinations[color], combinations[drink], combinations[cigarette], combinations[pet]) == true))
                                                {
                                                    solutions = solutions + 1;
                                                    Display_Results(solutions, combinations[nationality], combinations[color], combinations[drink], combinations[cigarette], combinations[pet]);
                                                }


                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            DateTime end = DateTime.Now;
            double diff = (end - begin).TotalMilliseconds;
            Console.WriteLine("Solved in " + diff.ToString() + " milliseconds");
            Console.ReadKey();
        }
        public static bool Check_Rules(int number, string nationality, string drink ="", string cigarette ="", string color = "", string pet = "")
        {
            switch (number)
            {
                case 1: // The Brit lives in the red house
                    if (nationality.Substring(color.IndexOf(((int)Colors.Red).ToString()), 1) == ((int)Nationalities.Brit).ToString())
                    {
                        return true;
                    }
                        break;
                case 2: //The Swede keeps the dogs as pets
                    if (nationality.Substring(pet.IndexOf(((int)Pets.dogs).ToString()), 1) == ((int)Nationalities.Swede).ToString())
                    {
                        return true;
                    }
                    break;
                case 3: //The Dane drinks tea
                    if (drink.Substring(nationality.IndexOf(((int)Nationalities.Dane).ToString()), 1) == ((int)Drinks.tea).ToString())
                    {
                        return true;
                    }
                    break;
                case 4: //The Green house is exactly to the left of the white house
                    if (color.IndexOf(((int)Colors.Green).ToString()) - color.IndexOf(((int)Colors.White).ToString()) == 1)
                    {
                        return true;
                    }
                    break;
                case 5: //The owner of the green house drinks coffee
                    if (drink.Substring(color.IndexOf(((int)Colors.Green).ToString()), 1) == ((int)Drinks.coffee).ToString())
                    {
                        return true;
                    }
                    break;
                case 6: //The person who smokes Pall Mall rears Birds
                    if (cigarette.Substring(pet.IndexOf(((int)Pets.birds).ToString()), 1) == ((int)Cigarettes.Pall_Mall).ToString())
                    {
                        return true;
                    }
                    break;
                case 7: //The owner of the yellow house smokes Dunhill
                    if (cigarette.Substring(color.IndexOf(((int)Colors.Yellow).ToString()), 1) == ((int)Cigarettes.Dunhill).ToString())
                    {
                        return true;
                    }
                    break;
                case 8: //The man living in the centre house drinks Milk
                    if (drink.Substring(2, 1) == ((int)Drinks.milk).ToString())
                    {
                        return true;
                    }
                    break;
                case 9: //The Norvegian lives in the first house
                    if (nationality.Substring(0, 1) == ((int)Nationalities.Norvegian).ToString())
                    {
                        return true;
                    }
                    break;
                case 10: //The man who smokes Blends lives next to the one who keeps cats
                    if (Math.Abs(cigarette.IndexOf(((int)Cigarettes.Blends).ToString()) - pet.IndexOf(((int)Pets.cats).ToString())) == 1)
                    {
                        return true;
                    }
                    break;
                case 11: // The man who keeps Horses lives next to the man who smokes Dunhill
                    if (Math.Abs(pet.IndexOf(((int)Pets.horses).ToString()) - cigarette.IndexOf(((int)Cigarettes.Dunhill).ToString())) == 1)
                    {
                        return true;
                    }
                    break;
                case 12: //The man who smokes Blue Master drinks beer
                    if (cigarette.Substring(pet.IndexOf(((int)Drinks.beer).ToString()), 1) == ((int)Cigarettes.Blue_Master).ToString())
                    {
                        return true;
                    }
                    break;
                case 13: //The German smokes Prince
                    if (cigarette.Substring(nationality.IndexOf(((int)Nationalities.German).ToString()), 1) == ((int)Cigarettes.Prince).ToString())
                    {
                        return true;
                    }
                    break;
                case 14: //The Norvegian lives next to the Blue House
                    if (Math.Abs(color.IndexOf(((int)Colors.Blue).ToString()) - nationality.IndexOf(((int)Nationalities.Norvegian).ToString())) == 1)
                    {
                        return true;
                    }
                    break;
                case 15: //The man who smokes Blends has a neighbour who drinks water
                    if (Math.Abs(cigarette.IndexOf(((int)Cigarettes.Blends).ToString()) - drink.IndexOf(((int)Drinks.water).ToString())) == 1)
                    {
                        return true;
                    }
                    break;
                default:
                    break;
            }
            return false;
        }
        public static void Display_Results(int solution, string nationalities, string colors, string drinks, string cigarettes, string pets)
        {
            Console.WriteLine("Results " + solution.ToString());
            Console.WriteLine();
            Console.Write(string.Format("{0,-1} | ", "p"));
            Console.Write(string.Format("{0,-6} | ", "Color"));
            Console.Write(string.Format("{0,-11} | ", "Nationality"));
            Console.Write(string.Format("{0,-12} | ", "Drink"));
            Console.Write(string.Format("{0,-12} | ", "Cigarette"));
            Console.Write(string.Format("{0,-6} | ", "pet"));
            Console.WriteLine();
            for(int c = 0; c < colors.Length; c++)
            {
                Console.Write(string.Format("{0,-1} | ", (c + 1)));
                Console.Write(string.Format("{0,-6} | ", ((Colors)Convert.ToInt32(colors.Substring(c, 1))).ToString()));
                Console.Write(string.Format("{0,-11} | ", ((Nationalities)Convert.ToInt32(nationalities.Substring(c, 1))).ToString()));
                Console.Write(string.Format("{0,-12} | ", ((Drinks)Convert.ToInt32(drinks.Substring(c, 1))).ToString()));
                Console.Write(string.Format("{0,-12} | ", ((Cigarettes)Convert.ToInt32(cigarettes.Substring(c, 1))).ToString()));
                Console.Write(string.Format("{0,-6} | ", ((Pets)Convert.ToInt32(pets.Substring(c, 1))).ToString()));
                Console.WriteLine();

            }
            Console.WriteLine();
        }

        public static string[] Combinations(string position)
        {
            List<string> combinations = new List<string>();
            for (int i = 0; i < position.Length; i++)
            {
                string single = position.Substring(i, 1);
                if (combinations.Count == 0)
                {
                    combinations.Add(single);
                }
                else
                {
                    List<string> newcombinations = new List<string>();
                    for (int current = 0; current < combinations.Count; current++)
                    {
                        for (int pos = 0; pos < combinations[current].Length; pos++)
                        {
                            newcombinations.Add(combinations[current].Substring(0, pos) + single + combinations[current].Substring(pos)) ;

                        }
                        newcombinations.Add(combinations[current] + single);
                            
                    }
                    combinations = newcombinations;
                }

            }
            return combinations.ToArray();
        }
    }
}
