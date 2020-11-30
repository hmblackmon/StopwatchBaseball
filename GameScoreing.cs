namespace StopwatchBaseball
{
    public class GameScoreing
    {
        private int outs;
        private int basesOccupied;
        private int inning;
        private string playerHomeRuns;
        private string playerHomeHits;
        private string[] playerHomeInningRuns;
        private string playerGuestRuns;
        private string playerGuestHits;
        private string[] playerGuestInningRuns;
        private string[] basesAnimation;


        public GameScoreing(int outs, int basesOccupied, int inning, string playerHomeRuns, string playerHomeHits, string[] playerHomeInningRuns, string playerGuestRuns, string playerGuestHits, string[] playerGuestInningRuns, string[] basesAnimation)

        {
            this.outs = outs;
            this.basesOccupied = basesOccupied;
            this.inning = inning;
            this.playerHomeRuns = playerHomeRuns;
            this.playerHomeHits = playerHomeHits;
            this.playerHomeInningRuns = playerHomeInningRuns;
            this.playerGuestRuns = playerGuestRuns;
            this.playerGuestHits = playerGuestHits;
            this.playerGuestInningRuns = playerGuestInningRuns;
            this.basesAnimation = basesAnimation;
        }

        public void SetOuts(int outs)
        {
            this.outs = outs;
        }
        public int GetOuts()
        {
            return outs;
        }
        public void SetBasesOcupied(int basesOccupied)
        {
            this.basesOccupied = basesOccupied;
        }
        public int GetBasesOcupied()
        {
            return basesOccupied;
        }
        public void SetInning(int inning)
        {
            this.inning = inning;
        }
        public int GetInning()
        {
            return inning;
        }
        public void SetPlayerHomeRuns(string playerHomeRuns)
        {
            this.playerHomeRuns = playerHomeRuns;
        }
        public string GetPlayerHomeRuns()
        {
            return playerHomeRuns;
        }
        public void SetPlayerHomeHits(string playerHomeHits)
        {
            this.playerHomeHits = playerHomeHits;
        }
        public string GetPlayerHomeHits()
        {
            return playerHomeHits;
        }
        public void SetPlayerHomeInningRuns(string[] playerHomeInningRuns)
        {
            this.playerHomeInningRuns = playerHomeInningRuns;
        }
        public string[] GetPlayerHomeInningRuns()
        {
            return playerHomeInningRuns;
        }
        public void SetPlayerGuestRuns(string playerGuestRuns)
        {
            this.playerGuestRuns = playerGuestRuns;
        }
        public string GetPlayerGuestRuns()
        {
            return playerGuestRuns;
        }
        public void SetPlayerGuestHits(string playerGuestHits)
        {
            this.playerGuestHits = playerGuestHits;
        }
        public string GetPlayerGuestHits()
        {
            return playerGuestHits;
        }
        public void SetPlayerGuestInningRuns(string[] playerGuestInningRuns)
        {
            this.playerGuestInningRuns = playerGuestInningRuns;
        }
        public string[] GetPlayerGuestInningRuns()
        {
            return playerGuestInningRuns;
        }
        public void SetBasesAnimation(string[] basesAnimation)
        {
            this.basesAnimation = basesAnimation;
        }
        public string[] GetBasesAnimation()
        {
            return basesAnimation;
        }

        public void IncreasePlayerHomeHits()
        {
            int intPlayerHomeHits = int.Parse(playerHomeHits);
            intPlayerHomeHits++;
            playerHomeHits = intPlayerHomeHits.ToString();
        }
        public void IncreasePlayerHomeRuns()
        {
            int intPlayerHomeRuns = int.Parse(playerHomeRuns);
            intPlayerHomeRuns++;
            playerHomeRuns = intPlayerHomeRuns.ToString();
        }
        public void IncreasePlayerHomeInningRuns()
        {
            if(playerHomeInningRuns[inning-1] == "")
            {
                playerHomeInningRuns[inning-1] = "1";
            }
            else
            {
                int intPlayerHomeInningRuns = int.Parse(playerHomeInningRuns[inning-1]);
                intPlayerHomeInningRuns++;
                playerHomeInningRuns[inning-1] = intPlayerHomeInningRuns.ToString();
            }
        }

        public void IncreasePlayerGuestHits()
        {
            int intPlayerGuestHits = int.Parse(playerGuestHits);
            intPlayerGuestHits++;
            playerGuestHits = intPlayerGuestHits.ToString();
        }
        public void IncreasePlayerGuestRuns()
        {
            int intPlayerGuestRuns = int.Parse(playerGuestRuns);
            intPlayerGuestRuns++;
            playerGuestRuns = intPlayerGuestRuns.ToString();
        }
        public void IncreasePlayerGuestInningRuns()
        {
            if(playerGuestInningRuns[inning-1] == "")
            {
                playerGuestInningRuns[inning-1] = "1";
            }
            else
            {
                int intPlayerGuestInningRuns = int.Parse(playerGuestInningRuns[inning-1]);
                intPlayerGuestInningRuns++;
                playerGuestInningRuns[inning-1] = intPlayerGuestInningRuns.ToString();
            }
        }


        public void ResetAfterGuestAtBat()
        {
            outs = 0;
            basesOccupied = 0;
            if(playerGuestInningRuns[inning-1] == "")
            {
                playerGuestInningRuns[inning-1] = "0";
            }
        }
        public void ResetAfterHomeAtBat()
        {
            outs = 0;
            basesOccupied = 0;
            if(playerHomeInningRuns[inning-1] == "")
            {
                playerHomeInningRuns[inning-1] = "0";
            }
        }
        public void ResetScore(int numberOfPlayers)
        {
            outs = 0;
            basesOccupied = 0;
            inning = 1;
            playerHomeRuns = "0";
            playerHomeHits = "0";
            if(numberOfPlayers == 1)
            {
                playerGuestRuns = "-";
                playerGuestHits = "-";
                for(int i = 0; i < 9; i++)
                {
                    playerGuestInningRuns[i] = "-";
                    playerHomeInningRuns[i] = "";
                }
            }
            else
            {
                playerGuestRuns = "0";
                playerGuestHits = "0";
                for(int i = 0; i < 9; i++)
                {
                    playerGuestInningRuns[i] = "";
                    playerHomeInningRuns[i] = "";
                }
            }
        }
    }
}