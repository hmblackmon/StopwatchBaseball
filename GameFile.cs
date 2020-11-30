using System;
using System.IO;

namespace StopwatchBaseball
{
    public class GameFile
    {
        private string difficultyFileName;
        private int[] myScores;
        private string[] myNames;
        
        public GameFile()
        {

        }
        public GameFile(string difficultyFileName)
        {
            this.difficultyFileName = difficultyFileName;
        }

        public void SetGameFileName(string difficultyFileName)
        {
            this.difficultyFileName = difficultyFileName;
        }

        public string GetGameFileName()
        {
            return difficultyFileName;
        }
        public void SetScores(int[] myScores)
        {
            this.myScores = myScores;
        }
        public int[] GetScores()
        {
            return myScores;
        }
        public void SetNames(string[] myNames)
        {
            this.myNames = myNames;
        }
        public string[] GetNames()
        {
            return myNames;
        }

        public int[] GetAllScores()
        {
            myScores = new int[3];
            myNames = new string[3];
            StreamReader file = new StreamReader(difficultyFileName);
            int i = 0;
            string input = file.ReadLine();
            while(input != null)
            {
                string[] temp = input.Split('#');
                myNames[i] = temp[0];
                myScores[i] = int.Parse(temp[1]);
                input = file.ReadLine();
                i++;
            }
            file.Close();

            return myScores;
        }

        public void SaveAllScores()
        {
            
            StreamWriter file = new StreamWriter(difficultyFileName);
            for(int i = 0; i < 3; i++)
            {
                file.WriteLine($"{myNames[i]}#{myScores[i]}");
            }
            file.Close();
        }

        public int HighScoreSearch(int score)
        {
            int j = -1;
            if(score > myScores[2])
            {
                myScores[2] = score;
                Console.Write($"New high score of {score}!!\nEnter your name:\t");
                myNames[2] = Console.ReadLine();
                
                for(int i = 0; i < 3-1; i++)
                {
                    int min = i;

                    for(j = i+1; j < 3; j++)
                    {
                        if(myScores[j] < myScores[min])
                        {
                            min = j;
                        }
                    }
                    if(min != i)
                    {
                        Swap(myScores, min, i);
                        Swap(myNames, min, i);
                    }
                }
            }
            Swap(myNames, 0, 2);
            Swap(myScores, 0, 2);
            return j;
        }
        public void Swap(string[] myNames, int x, int y)
        {
            string temp = myNames[x];
            myNames[x] = myNames[y];
            myNames[y] = temp;
        }
        public void Swap(int[] myScores, int x, int y)
        {
            int temp = myScores[x];
            myScores[x] = myScores[y];
            myScores[y] = temp;
        }

        public void ReadHighScores()
        {
            myScores = new int[3];
            myNames = new string[3];
            StreamReader file = new StreamReader(difficultyFileName);
            int i = 0;
            string input = file.ReadLine();
            while(input != null)
            {
                string[] temp = input.Split('#');
                myNames[i] = temp[0];
                myScores[i] = int.Parse(temp[1]);
                Console.WriteLine($"{myNames[i]}\t{myScores[i]}");
                input = file.ReadLine();
                i++;
            }
            file.Close();
        }
    }
}