using System;

namespace StopwatchBaseball
{
    public class Leaderboard
    {
        public void GetLeaderboard()
        {
            Console.Clear();
            GameFile majorLeague = new GameFile("Leaderboards/majorleague.txt");
            Console.WriteLine("Major League");
            majorLeague.ReadHighScores();

            GameFile minorLeague = new GameFile("Leaderboards/minorleague.txt");
            Console.WriteLine("\nMinor League");
            minorLeague.ReadHighScores();

            GameFile varsity = new GameFile("Leaderboards/varsity.txt");
            Console.WriteLine("\nVarsity");
            varsity.ReadHighScores();

            GameFile juniorVarsity = new GameFile("Leaderboards/juniorvarsity.txt");
            Console.WriteLine("\nJunior Varsity");
            juniorVarsity.ReadHighScores();

            GameFile littleLeague = new GameFile("Leaderboards/littleleague.txt");
            Console.WriteLine("\nLittle League");
            littleLeague.ReadHighScores();

            GameFile kidsPitch = new GameFile("Leaderboards/kidspitch.txt");
            Console.WriteLine("\nKids Pitch");
            kidsPitch.ReadHighScores();

            GameFile teeBall = new GameFile("Leaderboards/teeball.txt");
            Console.WriteLine("\nTee Ball");
            teeBall.ReadHighScores();

            Console.WriteLine("\n\nPress any key to go back to the main menu");
            Console.ReadKey();
        }
    }
}