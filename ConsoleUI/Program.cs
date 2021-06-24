using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the party!");
            GetUserInfo();
            PrintGuestsName();
            PrintWinner();
            //MultiLineAnimation();
            Console.ReadKey();
        }

        //Start writing your code here
        private static Dictionary<int, string> guests = new Dictionary<int, string>();
        private static int min = 1000;
        private static int max = 9999;
        private static int raffleNum;
        private static Random rdm = new Random();

        static string GetUserInput(string message)
        {
            Console.WriteLine(message);
            string userInput = Console.ReadLine();
            return userInput;
        }

        //Start writing your code here
        static void GetUserInfo()
        {
            string guest;
            string otherGuest;
            do
            {
                guest = GetUserInput("\nPlease enter the name of a guest: ");
                if (guest == "")
                {
                    Console.WriteLine("Invalid entry; entered empty name.");
                    GetUserInfo();
                }
                raffleNum = GenerateRandomNumber(min, max);
                if (guests.ContainsKey(raffleNum))
                {
                    GetUserInfo();
                }
                AddGuestsInRaffle(raffleNum, guest);
                otherGuest = GetUserInput("\nWould you like to add another guest?").ToLower();
            } while (otherGuest == "yes");
        }

        static int GenerateRandomNumber(int minNum, int maxNum)
        {
            int num = rdm.Next(minNum, maxNum);
            return num;
        }

        static void AddGuestsInRaffle(int raffleNum, string guest)
        {
            guests.Add(raffleNum, guest);
            Console.WriteLine($"{guest} has been entered into the raffle.");
        }

        static void PrintGuestsName()
        {
            foreach (KeyValuePair<int, string> guest in guests)
            {
                Console.WriteLine(guest);
            }
        }

        static int GetRaffleNumber(Dictionary<int, string> peeps)
        {
            List<int> numList = new List<int>();
            foreach (KeyValuePair<int, string> kvp in peeps)
            {
                numList.Add(kvp.Key);
            }
            int numDraw = rdm.Next(0, numList.Count - 1); // how to randomly pick a raffle num from the dictionary?
            int winnerNum = numList[numDraw];
            // Console.WriteLine(winnerNum);
            return winnerNum;
        }

        static void PrintWinner()
        {
            int winnerNum = GetRaffleNumber(guests);
            string winnerName = guests[winnerNum];
            Console.WriteLine($"The winner is {winnerName} with the #{winnerNum}!");
        }




        static void MultiLineAnimation() // Credit: https://www.michalbialecki.com/2018/05/25/how-to-make-you-console-app-look-cool/
        {
            var counter = 0;
            for (int i = 0; i < 30; i++)
            {
                Console.Clear();

                switch (counter % 4)
                {
                    case 0:
                        {
                            Console.WriteLine("         ╔════╤╤╤╤════╗");
                            Console.WriteLine("         ║    │││ \\   ║");
                            Console.WriteLine("         ║    │││  O  ║");
                            Console.WriteLine("         ║    OOO     ║");
                            break;
                        };
                    case 1:
                        {
                            Console.WriteLine("         ╔════╤╤╤╤════╗");
                            Console.WriteLine("         ║    ││││    ║");
                            Console.WriteLine("         ║    ││││    ║");
                            Console.WriteLine("         ║    OOOO    ║");
                            break;
                        };
                    case 2:
                        {
                            Console.WriteLine("         ╔════╤╤╤╤════╗");
                            Console.WriteLine("         ║   / │││    ║");
                            Console.WriteLine("         ║  O  │││    ║");
                            Console.WriteLine("         ║     OOO    ║");
                            break;
                        };
                    case 3:
                        {
                            Console.WriteLine("         ╔════╤╤╤╤════╗");
                            Console.WriteLine("         ║    ││││    ║");
                            Console.WriteLine("         ║    ││││    ║");
                            Console.WriteLine("         ║    OOOO    ║");
                            break;
                        };
                }

                counter++;
                Thread.Sleep(200);
            }
        }
    }
}
