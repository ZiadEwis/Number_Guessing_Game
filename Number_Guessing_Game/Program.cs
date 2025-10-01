using System;
using System.Threading.Channels;

namespace Number_Guessing_Game
{
    public class program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Guessing_Game game = new Guessing_Game();
            game.Play();
        }
    }

    public class Guessing_Game
    {
        public void Play()
        {
            Random random = new Random();

            int randomNum = random.Next(1, 101);
            int numOfRemainingChances = 7;
            int guess = -1;

            Console.WriteLine("Welcome to the number gussing game!");
            Console.WriteLine("A number between 1 and 100 will be generated.");
            Console.WriteLine("If you guess the correct number, you won!");

            while (numOfRemainingChances > 0)
            {
                bool inputSuccessful = false;

                while (!inputSuccessful)
                {
                    Console.WriteLine($"\nRemaining chances: {numOfRemainingChances}");
                    Console.WriteLine("Please enter your guess:");
                    string? input = Console.ReadLine();

                    if (string.IsNullOrEmpty(input))
                    {
                        Console.WriteLine("You didn't enter anything, please enter your number: ");
                        continue;
                    }

                    if(!int.TryParse(input,out guess))
                    {
                        Console.WriteLine("Invalid input, please enter your number");
                        continue;
                    }

                    if (guess >= 1 && guess <= 100)
                        inputSuccessful = true;
                    else
                        Console.WriteLine("The number must be between 1 and 100, please try again");
                }

                if (guess > randomNum)
                    Console.WriteLine("Your guess is too high, you still have " + --numOfRemainingChances + " chance");
                else if (guess < randomNum)
                    Console.WriteLine("Your guess is too low, you still have " + --numOfRemainingChances + " chance");
                else
                {
                    Console.WriteLine("Correct!");
                    break;
                }

            }

            if (numOfRemainingChances > 0)
                Console.WriteLine("Gongratulations! You have won the game! 🥳🥳");
            else
                Console.WriteLine($"You lose! 😔😔 the correct number was {randomNum}");

            Console.ReadKey();
        }
    }
}