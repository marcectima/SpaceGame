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
            string[] user = new string[3];
            Console.WriteLine("Welcome to Space Trader");
            Console.ReadLine();
            Console.WriteLine("Select gender: \n" +
                "Male 1\n" +
                "Female 2");
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
            Console.WriteLine(user[1]);
            Console.WriteLine(user[0] + " is a rich billionaire astronaut/scientist. " + user[0] + " saw something from out of space with his  telescope that \n" +
                "looked very interesting. Dave went on a long journey in space to discover whatever that was \n" +
                "that interest him. He discovered that the planet had a whole life form. He realizes the \n" +
                "creatures that where there can communicate with him. Dave saw a valuable item. Dave ask the \n" +
                "creatures about the item. And, the creatures told Dave they got it from a planet call Prextie. \n" +
                "Dave convince the creatures to take him to the planet. Dave couldn’t believe his eyes. Dave \n" +
                "went back to their planet.  They’ve told the creatures he would return.  A month pass after \n" +
                "Dave told his fellow earthling that he would be gone for a while. Dave return to the planet \n" +
                "and ask the creatures to show him more. Dave return to Prextie and was able to make a space \n" +
                "life for himself. He learned a lot of space life.");
            Console.ReadLine();
        }
    }
}