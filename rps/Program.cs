using System;

namespace rps
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Let's play Rock, Paper, Scissors!");
            Game g = new Game();
            while (true)
            {
                Console.WriteLine("Enter your choice (or 'q' to quit):");
                string x = Console.ReadLine();
                if (x.ToLower() == "quit" || x.ToLower() == "q")
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }
                g.Play(x);
            }
        }
    }
}
