namespace Assets.Scripts.PlainEntities
{
    public class ScoreUpdater : IScoreUpdater
    {
        private int scorePoints = 0;

        public void AddScore(int points)
        {
            scorePoints += points;
        }

        public int GetScore()
        {
            return scorePoints;
        }

        public void Reset()
        {
            scorePoints = 0;
        }
    }
}
