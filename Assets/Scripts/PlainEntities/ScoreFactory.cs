using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Entities
{
    public static class ScoreFactory
    {
        public static Score score;

        public static Score GetScore()
        {
            if (score == null)
            {
                score = new Score();
            }

            return score;
        }
    }
}
