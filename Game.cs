using System;
using System.Diagnostics;

namespace StopwatchBaseball
{
    class Game
    {
        private GameSettings gameSettings;
        private GameScoreing gameScoreing;
        private GameFile gameFile;

        public void SetGameSettings(GameSettings gameSettings)
        {
            this.gameSettings = gameSettings;
        }
        public void SetGameScoring(GameScoreing gameScoreing)
        {
            this.gameScoreing = gameScoreing;
        }
        public void BattingPractice()
        {
            Console.Clear();
            Console.WriteLine("Press 1 for:\t5 swings\nPress 2 to:\tReturn to main menu");
            int input = int.Parse(Console.ReadLine());
            while(input != 1 && input != 2)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: Input Invalid");
                Console.ResetColor();
                Console.WriteLine("Press 1 for:\t5 swings\nPress 2 to:\tReturn to main menu");
                input = int.Parse(Console.ReadLine());
            }
            while(input == 1)
            {
                double time = 0;
                for(int i = 0; i < 5; i++)
                {
                    Console.Clear();
                    if(i != 0)
                    {
                        Console.WriteLine($"You got:\t{time}");
                    }
                    time = GetTime();
                }
                Console.Clear();
                Console.WriteLine($"You got:\t{time}");
                Console.WriteLine("Press 1 for:\t5 swings\nPress 2 to:\tReturn to main menu");
                input = int.Parse(Console.ReadLine());
                while(input != 1 && input != 2)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: Input Invalid");
                    Console.ResetColor();
                    Console.WriteLine("Press 1 for:\t5 swings\nPress 2 to:\tReturn to main menu");
                    input = int.Parse(Console.ReadLine());
                }
            }
        }
        public void PlayBall(string[] basesAnimation)
        {
            Console.Clear();
            Console.WriteLine("Press 1 for:\t1 Player\nPress 2 for:\t2 Players");
            int numberOfPlayers = int.Parse(Console.ReadLine());
            while(numberOfPlayers > 2 || numberOfPlayers < 1)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: Input Invalid");
                Console.ResetColor();
                Console.WriteLine("Press 1 for:\t1 Player\nPress 2 for:\t2 Players");
                numberOfPlayers = int.Parse(Console.ReadLine());
            }
            Console.Clear();
            Console.WriteLine("Choose Difficulty:\nPress 1 for:\tMajor League\nPress 2 for:\tMinor League\nPress 3 for:\tVarsity\nPress 4 for:\tJunior Varsity\nPress 5 for:\tLittle League\nPress 6 for:\tKids Pitch\nPress 7 for:\tTee Ball");
            int difficulty = int.Parse(Console.ReadLine());
            while(numberOfPlayers > 7 || numberOfPlayers < 1)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: Input Invalid");
                Console.ResetColor();
                Console.WriteLine("Choose Difficulty:\nPress 1 for:\tMajor League\nPress 2 for:\tMinor League\nPress 3 for:\tVarsity\nPress 4 for:\tJunior Varsity\nPress 5 for:\tLittle League\nPress 6 for:\tKids Pitch\nPress 7 for:\tTee Ball");
                difficulty = int.Parse(Console.ReadLine());
            }
            GameSettings gameSettings = new GameSettings(numberOfPlayers, difficulty);
            SetGameSettings(gameSettings);
            string[] tempString1 = new string[9];
            string[] tempString2 = new string[9];
            GameScoreing gameScoreing = new GameScoreing(0, 0, 0, "", "", tempString1, "", "", tempString2, basesAnimation);
            SetGameScoring(gameScoreing);
            gameScoreing.ResetScore(numberOfPlayers);
            gameFile = SetFile(difficulty);
            gameFile.GetAllScores();
            Console.Clear();
            for(int i = 0; i < 9; i++)
            {
                
                gameScoreing.SetInning(i+1);
                if(numberOfPlayers == 2)
                {
                    if(i == 0)
                    {
                        ScoreBoard();
                        BaseAnimation();
                        Console.WriteLine("\n");
                        Console.WriteLine("Guest team is now up to bat.\nPress any key to continue");
                        Console.ReadKey();
                    }
                    (string tempOutcome, double tempTime) = GuestAtBat();
                    gameScoreing.SetPlayerGuestInningRuns(gameScoreing.GetPlayerGuestInningRuns());
                    gameScoreing.ResetAfterGuestAtBat();
                    ScoreBoard();
                    BaseAnimation();
                    Console.WriteLine(tempOutcome);
                    Console.WriteLine(tempTime);
                    Console.WriteLine("Home team is now up to bat.\nPress any key to continue");
                    Console.ReadKey();
                }
                (string outcome, double time) = HomeAtBat();
                gameScoreing.ResetAfterHomeAtBat();
                ScoreBoard();
                BaseAnimation();
                if(numberOfPlayers == 2)
                {
                    Console.WriteLine(outcome);
                    Console.WriteLine(time);
                    Console.WriteLine("Guest team is now up to bat.\nPress any key to continue");
                }
                else
                {
                    Console.WriteLine(outcome);
                    Console.WriteLine(time);
                    Console.WriteLine("End of the inning.\nPress any key to continue");
                }
                Console.ReadKey();
            }
            ScoreBoard();
            if(numberOfPlayers == 2)
            {
                if(int.Parse(gameScoreing.GetPlayerGuestRuns()) > int.Parse(gameScoreing.GetPlayerHomeRuns()))
                {
                    Console.WriteLine("Guest Team Wins!!!");
                }
                else if(int.Parse(gameScoreing.GetPlayerGuestRuns()) < int.Parse(gameScoreing.GetPlayerHomeRuns()))
                {
                    Console.WriteLine("Home Team Wins!!!");
                }
                else
                {
                    Console.WriteLine("Game Ends in a Draw.");
                }
                int indexGuest = gameFile.HighScoreSearch(int.Parse(gameScoreing.GetPlayerGuestRuns()));
                if(indexGuest != -1)
                {
                    gameFile.SaveAllScores();
                }
                
            }
            Console.WriteLine(int.Parse(gameScoreing.GetPlayerHomeRuns()));
            int indexHome = gameFile.HighScoreSearch(int.Parse(gameScoreing.GetPlayerHomeRuns()));
            if(indexHome != -1)
            {
                gameFile.SaveAllScores();
            }
            Console.WriteLine("Press any key to go back to the main menu");
            Console.ReadKey();
        
        }
        public double GetTime()
        {
            Stopwatch stopwatch = new Stopwatch();
            Console.WriteLine("Press any key to start and stop");
            Console.ReadKey();
            stopwatch.Start();
            Console.ReadKey();
            stopwatch.Stop();
            string elapsedTime = stopwatch.Elapsed.ToString();
            char[] time = new char[6]; 
            int j = 6;
            for(int i = 0; i < 6; i++)
            {

                time[i] = elapsedTime[j];
                j++;
            }
            string timeString = new string(time);
            double timeDouble = double.Parse(timeString);
            timeString = Math.Round(timeDouble, 2).ToString("0.00");
            timeDouble = double.Parse(timeString);
            stopwatch.Reset();
            return timeDouble;
        }
        public Tuple<string, double> GuestAtBat()
        {
            double time = 0;
            bool showTime = false;
            string outcome = "";
            while(gameScoreing.GetOuts() < 3)
            {
                ScoreBoard();
                Console.WriteLine("Batting:\tGuest");
                BaseAnimation();
                if(showTime)
                {
                    Console.WriteLine(outcome);
                    Console.WriteLine(time);
                }
                else
                {
                    Console.WriteLine();
                }
                time = GetTime();
                outcome = DetermineGuestBasesOccupiedOutsAndRuns(time);
                showTime = true;
            }
            Console.WriteLine(outcome);
            Console.WriteLine(time);
            return Tuple.Create(outcome, time);
        }
        public Tuple<string, double> HomeAtBat()
        {
            double time = 0;
            bool showTime = false;
            string outcome = "";
            while(gameScoreing.GetOuts() < 3)
            {
                ScoreBoard();
                Console.WriteLine("Batting:\tHome");
                BaseAnimation();
                if(showTime)
                {
                    Console.WriteLine(outcome);
                    Console.WriteLine(time);
                }
                else
                {
                    Console.WriteLine();
                }
                time = GetTime();
                outcome = DetermineHomeBasesOccupiedOutsAndRuns(time);
                showTime = true;
            }
            Console.WriteLine(outcome);
            Console.WriteLine(time);
            return Tuple.Create(outcome, time);
        }
        public void ScoreBoard()
        {
            Console.Clear();
            string[] playerHomeInningRuns = gameScoreing.GetPlayerHomeInningRuns();
            string[] playerGuestInningRuns = gameScoreing.GetPlayerGuestInningRuns();
            Console.Write("\t");
            for(int i = 0; i < 11; i++)
            {
                if(i > -1 && i < 9)
                {
                    Console.Write($"{i+1}\t");
                }
                else if(i == 9)
                {
                    Console.Write("R\t");
                }
                else
                {
                    Console.WriteLine("H");
                }
            }
            Console.Write("\nGuest:\t");
            for(int i = 0; i < 11; i++)
            {
                if(i > -1 && i < 9)
                {
                    Console.Write($"{playerGuestInningRuns[i]}\t");
                }
                else if(i == 9)
                {
                    Console.Write($"{gameScoreing.GetPlayerGuestRuns()}\t");
                }
                else
                {
                    Console.WriteLine(gameScoreing.GetPlayerGuestHits());
                }
            }
            Console.Write("Home:\t");
            for(int i = 0; i < 11; i++)
            {
                if(i > -1 && i < 9)
                {
                    Console.Write($"{playerHomeInningRuns[i]}\t");
                }
                else if(i == 9)
                {
                    Console.Write($"{gameScoreing.GetPlayerHomeRuns()}\t");
                }
                else
                {
                    Console.WriteLine(gameScoreing.GetPlayerHomeHits());
                }
            }
            Console.WriteLine($"Out:\t{gameScoreing.GetOuts()}");
        }
        public void BaseAnimation()
        {
            string[] basesAnimation = gameScoreing.GetBasesAnimation();
            int basesOccupied = gameScoreing.GetBasesOcupied();
            if(basesOccupied == 0)
            {
                Console.WriteLine(basesAnimation[0]);
                Console.WriteLine(basesAnimation[1]);
                Console.Write(basesAnimation[2]);
                Console.Write(basesAnimation[3]);
                Console.WriteLine(basesAnimation[4]);
                Console.WriteLine(basesAnimation[5]);
                Console.WriteLine(basesAnimation[6]);
            }
            else if(basesOccupied == 1)
            {
                Console.WriteLine(basesAnimation[0]);
                Console.WriteLine(basesAnimation[1]);
                Console.Write(basesAnimation[2]);
                Console.Write(basesAnimation[3]);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(basesAnimation[4]);
                Console.ResetColor();
                Console.WriteLine(basesAnimation[5]);
                Console.WriteLine(basesAnimation[6]);
            }
            else if(basesOccupied == 5)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(basesAnimation[0]);
                Console.ResetColor();
                Console.WriteLine(basesAnimation[1]);
                Console.Write(basesAnimation[2]);
                Console.Write(basesAnimation[3]);
                Console.WriteLine(basesAnimation[4]);
                Console.WriteLine(basesAnimation[5]);
                Console.WriteLine(basesAnimation[6]);
            }
            else if(basesOccupied == 10)
            {
                Console.WriteLine(basesAnimation[0]);
                Console.WriteLine(basesAnimation[1]);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(basesAnimation[2]);
                Console.ResetColor();
                Console.Write(basesAnimation[3]);
                Console.WriteLine(basesAnimation[4]);
                Console.WriteLine(basesAnimation[5]);
                Console.WriteLine(basesAnimation[6]);
            }
            else if(basesOccupied == 6)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(basesAnimation[0]);
                Console.ResetColor();
                Console.WriteLine(basesAnimation[1]);
                Console.Write(basesAnimation[2]);
                Console.Write(basesAnimation[3]);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(basesAnimation[4]);
                Console.ResetColor();
                Console.WriteLine(basesAnimation[5]);
                Console.WriteLine(basesAnimation[6]);
            }
            else if(basesOccupied == 11)
            {
                Console.WriteLine(basesAnimation[0]);
                Console.WriteLine(basesAnimation[1]);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(basesAnimation[2]);
                Console.ResetColor();
                Console.Write(basesAnimation[3]);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(basesAnimation[4]);
                Console.ResetColor();
                Console.WriteLine(basesAnimation[5]);
                Console.WriteLine(basesAnimation[6]);
            }
            else if(basesOccupied == 15)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(basesAnimation[0]);
                Console.WriteLine(basesAnimation[1]);
                Console.Write(basesAnimation[2]);
                Console.ResetColor();
                Console.Write(basesAnimation[3]);
                Console.WriteLine(basesAnimation[4]);
                Console.WriteLine(basesAnimation[5]);
                Console.WriteLine(basesAnimation[6]);
            }
            else if(basesOccupied == 16)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(basesAnimation[0]);
                Console.WriteLine(basesAnimation[1]);
                Console.Write(basesAnimation[2]);
                Console.ResetColor();
                Console.Write(basesAnimation[3]);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(basesAnimation[4]);
                Console.ResetColor();
                Console.WriteLine(basesAnimation[5]);
                Console.WriteLine(basesAnimation[6]);
            }
        }
        public string DetermineGuestBasesOccupiedOutsAndRuns(double time)
        {
            int difficulty = gameSettings.GetDifficulty();
            int basesOccupied = gameScoreing.GetBasesOcupied();
            string outcome = "";
            switch(difficulty)
            {
                case 1:
                    if(time < 0.97 || time > 1.00) //Out
                    {
                        gameScoreing.SetOuts(gameScoreing.GetOuts()+1);
                        outcome = "out!!";
                    }
                    else if(time == 0.97) //Single
                    {
                        gameScoreing.IncreasePlayerGuestHits();
                        GuestSingle(basesOccupied);
                        outcome = "single!!";
                    }
                    else if(time == 0.98) //Double
                    {
                        gameScoreing.IncreasePlayerGuestHits();
                        GuestDouble(basesOccupied);
                        outcome = "double!!";
                    }
                    else if(time == 0.99) //Triple
                    {
                        gameScoreing.IncreasePlayerGuestHits();
                        GuestTriple(basesOccupied);
                        outcome = "triple!!";
                    }
                    else //Homerun
                    {
                        gameScoreing.IncreasePlayerGuestHits();
                        GuestHomeRun(basesOccupied);
                        outcome = "homerun!!";
                    }
                    return outcome;
                case 2:
                    if(time < 0.97 || time > 1.03) //Out
                    {
                        gameScoreing.SetOuts(gameScoreing.GetOuts()+1);
                        outcome = "out!!";
                    }
                    else if(time == 0.97 || time == 1.03)
                    {
                        gameScoreing.IncreasePlayerGuestHits();
                        GuestSingle(basesOccupied);
                        outcome = "single!!";
                    }
                    else if(time == 0.98 || time == 1.02)
                    {
                        gameScoreing.IncreasePlayerGuestHits();
                        GuestDouble(basesOccupied);
                        outcome = "double!!";
                    }
                    else if(time == 0.99 || time == 1.01)
                    {
                        gameScoreing.IncreasePlayerGuestHits();
                        GuestTriple(basesOccupied);
                        outcome = "triple!!";
                    }
                    else
                    {
                        gameScoreing.IncreasePlayerGuestHits();
                        GuestHomeRun(basesOccupied);
                        outcome = "homerun!!";
                    }
                    return outcome;
                case 3:
                    if(time < 0.94 || time > 1.06) //Out
                    {
                        gameScoreing.SetOuts(gameScoreing.GetOuts()+1);
                        outcome = "out!!";
                    }
                    else if(time == 0.94 || time == 0.95 || time == 1.05 || time == 1.06) //Single
                    {
                        gameScoreing.IncreasePlayerGuestHits();
                        GuestSingle(basesOccupied);
                        outcome = "single!!";
                        
                    }
                    else if(time == 0.96 || time == 0.97 || time == 1.03 || time == 1.04) //Double
                    {
                        gameScoreing.IncreasePlayerGuestHits();
                        GuestDouble(basesOccupied);
                        outcome = "double!!";
                        
                    }
                    else if(time == 0.98 || time == 0.99 || time == 1.01 || time == 1.02) //Triple
                    {
                        gameScoreing.IncreasePlayerGuestHits();
                        GuestTriple(basesOccupied);
                        outcome = "triple!!";
                    }
                    else //Homerun
                    {
                        gameScoreing.IncreasePlayerGuestHits();
                        GuestHomeRun(basesOccupied);
                        outcome = "homerun!!";
                    }
                    break;
                case 4:
                    if(time < 0.90 || time > 1.10) //Out
                    {
                        gameScoreing.SetOuts(gameScoreing.GetOuts()+1);
                        outcome = "out!!";
                    }
                    else if(time >= 0.90 && time <= 0.92 || time >= 1.08 && time <= 1.10) //Single
                    {
                        gameScoreing.IncreasePlayerGuestHits();
                        GuestSingle(basesOccupied);
                        outcome = "single!!";
                        
                    }
                    else if(time >= 0.93 && time <= 0.95 || time >= 1.05 && time <= 1.07) //Double
                    {
                        gameScoreing.IncreasePlayerGuestHits();
                        GuestDouble(basesOccupied);
                        outcome = "double!!";
                    }
                    else if(time >= 0.96 && time <= 0.98 || time >= 1.02 && time <= 1.04) //Triple
                    {
                        gameScoreing.IncreasePlayerGuestHits();
                        GuestTriple(basesOccupied);
                        outcome = "triple!!";
                    }
                    else //Homerun
                    {
                        gameScoreing.IncreasePlayerGuestHits();
                        GuestHomeRun(basesOccupied);
                        outcome = "homerun!!";
                    }
                    return outcome;
                case 5:
                    if(time < 0.76 || time > 1.24) //Out
                    {
                        gameScoreing.SetOuts(gameScoreing.GetOuts()+1);
                        outcome = "out!!";
                    }
                    else if(time >= 0.83 && time <= 0.87 || time >= 1.13 && time <= 1.17) //Single
                    {
                        gameScoreing.IncreasePlayerGuestHits();
                        GuestSingle(basesOccupied);
                        outcome = "single!!";
                    }
                    else if(time >= 0.88 && time <= 0.92 || time >= 1.08 && time <= 1.12) //Double
                    {
                        gameScoreing.IncreasePlayerGuestHits();
                        GuestDouble(basesOccupied);
                        outcome = "double!!";
                    }
                    else if(time >= 0.93 && time <= 0.97 || time >= 1.03 && time <= 1.07) //Triple
                    {
                        gameScoreing.IncreasePlayerGuestHits();
                        GuestTriple(basesOccupied);
                        outcome = "triple!!";
                    }
                    else //Homerun
                    {
                        gameScoreing.IncreasePlayerGuestHits();
                        GuestHomeRun(basesOccupied);
                        outcome = "homerun!!";
                    }
                    return outcome;
                case 6:
                    if(time < 0.76 || time > 1.24) //Out
                    {
                        gameScoreing.SetOuts(gameScoreing.GetOuts()+1);
                        outcome = "out!!";
                    }
                    else if(time >= 0.76 && time <= 0.82 || time >= 1.18 && time <= 1.24) //Single
                    {
                        gameScoreing.IncreasePlayerGuestHits();
                        GuestSingle(basesOccupied);
                        outcome = "single!!";
                    }
                    else if(time >= 0.83 && time <= 0.89 || time >= 1.11 && time <= 1.17) //Double
                    {
                        gameScoreing.IncreasePlayerGuestHits();
                        GuestDouble(basesOccupied);
                        outcome = "double!!";
                    }
                    else if(time >= 0.90 && time <= 0.96 || time >= 1.04 && time <= 1.10) //Triple
                    {
                        gameScoreing.IncreasePlayerGuestHits();
                        GuestTriple(basesOccupied);
                        outcome = "triple!!";
                    }
                    else //Homerun
                    {
                        gameScoreing.IncreasePlayerGuestHits();
                        GuestHomeRun(basesOccupied);
                        outcome = "homerun!!";
                    }
                    break;
                case 7:
                    if(time < 0.69 || time > 1.31) //Out
                    {
                        gameScoreing.SetOuts(gameScoreing.GetOuts()+1);
                        outcome = "out!!";
                    }
                    else if(time >= 0.69 && time <= 0.77 || time >= 1.23 && time <= 1.31) //Single
                    {
                        gameScoreing.IncreasePlayerGuestHits();
                        GuestSingle(basesOccupied);
                        outcome = "single!!";
                        
                    }
                    else if(time >= 0.78 && time <= 0.86 || time >= 1.14 && time <= 1.22) //Double
                    {
                        gameScoreing.IncreasePlayerGuestHits();
                        GuestDouble(basesOccupied);
                        outcome = "double!!";
                    }
                    else if(time >= 0.87 && time <= 0.95 || time >= 1.05 && time <= 1.13) //Triple
                    {
                        gameScoreing.IncreasePlayerGuestHits();
                        GuestTriple(basesOccupied);
                        outcome = "triple!!";
                    }
                    else //Homerun
                    {
                        gameScoreing.IncreasePlayerGuestHits();
                        GuestHomeRun(basesOccupied);
                        outcome = "homerun!!";
                    }
                    return outcome;
            }
            return outcome;
        }
        public string DetermineHomeBasesOccupiedOutsAndRuns(double time)
        {
            int difficulty = gameSettings.GetDifficulty();
            int basesOccupied = gameScoreing.GetBasesOcupied();
            string outcome = "";
            switch(difficulty)
            {
                case 1:
                    if(time < 0.97 || time > 1.00) //Out
                    {
                        gameScoreing.SetOuts(gameScoreing.GetOuts()+1);
                        outcome = "out!!";
                    }
                    else if(time == 0.97) //Single
                    {
                        gameScoreing.IncreasePlayerHomeHits();
                        HomeSingle(basesOccupied);
                        outcome = "single!!";                        
                    }
                    else if(time == 0.98) //Double
                    {
                        gameScoreing.IncreasePlayerHomeHits();
                        HomeDouble(basesOccupied);
                        outcome = "double!!";                        
                    }
                    else if(time == 0.99) //Triple
                    {
                        gameScoreing.IncreasePlayerHomeHits();
                        HomeTriple(basesOccupied);
                        outcome = "triple!!";
                    }
                    else //Homerun
                    {
                        gameScoreing.IncreasePlayerHomeHits();
                        HomeHomeRun(basesOccupied);
                        outcome = "homerun!!";
                    }
                    return outcome;
                case 2:
                    if(time < 0.97 || time > 1.03) //Out
                    {
                        gameScoreing.SetOuts(gameScoreing.GetOuts()+1);
                        outcome = "out!!";
                    }
                    else if(time == 0.97 || time == 1.03)
                    {
                        gameScoreing.IncreasePlayerHomeHits();
                        HomeSingle(basesOccupied);
                        outcome = "single!!";
                    }
                    else if(time == 0.98 || time == 1.02)
                    {
                        gameScoreing.IncreasePlayerHomeHits();
                        HomeDouble(basesOccupied);
                        outcome = "double!!";
                    }
                    else if(time == 0.99 || time == 1.01)
                    {
                        gameScoreing.IncreasePlayerHomeHits();
                        HomeTriple(basesOccupied);
                        outcome = "triple!!";
                    }
                    else
                    {
                        gameScoreing.IncreasePlayerHomeHits();
                        HomeHomeRun(basesOccupied);
                        outcome = "homerun!!";
                    }
                    return outcome;
                case 3:
                    if(time < 0.94 || time > 1.06) //Out
                    {
                        gameScoreing.SetOuts(gameScoreing.GetOuts()+1);
                        outcome = "out!!";
                    }
                    else if(time == 0.94 || time == 0.95 || time == 1.05 || time == 1.06) //Single
                    {
                        gameScoreing.IncreasePlayerHomeHits();
                        HomeSingle(basesOccupied);
                        outcome = "single!!";                        
                    }
                    else if(time == 0.96 || time == 0.97 || time == 1.03 || time == 1.04) //Double
                    {
                        gameScoreing.IncreasePlayerHomeHits();
                        HomeDouble(basesOccupied);
                        outcome = "double!!";                        
                    }
                    else if(time == 0.98 || time == 0.99 || time == 1.01 || time == 1.02) //Triple
                    {
                        gameScoreing.IncreasePlayerHomeHits();
                        HomeTriple(basesOccupied);
                        outcome = "triple!!";
                    }
                    else //Homerun
                    {
                        gameScoreing.IncreasePlayerHomeHits();
                        HomeHomeRun(basesOccupied);
                        outcome = "homerun!!";
                    }
                    return outcome;
                case 4:
                    if(time < 0.90 || time > 1.10) //Out
                    {
                        gameScoreing.SetOuts(gameScoreing.GetOuts()+1);
                        outcome = "out!!";
                    }
                    else if(time >= 0.90 && time <= 0.92 || time >= 1.08 && time <= 1.10) //Single
                    {
                        gameScoreing.IncreasePlayerHomeHits();
                        HomeSingle(basesOccupied);
                        outcome = "single!!";                        
                    }
                    else if(time >= 0.93 && time <= 0.95 || time >= 1.05 && time <= 1.07) //Double
                    {
                        gameScoreing.IncreasePlayerHomeHits();
                        HomeDouble(basesOccupied);
                        outcome = "double!!";                        
                    }
                    else if(time >= 0.96 && time <= 0.98 || time >= 1.02 && time <= 1.04) //Triple
                    {
                        gameScoreing.IncreasePlayerHomeHits();
                        HomeTriple(basesOccupied);
                        outcome = "triple!!";
                    }
                    else //Homerun
                    {
                        gameScoreing.IncreasePlayerHomeHits();
                        HomeHomeRun(basesOccupied);
                        outcome = "homerun!!";
                    }
                    return outcome;
                case 5:
                    if(time < 0.76 || time > 1.24) //Out
                    {
                        gameScoreing.SetOuts(gameScoreing.GetOuts()+1);
                        outcome = "out!!";
                    }
                    else if(time >= 0.83 && time <= 0.87 || time >= 1.13 && time <= 1.17) //Single
                    {
                        gameScoreing.IncreasePlayerHomeHits();
                        HomeSingle(basesOccupied);
                        outcome = "single!!";
                    }
                    else if(time >= 0.88 && time <= 0.92 || time >= 1.08 && time <= 1.12) //Double
                    {
                        gameScoreing.IncreasePlayerHomeHits();
                        HomeDouble(basesOccupied);
                        outcome = "double!!";
                    }
                    else if(time >= 0.93 && time <= 0.97 || time >= 1.03 && time <= 1.07) //Triple
                    {
                        gameScoreing.IncreasePlayerHomeHits();
                        HomeTriple(basesOccupied);
                        outcome = "triple!!";
                    }
                    else //Homerun
                    {
                        gameScoreing.IncreasePlayerHomeHits();
                        HomeHomeRun(basesOccupied);
                        outcome = "homerun!!";
                    }
                    break;
                case 6:
                    if(time < 0.76 || time > 1.24) //Out
                    {
                        gameScoreing.SetOuts(gameScoreing.GetOuts()+1);
                        outcome = "out!!";
                    }
                    else if(time >= 0.76 && time <= 0.82 || time >= 1.18 && time <= 1.24) //Single
                    {
                        gameScoreing.IncreasePlayerHomeHits();
                        HomeSingle(basesOccupied);
                        outcome = "single!!";
                    }
                    else if(time >= 0.83 && time <= 0.89 || time >= 1.11 && time <= 1.17) //Double
                    {
                        gameScoreing.IncreasePlayerHomeHits();
                        HomeDouble(basesOccupied);
                        outcome = "double!!";
                    }
                    else if(time >= 0.90 && time <= 0.96 || time >= 1.04 && time <= 1.10) //Triple
                    {
                        gameScoreing.IncreasePlayerHomeHits();
                        HomeTriple(basesOccupied);
                        outcome = "triple!!";
                    }
                    else //Homerun
                    {
                        gameScoreing.IncreasePlayerHomeHits();
                        HomeHomeRun(basesOccupied);
                        outcome = "homerun!!";
                    }
                    return outcome;
                case 7:
                    if(time < 0.69 || time > 1.31) //Out
                    {
                        gameScoreing.SetOuts(gameScoreing.GetOuts()+1);
                        outcome = "out!!";
                    }
                    else if(time >= 0.69 && time <= 0.77 || time >= 1.23 && time <= 1.31) //Single
                    {
                        gameScoreing.IncreasePlayerHomeHits();
                        HomeSingle(basesOccupied);
                        outcome = "single!!";                        
                    }
                    else if(time >= 0.78 && time <= 0.86 || time >= 1.14 && time <= 1.22) //Double
                    {
                        gameScoreing.IncreasePlayerHomeHits();
                        HomeDouble(basesOccupied);
                        outcome = "double!!";                        
                    }
                    else if(time >= 0.87 && time <= 0.95 || time >= 1.05 && time <= 1.13) //Triple
                    {
                        gameScoreing.IncreasePlayerHomeHits();
                        HomeTriple(basesOccupied);
                        outcome = "triple!!";
                    }
                    else //Homerun
                    {
                        gameScoreing.IncreasePlayerHomeHits();
                        HomeHomeRun(basesOccupied);
                        outcome = "homerun!!";
                    }
                    return outcome;
            }
            return outcome;
        }   
        public void GuestSingle(int basesOccupied)
        {
            if(basesOccupied == 0) //No runners on
            {
                gameScoreing.SetBasesOcupied(1);
            }
            else if(basesOccupied == 1) //Runner on first
            {
                gameScoreing.SetBasesOcupied(6);
            }
            else if(basesOccupied == 5) //Runner on second
            {
                gameScoreing.SetBasesOcupied(11);
            }
            else if(basesOccupied == 10) //Runner on third
            {
                gameScoreing.IncreasePlayerGuestRuns();
                gameScoreing.IncreasePlayerGuestInningRuns();
                gameScoreing.SetBasesOcupied(1);
            }
            else if(basesOccupied == 6) //Runner on first and second
            {
               gameScoreing.SetBasesOcupied(16);
            }
            else if(basesOccupied == 11) //Runner on first and third
            {
                gameScoreing.IncreasePlayerGuestRuns();
                gameScoreing.IncreasePlayerGuestInningRuns();
                gameScoreing.SetBasesOcupied(16);
            }
            else if(basesOccupied == 15) //Runner on second and third
            {
                gameScoreing.IncreasePlayerGuestRuns();
                gameScoreing.IncreasePlayerGuestInningRuns();
                gameScoreing.SetBasesOcupied(11);
            }
            else //Bases loaded
            {
                gameScoreing.IncreasePlayerGuestRuns();
                gameScoreing.IncreasePlayerGuestInningRuns();
                gameScoreing.SetBasesOcupied(16);
            }
        }
        public void HomeSingle(int basesOccupied)
        {
            if(basesOccupied == 0) //No runners on
            {
                gameScoreing.SetBasesOcupied(1);
            }
            else if(basesOccupied == 1) //Runner on first
            {
                gameScoreing.SetBasesOcupied(6);
            }
            else if(basesOccupied == 5) //Runner on second
            {
                gameScoreing.SetBasesOcupied(11);
            }
            else if(basesOccupied == 10) //Runner on third
            {
                gameScoreing.IncreasePlayerHomeRuns();
                gameScoreing.IncreasePlayerHomeInningRuns();
                gameScoreing.SetBasesOcupied(1);
            }
            else if(basesOccupied == 6) //Runner on first and second
            {
               gameScoreing.SetBasesOcupied(16);
            }
            else if(basesOccupied == 11) //Runner on first and third
            {
                gameScoreing.IncreasePlayerHomeRuns();
                gameScoreing.IncreasePlayerHomeInningRuns();
                gameScoreing.SetBasesOcupied(16);
            }
            else if(basesOccupied == 15) //Runner on second and third
            {
                gameScoreing.IncreasePlayerHomeRuns();
                gameScoreing.IncreasePlayerHomeInningRuns();
                gameScoreing.SetBasesOcupied(11);
            }
            else //Bases loaded
            {
                gameScoreing.IncreasePlayerHomeRuns();
                gameScoreing.IncreasePlayerHomeInningRuns();
                gameScoreing.SetBasesOcupied(16);
            }
        }
        public void GuestDouble(int basesOccupied)
        {
            if(basesOccupied == 0) //No runners on
            {
                gameScoreing.SetBasesOcupied(5);
            }
            else if(basesOccupied == 1) //Runner on first
            {
                gameScoreing.SetBasesOcupied(15);
            }
            else if(basesOccupied == 5) //Runner on second
            {
                gameScoreing.IncreasePlayerGuestRuns();
                gameScoreing.IncreasePlayerGuestInningRuns();
                gameScoreing.SetBasesOcupied(5);
            }
            else if(basesOccupied == 10) //Runner on third
            {
                gameScoreing.IncreasePlayerGuestRuns();
                gameScoreing.IncreasePlayerGuestInningRuns();
                gameScoreing.SetBasesOcupied(5);
                // basesOccupied = 5;
            }
            else if(basesOccupied == 6) //Runner on first and second
            {
                gameScoreing.IncreasePlayerGuestRuns();
                gameScoreing.IncreasePlayerGuestInningRuns();
                gameScoreing.SetBasesOcupied(15);
                // basesOccupied = 15;
            }
            else if(basesOccupied == 11) //Runner on first and third
            {
                gameScoreing.IncreasePlayerGuestRuns();
                gameScoreing.IncreasePlayerGuestInningRuns();
                gameScoreing.SetBasesOcupied(15);
            }
            else if(basesOccupied == 15) //Runner on second and third
            {
                for(int i = 0; i < 2; i++)
                {
                    gameScoreing.IncreasePlayerGuestRuns();
                    gameScoreing.IncreasePlayerGuestInningRuns();
                }
                gameScoreing.SetBasesOcupied(5);
            }
            else //Bases loaded
            {
                for(int i = 0; i < 2; i++)
                {
                    gameScoreing.IncreasePlayerGuestRuns();
                    gameScoreing.IncreasePlayerGuestInningRuns();
                }
                gameScoreing.SetBasesOcupied(15);
            }
        }
        public void HomeDouble(int basesOccupied)
        {
            if(basesOccupied == 0) //No runners on
            {
                gameScoreing.SetBasesOcupied(5);
            }
            else if(basesOccupied == 1) //Runner on first
            {
                gameScoreing.SetBasesOcupied(15);
            }
            else if(basesOccupied == 5) //Runner on second
            {
                gameScoreing.IncreasePlayerHomeRuns();
                gameScoreing.IncreasePlayerHomeInningRuns();
                gameScoreing.SetBasesOcupied(5);
            }
            else if(basesOccupied == 10) //Runner on third
            {
                gameScoreing.IncreasePlayerHomeRuns();
                gameScoreing.IncreasePlayerHomeInningRuns();
                gameScoreing.SetBasesOcupied(5);
                // basesOccupied = 5;
            }
            else if(basesOccupied == 6) //Runner on first and second
            {
                gameScoreing.IncreasePlayerHomeRuns();
                gameScoreing.IncreasePlayerHomeInningRuns();
                gameScoreing.SetBasesOcupied(15);
                // basesOccupied = 15;
            }
            else if(basesOccupied == 11) //Runner on first and third
            {
                gameScoreing.IncreasePlayerHomeRuns();
                gameScoreing.IncreasePlayerHomeInningRuns();
                gameScoreing.SetBasesOcupied(15);
            }
            else if(basesOccupied == 15) //Runner on second and third
            {
                for(int i = 0; i < 2; i++)
                {
                    gameScoreing.IncreasePlayerHomeRuns();
                    gameScoreing.IncreasePlayerHomeInningRuns();
                }
                gameScoreing.SetBasesOcupied(5);
            }
            else //Bases loaded
            {
                for(int i = 0; i < 2; i++)
                {
                    gameScoreing.IncreasePlayerHomeRuns();
                    gameScoreing.IncreasePlayerHomeInningRuns();
                }
                gameScoreing.SetBasesOcupied(15);
            }
        }
        public void GuestTriple(int basesOccupied)
        {
            if(basesOccupied == 0) //No runners on
            {
                gameScoreing.SetBasesOcupied(10);
            }
            else if(basesOccupied == 1) //Runner on first
            {
                gameScoreing.IncreasePlayerGuestRuns();
                gameScoreing.IncreasePlayerGuestInningRuns();
                gameScoreing.SetBasesOcupied(10);
            }
            else if(basesOccupied == 5) //Runner on second
            {
                gameScoreing.IncreasePlayerGuestRuns();
                gameScoreing.IncreasePlayerGuestInningRuns();
                gameScoreing.SetBasesOcupied(10);
            }
            else if(basesOccupied == 10) //Runner on third
            {
                gameScoreing.IncreasePlayerGuestRuns();
                gameScoreing.IncreasePlayerGuestInningRuns();
                gameScoreing.SetBasesOcupied(10);
            }
            else if(basesOccupied == 6) //Runner on first and second
            {
                for(int i = 0; i < 2; i++)
                {
                    gameScoreing.IncreasePlayerGuestRuns();
                    gameScoreing.IncreasePlayerGuestInningRuns();
                }
                gameScoreing.SetBasesOcupied(10);
            }
            else if(basesOccupied == 11) //Runner on first and third
            {
                for(int i = 0; i < 2; i++)
                {
                    gameScoreing.IncreasePlayerGuestRuns();
                    gameScoreing.IncreasePlayerGuestInningRuns();
                }
                gameScoreing.SetBasesOcupied(10);
            }
            else if(basesOccupied == 15) //Runner on second and third
            {
                for(int i = 0; i < 2; i++)
                {
                    gameScoreing.IncreasePlayerGuestRuns();
                    gameScoreing.IncreasePlayerGuestInningRuns();
                }
                gameScoreing.SetBasesOcupied(10);
            }
            else if(basesOccupied == 16) //Bases loaded
            {
                for(int i = 0; i < 3; i++)
                {
                    gameScoreing.IncreasePlayerGuestRuns();
                    gameScoreing.IncreasePlayerGuestInningRuns();
                }
                gameScoreing.SetBasesOcupied(10);
            }
        }
        public void HomeTriple(int basesOccupied)
        {
            if(basesOccupied == 0) //No runners on
            {
                gameScoreing.SetBasesOcupied(10);
            }
            else if(basesOccupied == 1) //Runner on first
            {
                gameScoreing.IncreasePlayerHomeRuns();
                gameScoreing.IncreasePlayerHomeInningRuns();
                gameScoreing.SetBasesOcupied(10);
            }
            else if(basesOccupied == 5) //Runner on second
            {
                gameScoreing.IncreasePlayerHomeRuns();
                gameScoreing.IncreasePlayerHomeInningRuns();
                gameScoreing.SetBasesOcupied(10);
            }
            else if(basesOccupied == 10) //Runner on third
            {
                gameScoreing.IncreasePlayerHomeRuns();
                gameScoreing.IncreasePlayerHomeInningRuns();
                gameScoreing.SetBasesOcupied(10);
            }
            else if(basesOccupied == 6) //Runner on first and second
            {
                for(int i = 0; i < 2; i++)
                {
                    gameScoreing.IncreasePlayerHomeRuns();
                    gameScoreing.IncreasePlayerHomeInningRuns();
                }
                gameScoreing.SetBasesOcupied(10);
            }
            else if(basesOccupied == 11) //Runner on first and third
            {
                for(int i = 0; i < 2; i++)
                {
                    gameScoreing.IncreasePlayerHomeRuns();
                    gameScoreing.IncreasePlayerHomeInningRuns();
                }
                gameScoreing.SetBasesOcupied(10);
            }
            else if(basesOccupied == 15) //Runner on second and third
            {
                for(int i = 0; i < 2; i++)
                {
                    gameScoreing.IncreasePlayerHomeRuns();
                    gameScoreing.IncreasePlayerHomeInningRuns();
                }
                gameScoreing.SetBasesOcupied(10);
            }
            else if(basesOccupied == 16) //Bases loaded
            {
                for(int i = 0; i < 3; i++)
                {
                    gameScoreing.IncreasePlayerHomeRuns();
                    gameScoreing.IncreasePlayerHomeInningRuns();
                }
                gameScoreing.SetBasesOcupied(10);
            }
        }
        public void GuestHomeRun(int basesOccupied)
        {
            if(basesOccupied == 0) //No runners on
            {
                gameScoreing.IncreasePlayerGuestRuns();
                gameScoreing.IncreasePlayerGuestInningRuns();
                gameScoreing.SetBasesOcupied(0);
            }
            else if(basesOccupied == 1 || basesOccupied == 5 || basesOccupied == 10) //1 runner on
            {
                for(int i = 0; i < 2; i++)
                {
                    gameScoreing.IncreasePlayerGuestRuns();
                    gameScoreing.IncreasePlayerGuestInningRuns();
                }
                gameScoreing.SetBasesOcupied(0);
            }
            
            else if(basesOccupied == 6) //2 runners on
            {
                for(int i = 0; i < 3; i++)
                {
                    gameScoreing.IncreasePlayerGuestRuns();
                    gameScoreing.IncreasePlayerGuestInningRuns();
                }
                gameScoreing.SetBasesOcupied(0);
            }
            else //Bases loaded
            {
                for(int i = 0; i < 4; i++)
                {
                    gameScoreing.IncreasePlayerGuestRuns();
                    gameScoreing.IncreasePlayerGuestInningRuns();
                }
                gameScoreing.SetBasesOcupied(0);
            }
        }
        public void HomeHomeRun(int basesOccupied)
        {
            if(basesOccupied == 0) //No runners on
            {
                gameScoreing.IncreasePlayerHomeRuns();
                gameScoreing.IncreasePlayerHomeInningRuns();
                gameScoreing.SetBasesOcupied(0);
            }
            else if(basesOccupied == 1 || basesOccupied == 5 || basesOccupied == 10) //1 runner on
            {
                for(int i = 0; i < 2; i++)
                {
                    gameScoreing.IncreasePlayerHomeRuns();
                    gameScoreing.IncreasePlayerHomeInningRuns();
                }
                gameScoreing.SetBasesOcupied(0);
            }
            
            else if(basesOccupied == 6) //2 runners on
            {
                for(int i = 0; i < 3; i++)
                {
                    gameScoreing.IncreasePlayerHomeRuns();
                    gameScoreing.IncreasePlayerHomeInningRuns();
                }
                gameScoreing.SetBasesOcupied(0);
            }
            else //Bases loaded
            {
                for(int i = 0; i < 4; i++)
                {
                    gameScoreing.IncreasePlayerHomeRuns();
                    gameScoreing.IncreasePlayerHomeInningRuns();
                }
                gameScoreing.SetBasesOcupied(0);
            }
        }
        public GameFile SetFile(int difficulty)
        {
            switch(difficulty)
            {
                case 1:
                    GameFile majorLeagueFile = new GameFile("Leaderboards/majorleague.txt");
                    return majorLeagueFile;
                case 2:
                    GameFile minorLeagueFile = new GameFile("Leaderboards/minorleague.txt");
                    return minorLeagueFile;
                case 3:
                    GameFile varsityFile = new GameFile("Leaderboards/varsity.txt");
                    return varsityFile;
                case 4:
                    GameFile juniorVarsityFile = new GameFile("Leaderboards/juniorvarsity.txt");
                    return juniorVarsityFile;
                case 5:
                    GameFile littleLeagueFile = new GameFile("Leaderboards/littleleague.txt");
                    return littleLeagueFile;
                case 6:
                    GameFile kidsPitchFile = new GameFile("Leaderboards/kidspitch.txt");
                    return kidsPitchFile;
                case 7:
                    GameFile teeBallFile = new GameFile("Leaderboards/teeball.txt");
                    return teeBallFile;
            }
            return gameFile;
        }
    }
}