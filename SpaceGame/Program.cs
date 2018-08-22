using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n>>> Welcome to Space Trader");

            // Creates a new user.
            string[] user = CreateUser();

            Console.WriteLine($"\n>>> Hello {user[0]}. Your character has been created and awarded with 15,000 credits to start the game.");
            //Console.WriteLine(user[0] + " are a billionaire astronaut/scientist. " + user[0] + " saw something \n " +
            //    "from out of space with his  telescope that looked very interesting. Dave went on a long journey in \n" +
            //    "space to discover whatever that was that interest him. He discovered that the planet had a whole life \n" +
            //    "form. He realizes the creatures that where there can communicate with him. Dave saw a valuable item. \n" +
            //    "Dave ask the creatures about the item. And, the creatures told Dave they got it from a planet call Prextie. \n" +
            //    "Dave convince the creatures to take him to the planet. Dave couldn’t believe his eyes. Dave went back to \n" +
            //    "their planet.  They’ve told the creatures he would return.  A month pass after Dave told his fellow \n" +
            //    "earthling that he would be gone for a while. Dave return to the planet and ask the creatures to show him \n" +
            //    "more. Dave return to Prextie and was able to make a space life for himself. He learned a lot of space life.");
            //Console.WriteLine("");

            // Purchase the first ship.
            string[] ship = NewShip(ref user);

            // Opens action menu.
            ShowActionMenu(ref user, ref ship);
            Environment.Exit(-1);
        }

        // Action menu
        private static void ShowActionMenu(ref string[] user, ref string[] ship)
        {
            bool keepLooping = true;
            do
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("\n>>> Select from the following options:");
                    Console.WriteLine("Status       : 1");
                    Console.WriteLine("Trade        : 2");
                    Console.WriteLine("Travel to... : 3");
                    Console.WriteLine("Change ship  : 4");
                    Console.WriteLine("Quit game    : 5");
                    int selection = int.Parse(Console.ReadLine());
                    switch (selection)
                    {
                        case 1:
                            ShowStatus(user);
                            break;
                        case 2:
                            Trade();
                            break;
                        case 3:
                            ChangeLocation(ref user, ship);
                            break;
                        case 4:
                            NewShip(ref user);
                            break;
                        case 5:
                            keepLooping = false;
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Invalid entry.");
                }
                finally
                {
                    Console.WriteLine("\n>>> Press Enter to Continue.");
                    Console.ReadLine();
                }
            } while (keepLooping);
        }

        // Updates user location and travel time.
        private static void ChangeLocation(ref string[] user, string[] ship)
        {
            string[] destinations = { "Earth", "Alpha Centauri", "Prextie" };
            double[] Earth = { 0, 0 };
            double[] AlphaCentauri = { 0, -4.367 };
            double[] Prextie = { -4.6, 5.0 };
            double[] from = new double[2];
            double[] to = new double[2];
            string whereTo = "";
            double distance = 0;
            double travelTime = 0;
            double W = int.Parse(ship[1].Trim());
            try
            {
                switch (user[4])
                {
                    case "Earth":
                        from = Earth;
                        Console.WriteLine("Where would you like to travel to? \n" +
                        $"{destinations[1]} : 1\n" +
                        $"{destinations[2]} : 2");
                        if (Console.ReadLine().Trim() == "1") { whereTo = destinations[1]; }
                        else if (Console.ReadLine() == "2") { whereTo = destinations[2]; }
                        break;
                    case "Alpha Centauri":
                        from = AlphaCentauri;
                        Console.WriteLine("Where would you like to travel to? \n" +
                        $"{destinations[0]} : 1\n" +
                        $"{destinations[2]} : 2");
                        if (Console.ReadLine().Trim() == "1") { whereTo = destinations[0]; }
                        else if (Console.ReadLine() == "2") { whereTo = destinations[2]; }
                        break;
                    case "Prextie":
                        from = Prextie;
                        Console.WriteLine("Where would you like to travel to? \n" +
                        $"{destinations[0]} : 1\n" +
                        $"{destinations[1]} : 2");
                        if (Console.ReadLine().Trim() == "1") { whereTo = destinations[0]; }
                        else if (Console.ReadLine() == "2") { whereTo = destinations[1]; }
                        break;
                }
                switch (whereTo)
                {
                    case "Earth":
                        to = Earth;
                        break;
                    case "Alpha Centauri":
                        to = AlphaCentauri;
                        break;
                    case "Prextie":
                        to = Prextie;
                        break;
                }
                // Calculates the distance between two destinations
                distance = Math.Sqrt(Math.Pow((from[0] - to[0]), 2) + Math.Pow((from[1] - to[1]), 2));

                // Calculates the elapsed time in years.
                travelTime = distance / (Math.Pow(W, 10 / 3) + Math.Pow(10 - W, -11 / 3));

                // Updates the user's travel time.
                user[3] = Convert.ToString(double.Parse(user[3].Trim()) + travelTime);
                // Checks to total time elapsed.
                if (double.Parse(user[3]) == 40 * 52560)
                {
                    EndGameReport();
                    Environment.Exit(-1);
                }

                // Updates the user's location.
                user[4] = whereTo;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid entry.");
            }
        }

        private static void Trade()
        {
            throw new NotImplementedException();
        }

        // Displays information about user and currentShip
        private static void ShowStatus(string[] user)
        {
            Console.WriteLine($"wallet: {user[2]}");
            Console.WriteLine($"travel time: {user[3]}");
            Console.WriteLine($"location: {user[4]}");
        }

        // Purchasing a ship
        // [0] - type, [1] - speed, [2] - capacity, [3] - price.
        private static string[] NewShip(ref string[] user)
        {
            string[] currentShip = new string[4];
            try
            {
                Console.WriteLine("\n>>> Select the type of ship you want to purchase: \n" +
                    "Shuttlecraft   : 1 \n" +
                    "Freighter      : 2 \n" +
                    "Cruis Freighter: 3 \n" +
                    "Starship       : 4");
                int selectedShip = int.Parse(Console.ReadLine().Trim());
                switch (selectedShip)
                {
                    case 1:
                        currentShip[0] = "Shuttlecraft";
                        currentShip[1] = "3";
                        currentShip[2] = "10";
                        currentShip[3] = "10000";
                        break;
                    case 2:
                        currentShip[0] = "Freighter";
                        currentShip[1] = "5";
                        currentShip[2] = "25";
                        currentShip[3] = "25000";
                        break;
                    case 3:
                        currentShip[0] = "Cruis Freighter";
                        currentShip[1] = "8";
                        currentShip[2] = "35";
                        currentShip[3] = "50000";
                        break;
                    case 4:
                        currentShip[0] = "Starship";
                        currentShip[1] = "9.9";
                        currentShip[2] = "50";
                        currentShip[3] = "100000";
                        break;
                }
                // Updates user's wallet.
                user[2] = Convert.ToString(int.Parse(user[2]) - int.Parse(currentShip[3]));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid entry.");

            }
            return currentShip;
        }

        // Creates a user
        // [0] - name, [1] - gender, [2] - wallet, [3] - travel time, [4] - location
        private static string[] CreateUser()
        {
            string[] user = new string[5];
            try
            {
                Console.WriteLine("\n>>> Type your name:");
                user[0] = Console.ReadLine().Trim();
                Console.WriteLine("\n>>> Select gender: \n Male  : 1 \n Female: 2");
                int gender = int.Parse(Console.ReadLine().Trim());
                switch (gender)
                {
                    case 1:
                        user[1] = "Male";
                        break;
                    case 2:
                        user[1] = "Female";
                        break;
                }
                user[2] = "15000";
                user[3] = "0";
                user[4] = "Earth";
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid entry.");
            }
            return user;
        }

        private static void EndGameReport()
        {
            throw new NotImplementedException();
        }
    }
}