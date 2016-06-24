using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loginauthentication
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            String username;
            String password;
            String[,] accnts = { { "mukes", "dada" }, { "admin", "fafa" }, { "admin", "gaga" } };
            int row;
            bool isValideUser = false;
            for (int x = 3; x >= 1; x--)
            {
                Console.WriteLine("HELLO !");
                Console.WriteLine("You have " + x + " attempt/s.");
                Console.Write("Enter Username: ");
                username = Console.ReadLine();
                Console.Write("Enter Password: ");
                password = Console.ReadLine();
                for (row = 0; row < 3; row++)
                {
                    if (username.Equals(accnts[row, 0]) && password.Equals(accnts[row, 1]))
                    {
                        Console.WriteLine("Welcome " + accnts[row, 0] + "!");
                        isValideUser = true;
                        break;
                    }
                }
                if (!isValideUser)
                {
                    Console.WriteLine("Invalid Input.");
                    if (x != 1)
                    {
                        Console.WriteLine("Please Try Again.");
                        Console.Write("\n");
                    }
                    else if (x.Equals(1))
                    {
                        Console.Write("Goodbye!");
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
            Console.ReadKey();
        }
    }
}