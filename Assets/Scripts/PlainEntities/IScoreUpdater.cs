namespace Assets.Scripts.PlainEntities
{
    public interface IScoreUpdater
    {
        void AddScore(int points);
        int GetScore();
        void Reset();
    }
}
