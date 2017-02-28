using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.PlainEntities
{
    public static class ScoreFactory
    {
        public static ScoreUpdater score;

        public static ScoreUpdater GetScore()
        {
            if (score == null)
            {
                score = new ScoreUpdater();
            }

            return score;
        }
    }
}
