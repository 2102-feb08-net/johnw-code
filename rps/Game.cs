using System;

namespace rps
{
    public enum Choices
    {
        Rock,
        Paper,
        Scissors
    }
    class Game
    {
        int playerWins = 0;
        int cpuWins = 0;
        public void Play(string playerChoice)
        {
            // check for valid player choice
            if (!IsValid(playerChoice))
            {
                Console.WriteLine($"{playerChoice} is not a valid choice. Please choose another.\n");
                return;
            }

            // get a random number to choose a random choice
            Random _random = new Random(Guid.NewGuid().GetHashCode());
            int r = _random.Next(Enum.GetValues(typeof(Choices)).Length);
            var cpuChoice = (Choices)r;
            FindWinner(playerChoice, cpuChoice);
            Console.WriteLine($"\nPlayer wins: {playerWins} - CPU wins: {cpuWins}");
        }

        private bool IsValid(string playerChoice)
        {
            // check each of the choices to see if the player chose a valid one or not
            foreach (Choices val in Enum.GetValues(typeof(Choices)))
            {
                if (playerChoice.ToLower() == val.ToString().ToLower())
                {
                    return true;
                }
            }
            return false;
        }

        private void FindWinner(string playerChoice, Choices cpuChoice)
        {
            // Buffer line in the terminal
            Console.WriteLine("");
            // standardize the player guess to match the enum style.
            string p = FirstCharToUpper(playerChoice.ToLower());
            // check for a tie
            if (playerChoice.ToLower() == cpuChoice.ToString().ToLower())
            {
                Console.WriteLine($"Player chose: {p}");
                Console.WriteLine($"Computer chose: {cpuChoice}");
                Console.WriteLine("It's a tie.");
            }
            
            Choices result;
            if (Enum.TryParse(p, out result))
            {
                switch (result)
                {
                    case Choices.Rock:
                        if (cpuChoice == Choices.Paper)
                        {
                            Console.WriteLine($"Player chose: {result}");
                            Console.WriteLine($"Computer chose: {cpuChoice}");
                            Console.WriteLine($"{cpuChoice} beats {result}. You lost...");
                            cpuWins++;
                        }
                        if (cpuChoice == Choices.Scissors)
                        {
                            Console.WriteLine($"Player chose: {result}");
                            Console.WriteLine($"Computer chose: {cpuChoice}");
                            Console.WriteLine($"{result} beats {cpuChoice}! You won!");
                            playerWins++;
                        }
                        break;
                    case Choices.Paper:
                        if (cpuChoice == Choices.Scissors)
                        {
                            Console.WriteLine($"Player chose: {result}");
                            Console.WriteLine($"Computer chose: {cpuChoice}");
                            Console.WriteLine($"{cpuChoice} beats {result}. You lost...");
                            cpuWins++;
                        }
                        if (cpuChoice == Choices.Rock)
                        {
                            Console.WriteLine($"Player chose: {result}");
                            Console.WriteLine($"Computer chose: {cpuChoice}");
                            Console.WriteLine($"{result} beats {cpuChoice}! You won!");
                            playerWins++;
                        }
                        break;
                    case Choices.Scissors:
                        if (cpuChoice == Choices.Rock)
                        {
                            Console.WriteLine($"Player chose: {result}");
                            Console.WriteLine($"Computer chose: {cpuChoice}");
                            Console.WriteLine($"{cpuChoice} beats {result}. You lost...");
                            cpuWins++;
                        }
                        if (cpuChoice == Choices.Paper)
                        {
                            Console.WriteLine($"Player chose: {result}");
                            Console.WriteLine($"Computer chose: {cpuChoice}");
                            Console.WriteLine($"{result} beats {cpuChoice}! You won!");
                            playerWins++;
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private string FirstCharToUpper(string input)
        {
            return input[0].ToString().ToUpper() + input.Substring(1);
        }
    }
}