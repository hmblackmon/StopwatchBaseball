using System;

namespace StopwatchBaseball
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] basesAnimation = new string[7];
            basesAnimation[0] = "     ◆";
            basesAnimation[1] = "";
            basesAnimation[2] = "◆";
            basesAnimation[3] = "    ▬";
            basesAnimation[4] = "    ◈";
            basesAnimation[5] = "";
            basesAnimation[6] = "     ◆";
            Game game = new Game();
            Console.Clear();
            Console.WriteLine("Welcome to Stopwatch Baseball");
            Console.WriteLine("Press 1 to:\tPlay Ball\nPress 2 to:\tBatting Practice\nPress 3 to:\tSee Rules\nPress 4 to:\tSee Leaderboard\nPress 5 to:\tExit Game");
            string userInput = Console.ReadLine();
            while(userInput != "5")
            {
                if (userInput == "1")
                {
                    game.PlayBall(basesAnimation);
                    Console.Clear();
                }
                else if(userInput == "2")
                {
                    game.BattingPractice();
                    Console.Clear();
                }
                else if (userInput == "3")
                {
                    Rules rules = new Rules();
                    rules.ShowRules();
                    Console.Clear();
                }
                else if (userInput == "4")
                {
                    Leaderboard leaderboard = new Leaderboard();
                    leaderboard.GetLeaderboard();
                    Console.Clear();
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: Input Invalid");
                    Console.ResetColor();
                }
                Console.WriteLine("Welcome to Stopwatch Baseball");
                Console.WriteLine("Press 1 to:\tPlay Ball\nPress 2 to:\tBatting Practice\nPress 3 to:\tSee Rules\nPress 4 to:\tSee Leaderboard\nPress 5 to:\tExit Game");
                userInput = Console.ReadLine();
            }
            Console.WriteLine("Exiting...");
        }
    }
}
