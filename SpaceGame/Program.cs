using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

https://github.com/marcectima/SpaceGame.git

        // Action menu
        private static void ShowActionMenu(ref string[] user, ref string[] ship)
        {
            bool keepLooping = true;
            do
            {
                try
                {
                    Console.Write("Select from the following options:\n" +
                                        "1. Status\n" +
                                        "2. Trade\n" +
                                        "3. Travel to...\n" +
                                        "4. Change ship\n" +
                                        "5. Quit game\n" +
                                        "\n>>> ");
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
                            Console.WriteLine("You chose to end the game.");
                            ShowStatus(user);
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
                    Console.WriteLine("\nPress Enter to Continue");
                    Console.ReadLine();
                    Console.Clear();
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
                do
                {
                    switch (user[4])
                    {
                        case "Earth":
                            from = Earth;
                            Console.WriteLine("Where would you like to travel to? \n" +
                            $"1. {destinations[1]}\n" +
                            $"2. {destinations[2]}");
                            string selection1 = Console.ReadLine().Trim();
                            if (selection1 == "1") { whereTo = destinations[1]; }
                            else if (selection1 == "2") { whereTo = destinations[2]; }
                            break;
                        case "Alpha Centauri":
                            from = AlphaCentauri;
                            Console.WriteLine("Where would you like to travel to? \n" +
                            $"1. {destinations[0]}\n" +
                            $"2. {destinations[2]}");
                            string selection2 = Console.ReadLine().Trim();
                            if (selection2 == "1") { whereTo = destinations[0]; }
                            else if (selection2 == "2") { whereTo = destinations[2]; }
                            break;
                        case "Prextie":
                            from = Prextie;
                            Console.WriteLine("Where would you like to travel to? \n" +
                            $"1. {destinations[0]}\n" +
                            $"2. {destinations[1]}");
                            string selection3 = Console.ReadLine().Trim();
                            if (selection3 == "1") { whereTo = destinations[0]; }
                            else if (selection3 == "2") { whereTo = destinations[1]; }
                            break;
                    }
                } while (whereTo == "");
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

        // 
        private static void Trade()
        {
            Console.WriteLine("Markets are closed due to the recent trade wars. Thanks Mr. President!");
        }

        // Displays information about user and currentShip
        private static void ShowStatus(string[] user)
        {
            Console.WriteLine($"wallet: {user[2]}");
            Console.WriteLine($"travel time: {user[3]}");
            Console.WriteLine($"location: {user[4]}");
        }

        // Purchasing a ship. [0] - type, [1] - speed, [2] - capacity, [3] - price.
        private static string[] NewShip(ref string[] user)
        {
            string[] currentShip = new string[4];
            try
            {
                Console.Write("Select the type of ship you want to purchase: \n" +
                    "1. Shuttlecraft\n" +
                    "2. Freighter\n" +
                    "3. Cruis Freighter\n" +
                    "4. Starship\n" +
                    "\n>>> ");
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

        // Creates a user. [0] - name, [1] - gender, [2] - wallet, [3] - travel time, [4] - location
        private static string[] CreateUser()
        {
            string[] user = new string[5];
            try
            {
                Console.Write("\n>>> Type your name: ");
                user[0] = Console.ReadLine();
                Console.Write("\nSelect your gender\n" +
                    "1. Male\n" +
                    "2. Female\n" +
                    "\n>>> ");
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

        // Displays the endgame stats.
        private static void EndGameReport()
        {
            throw new NotImplementedException();
        }
    }
}
