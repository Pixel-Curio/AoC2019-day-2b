using System;
using System.IO;
using System.Linq;

namespace Day_2b
{
    class Program
    {
        private const string InputPath = @"day2a-input.txt";
        private const int TargetValue = 19690720;

        static void Main(string[] args)
        {
            int[] code = File.ReadAllText(InputPath).Split(",").Select(int.Parse).ToArray();

            for (int x = 0; x < 99; x++)
            {
                for (int y = 0; y < 99; y++)
                {
                    code = File.ReadAllText(InputPath).Split(",").Select(int.Parse).ToArray();
                    code[1] = x;
                    code[2] = y;

                    Intcode processor = new Intcode(code);
                    processor.Process();

                    Console.WriteLine($"Processing X:{x} Y:{y} Result:{processor.PrintValue(0)}");

                    if (processor.PrintValue(0) == TargetValue)
                    {
                        Console.WriteLine($"Success Value = X:{x},Y:{y}");
                        return;
                    }
                }
            }

            Console.ReadKey();
        }
    }
}
