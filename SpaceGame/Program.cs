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
            // Game's Introduction
            Console.ForegroundColor = ConsoleColor.DarkGreen; 
            Console.WriteLine(" \n" +
                "                                                                                                                         \n" +
                "                                  ______________________________________________________________                                                                                        \n" +
                "                                 |  ___________________________________________________________  |                                                                                      \n" +
                "                                 | |                                               __          | |                           \n" +
                "                                 | |           __                            __   |__|         | |                                \n" +
                "                                 | |        __|  |__                        |__|     __        | |                                     \n" +
                "                                 | |       |__    __|       __      __         __   |__|       | |                                       \n" +
                "                                 | |          |__|         /_/     /_/        |__|             | |                                       \n" +
                "                                 | |___________________________________________________________| |                                                                                       \n" +
                "                                 |_______________________________________________________________|                                     \n" +
                "                                                                                                                         \n" +
                "                                                          " + "Elliot Gaming \n" +
                "                                                                                                                         \n");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("\n" +                
                "\n" +
                "\n" +
                "\n" +
                "\n" +
                "\n" +
                "\n" +
                "\n" +
                "\n" +
                "\n" +
                "\n" +
                "\n" +
                "                                                   " + "Gabriel and Marc\n" +
                "\n" +
                "                                                       " + "Presents");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("\n                                                                                                          " +
                "   " +
                "                                                                    /\\                       .           \n" +
                "         .                  .                           /  \\       .                           .         \n" +
                "                                                       /    \\                 .                          \n" +
                "                                                      /______\\                                    .      \n" +
                "                            .                        /        \\                     .                    \n" +
                "                                                    /          \\                                         \n" +
                "             .                                     /            \\            .                           \n" +
                "                                                  |              |                            .           \n" +
                "                                                  |______________|                                        \n" +
                "                                                 /                \\                                      \n" +
                "                            .                   /__________________\\         .                           \n" +
                "               .                               /|                  |\\                                    \n" +
                "                                              / |                  | \\                     .         .   \n" +
                "                                             /  |                  |  \\                                  \n" +
                "                            .               |   |                  |   |                                  \n" +
                "       .                                    |   |                  |   |           .                   .  \n" +
                "                                            |___|__________________|___|                                  \n" +
                "                              .                   |             |                                         \n" +
                "       .                                          |_____________|                           .             \n" +
                "                                                  _ _ _ _ _ _ _ _                                         \n" +
                "                                                 " + "   Space Trader \n" +
                "                                                  _ _ _ _ _ _ _ _ ");
            Console.ReadLine();
            Console.Clear();
            // Game's Story Line. Creates a new user.
            string[] user = CreateUser();
            Console.WriteLine("Choose Your Gender: \n" +
    "1. Male \n" +
    "2. Female \n");
            string[] gen = new string[5];
            int x;
            x = Convert.ToInt32(Console.ReadLine());
            if (x == 1)
            {
                gen[0] = "He";
                gen[1] = "he";
                gen[2] = "his";
                gen[3] = "him";
                gen[4] = "himself";
            }
            else if (x == 2)
            {
                gen[0] = "She";
                gen[1] = "she";
                gen[2] = "her";
                gen[3] = "her";
                gen[4] = "herself";
            }
            else
            {
                Console.WriteLine("Invalid entry");
            }
            Console.Clear();
            Console.WriteLine("\n" +
                "\n" +
                "\n" +
                "\n" +
                "\n" +
                "\n" +
                "\n" +
                "\n" +
                "\n" +
                "\n" +
                "\n" +
                "\n" +
                "                  " + user[0] + " is a billionaire astronaut and scientist who is fasinated by the universe.");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("\n" +
                "\n" +
                "\n" +
                "\n" +
                "\n" +
                "\n" +
                "\n" + 
                "\n" +
                "\n" +
                "\n" +
                "\n" +
                "\n" +
                "\n" +
                "                  " + user[0] + " saw something from out of space with " + gen[2] + " telescope that looked very interesting.");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine(" \n" +
                "\n" +
                "\n" +
                "\n" +
                "\n" +
                "\n" +
                "\n" +
                "\n" +
                "\n" +
                "\n" +
                "\n" +
                "\n" +
                "\n" +
                "                  " + user[0] + " went on a long space journey to search for the which caught " + gen[2] + "\n" +
                "                  " + "interest. " + gen[0] + " saw a planet that had a whole life form in itself. " + gen[0] + " also realized \n" +
                "                  " + "that these creatures communicated well with " + gen[3] + ". " + user[0] + " saw a valuable \n" +
                "                  " + "item. " + gen[0] + " ask the creatures about the item. And, the creatures told " + gen[3] + " they got it \n" +
                "                  " + "from a planet call Prextie. So, "+ user[0] + " convince the creatures to take " + gen[3] + "\n" +
                "                  " + "to Prextie.");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine(" \n" +
                "\n" +
                "\n" +
                "\n" +
                "\n" +
                "\n" +
                "\n" +
                "\n" +
                "\n" +
                "\n" +
                "\n" +
                "\n" +
                "\n" +
                "                  " + user[0] + " couldn’t believe " + gen[2] + " eyes when " + gen[1] + " arrived at Prextie. " + gen[0] + " went back \n" +
                "                  " + "to the creature's planet. And, told the creatures that " + gen[1] + " would return. ");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("\n" +
                "\n" +
                "\n" +
                "\n" +
                "\n" +
                "\n" +
                "\n" +
                "\n" +
                "\n" +
                "\n" +
                "\n" +
                "\n" +
                "\n" +
                "                  " + "A month pass after " + user[0] + " told " + gen[2] + " fellow earthlings that " + gen[1] + " would \n" +
                "                  " + "be gone for a while. " + user[0] + " return to the planet and ask the creatures \n" +
                "                  " + "to show " + gen[3] + " more. " + gen[0] + " returned to Prextie and was able to make a space life for \n" +
                "                  " + gen[4] + ". " + gen[0] + " learned a lot and gained a lot during " + gen[2] + " journey in space.");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine(" \n" +
                "\n" +
                "\n" +
                "\n" +
                "\n" +
                "\n" +
                "\n" +
                "\n" +
                "\n" +
                "\n" +
                "\n" +
                "\n" +
                "                  " + user[0] + " collected and advance in the space life. " + gen[0] + " was able to obtain \n" +
                "                  " + "15,000 credits during " + gen[2] + " time in space, and " + gen[1] + " wants more. \n" +
                "\n" +
                "\n" +
                "\n" + 
                "\n" +
                "                                               " + "Press Enter to Continue");
            Console.ReadLine();
            Console.Clear();
            // Purchase the first ship.
            string[] ship = NewShip(ref user);
            Console.Clear();
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
                    Console.Write("Select from the following options:\n" +
                                        "1. Status\n" +
                                        "2. Trade\n" +
                                        "3. Travel to...\n" +
                                        "4. Change ship\n" +
                                        "5. Quit game\n" +
                                        "\n ");
                    int selection = int.Parse(Console.ReadLine());
                    switch (selection)
                    {
                        case 1:
                            ShowStatus(user);
                            break;
                        case 2:
                            Trade(ref user, ref ship);
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
        private static void Trade(ref string[] user, ref string[] ship)
        {
            string[] earthGoods = { "art", "wine", "literature" };
            double[] eartPrices = { 1250.00, 750.00, 1499.99 };
            string[] acGoods = { "dilithium crystals", "positronic brain" };
            double[] acPrices = { 3250.00, 3075.50 };
            string[] prextieGoods = { "dark enetrgy shots", "black whole tickets" };
            double[] prextiePrices = { 3499.99, 4999.99 };
            int selection = 0;
            int quantity = 0;
            Console.WriteLine("Select from the following uptions: \n" +
            "1. buy\n" +
            "2. sell");
            int tradeMode = int.Parse(Console.ReadLine().Trim());
            if (tradeMode == 1)
            {
                switch (user[4])
                {
                    case "Earth":
                        Console.WriteLine("what would you like to buy? \n" +
                        $"1. {earthGoods[0]}\n" +
                        $"2. {earthGoods[1]}\n" +
                        $"3. {earthGoods[2]}");
                        selection = int.Parse(Console.ReadLine().Trim());
                        break;
                    case "Alpha Centauri":
                        Console.WriteLine("what would you like to buy? \n" +
                        $"1. {acGoods[0]}\n" +
                        $"2. {acGoods[1]}");
                        selection = int.Parse(Console.ReadLine().Trim());
                        break;
                    case "Prextie":
                        Console.WriteLine("what would you like to buy? \n" +
                        $"1. {prextieGoods[0]}\n" +
                        $"2. {prextieGoods[1]}\n");
                        selection = int.Parse(Console.ReadLine().Trim());
                        break;
                }
                Console.WriteLine("How many units would you like to buy?");
                quantity = int.Parse(Console.ReadLine().Trim());
                if (int.Parse(user[5].Trim()) < int.Parse(ship[2].Trim()))
                {
                    switch (user[4])
                    {
                        case "Earth":
                            // updates the user's wallet
                            user[2] = Convert.ToString(double.Parse(user[2]) - eartPrices[selection - 1]);
                            break;
                        case "Alpha Centauri":
                            // updates the user's wallet
                            user[2] = Convert.ToString(double.Parse(user[2]) - acPrices[selection - 1]);
                            break;
                        case "Prextie":
                            // updates the user's wallet
                            user[2] = Convert.ToString(double.Parse(user[2]) - prextiePrices[selection - 1]);
                            break;
                    }
                    user[5] = Convert.ToString(int.Parse(user[5]) + quantity);
                }
                else
                {
                    Console.WriteLine("The ship's cargo is full.");
                }
            }
            else
            {
                Console.WriteLine("How many units would you like to sell?");
                int sellQuantity = int.Parse(Console.ReadLine().Trim());
                user[5] = Convert.ToString(int.Parse(user[5]) - sellQuantity);

                // updates the user's wallet
                user[2] = Convert.ToString(double.Parse(user[2]) + 5000);
            }

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
                    "\n ");
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

        // Creates a user. [0] - name, [1] - gender, [2] - wallet, [3] - travel time, [4] - location, [5] - goods quantity
        private static string[] CreateUser()
        {
            string[] user = new string[6];
            try
            {
                Console.Write("\n Enter your character's name: ");
                user[0] = Console.ReadLine();
                user[2] = "15000";
                user[3] = "0";
                user[4] = "Earth";
                user[5] = "0";
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
