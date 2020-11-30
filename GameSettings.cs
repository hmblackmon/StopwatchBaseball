namespace StopwatchBaseball
{
    public class GameSettings
    {
        private int numberOfPlayers;
        private int difficulty;

        public GameSettings(int numberOfPlayers, int difficulty)
        {
            this.numberOfPlayers = numberOfPlayers;
            this.difficulty = difficulty;
        }
        public void SetNumberOfPlayers(int numberOfPlayers)
        {
            this.numberOfPlayers = numberOfPlayers;
        }
        public int GetNumberOfPlayers()
        {
            return numberOfPlayers;
        }
        public void SetDifficulty(int difficulty)
        {
            this.difficulty = difficulty;
        }
        public int GetDifficulty()
        {
            return difficulty;
        }
    }
}