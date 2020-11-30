using System;

namespace StopwatchBaseball
{
    public class Rules
    {
        public void ShowRules()
        {
            Console.Clear();
            Console.WriteLine("To start the game, the player will press any key to activate the stopwatch.\nThe player will then atempt to stop the stopwatch within the specific time based on the chosen difficulty.\nIf a player fails to stop the stopwatch on the specific time, then that attempt is considered an out.\n\nPress any key to see times for each difficulty.");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Major League:\nHomerun:\t1.00\nTriple:\t\t0.99\nDouble:\t\t0.98\nSingle\t\t0.97");
            Console.WriteLine("\nMinor League:\nHomerun:\t1.00\nTriple:\t\t0.99 or 1.01\nDouble:\t\t0.98 or 1.02\nSingle\t\t0.97 or 1.03");
            Console.WriteLine("\nVarsity\nHomerun:\t1.00\nTriple:\t\t0.98-0.99 or 1.01-1.02\nDouble:\t\t0.96-0.97 or 1.03-1.04\nSingle:\t\t0.94-0.95 or 1.05-1.06");
            Console.WriteLine("\nJunior Varsity\nHomerun:\t0.99-1.01\nTriple:\t\t0.96-0.98 or 1.02-1.04\nDouble:\t\t0.93-0.95 or 1.05-1.07\nSingle:\t\t0.90-0.92 or 1.08-1.10");
            Console.WriteLine("\nLittle League\nHomerun:\t0.98-1.02\nTriple:\t\t0.93-0.97 or 1.03-1.07\nDouble:\t\t0.88-0.92 or 1.08-1.12\nSingle:\t\t0.83-0.87 or 1.13-1.17");
            Console.WriteLine("\nKids Pitch\nHomerun:\t0.97-1.03\nTriple:\t\t0.90-0.96 or 1.04-1.10\nDouble:\t\t0.83-0.89 or 1.11-1.17\nSingle:\t\t0.76-0.82 or 1.18-1.24");
            Console.WriteLine("\nTee Ball\nHomerun:\t0.96-1.04\nTriple:\t\t0.87-0.95 or 1.05-1.13\nDouble:\t\t0.78-0.86 or 1.14-1.22\nSingle:\t\t0.69-0.77 or 1.23-1.31");
            Console.WriteLine("\n\nPress any key to return to the main menu.");
            Console.ReadKey();
        }
    }
}