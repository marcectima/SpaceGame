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

            // Setting the conolse text color to green
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            // Creating the univers
            List<PlanetarySystem> universe = Utilities.OperationGenesis();

            // Creating trading goods and trade menus
            Goods[] tradingGoods = Utilities.CreateTradingGoods();
            string[] TradeMenu = Utilities.CreateTradeMenus(tradingGoods);

            Console.WriteLine("\nWelcome to Space Trader");

            // Creating a new user.
            Player myPlayer = new Player();
            Console.Clear();

            // Opens action menu. This is where the game runs.
            ShowActionMenu(myPlayer, universe, tradingGoods, TradeMenu);

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
        private static void ShowActionMenu(Player myPlayer, List<PlanetarySystem> universe, Goods[] tradingGoods, string[] TradeMenu)
        {
            bool keepLooping = true;
            do
            {
                bool commandNotExecuted = true;
                do
                {

                    try

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
                        Console.Write("\nSelect from the following options:\n\n1. Status\n2. Trade\n3. Travel to...\n4. Refuel\n5. Change ship\n6. Quit game\n\n>>> ");
                        MenuSelection selection = new MenuSelection(Console.ReadLine().Trim());
                        if (Enumerable.Range(1, 6).Contains(selection.GetSelection()))
                        {
                            switch (selection.GetSelection())
                            {
                                case 1:
                                    myPlayer.ShowStatus();
                                    break;
                                case 2:
                                    Console.Clear();
                                    Trade(tradingGoods, myPlayer, TradeMenu);
                                    break;
                                case 3:
                                    myPlayer.Travel(universe);
                                    break;
                                case 4:
                                    myPlayer.Refuel(true);
                                    break;
                                case 5:
                                    myPlayer.newShip(true);
                                    break;
                                case 6:
                                    Console.WriteLine("You chose to end the game.\n");
                                    Utilities.EndGameReport(myPlayer);
                                    keepLooping = false;
                                    break;
                            }
                            commandNotExecuted = false;
                        }
                        else
                        {
                            Console.Clear();
                            throw new Exception("\nInvalid Entry");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                } while (commandNotExecuted);
                Console.WriteLine("\nCommand successfully executed. Press Enter to Continue.");
                Console.ReadLine();
                Console.Clear();
            } while (keepLooping);
        }

        // Executes the trading decisions
        private static void Trade(Goods[] tradingGoods, Player myPlayer, string[] TradeMenu)
        {
            string buyMenu = TradeMenu[0];
            string sellMenu = TradeMenu[1];
            bool keepLooping = true;
            do
            {
                Console.Write("\nSelect from the following options:\n\n1. buy\n2. sell\n\n>>> ");
                MenuSelection tradeMode = new MenuSelection(Console.ReadLine().Trim());
                try
                {
                    if (tradeMode.GetSelection() == 1)
                    {
                        myPlayer.BuyGoods(buyMenu, tradingGoods);
                    }
                    else if (tradeMode.GetSelection() == 2)
                    {
                        myPlayer.SellGoods(sellMenu, tradingGoods);
                    }
                    else
                    {
                        throw new Exception("\nInvalid Entry");
                    }
                    keepLooping = false;
                }

                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                }
            } while (keepLooping);

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

        // Creates a user. [0] - name, [1] - gender, [2] - wallet, [3] - travel time, [4] - location, 
        // [5] - Earth goods, [6] - Alpha Centauri Goods, [7] - Prextie Goods
        private static string[] CreateUser()
        {
            string[] user = new string[8];
            try
            {
                Console.Write("\n Enter your character's name: ");
                user[0] = Console.ReadLine();
                user[2] = "15000";
                user[3] = "0";
                user[4] = "Earth";
                user[5] = "0";
                user[6] = "0";
                user[7] = "0";
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
