using System;

namespace FOP_Final_Proj
{
  
    public static class Input
    {
       
        public static int ReadNumber(string prompt, int min, int max = int.MaxValue)
        {
            while (true)
            {
                try
                {
                    Console.Write(prompt);
                    int number = Convert.ToInt32(Console.ReadLine());

                    if (number >= min && number <= max)
                        return number;

                    Console.WriteLine();

                    if (max == int.MaxValue)
                        Console.WriteLine($"Invalid input. Please enter {min} or higher.");
                    else
                        Console.WriteLine($"Invalid input. Please enter a number from {min} to {max}.");
                }
                catch (FormatException)
                {
                    Console.WriteLine();
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine();
                    Console.WriteLine("That number is too big.");
                }

                Console.WriteLine();
            }
        }
    }
}
