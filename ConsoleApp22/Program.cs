using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp22
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] username = new string[1];
            Console.WriteLine("Enter your name");
            username[0] = Console.ReadLine(1);
            Console.WriteLine("This " + username[0] + " is awsome");          
        }
    }
}
