using System;

class Program
{
    static void Main()
    {
        // intro display text
        Console.WriteLine("----------------------------------");
        Console.WriteLine("- Welcome to the game of sticks! -");
        Console.WriteLine("----------------------------------");
        Console.WriteLine();
        Console.WriteLine("Players will take turns removing between 1 and 3 of the remaining sticks.");
        Console.WriteLine("The player that removes the last stick loses.");
        Console.WriteLine();

        //variables for game

        int sticksLeft = 20;

        int currentPlayer = 1;

        int maxSticks = 3;

        while (true)
        {
            // make it so if theres less than 3 sticks you can only chooose the amount left
            if (sticksLeft < 3)
            {
                maxSticks = sticksLeft;
            }
            else
            {
                maxSticks = 3;
            }

            //  ask for sticks
            int sticksChosen;
            bool validInput = false;

            while (!validInput)
            {
                Console.WriteLine($"Sticks left: {sticksLeft}");
                Console.Write($"Player {currentPlayer}, how many sticks would you like to take? ");

                string? input = Console.ReadLine();

                // parse the input
                if (int.TryParse(input, out sticksChosen))
                {
                    // make sure the amount of sticks is between 1 anmd 3
                    if (sticksChosen < 1)
                    {
                        Console.WriteLine("Please choose at least 1 stick.");
                        Console.WriteLine();
                    }
                    else if (sticksChosen > maxSticks)
                    {
                        Console.WriteLine($"Sorry, there are not {sticksChosen} sticks left.");
                        Console.WriteLine();
                    }
                    else
                    {

                        validInput = true;

                        // decreases the amount of total
                        sticksLeft -= sticksChosen;
                        Console.WriteLine();

                        // alternate players turn
                        if (currentPlayer == 1)
                        {
                            currentPlayer = 2;
                        }
                        else
                        {
                            currentPlayer = 1;
                        }

                        // if the number of sticks left is 0, show who won
                        if (sticksLeft == 0)
                        {
                            Console.WriteLine("/---------------\\");
                            Console.WriteLine($"| Player {currentPlayer} won! |");
                            Console.WriteLine("\\---------------/");
                            return;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid number.");
                    Console.WriteLine();
                }
            }
        }
    }
}
