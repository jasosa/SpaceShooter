using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Entities
{
    public class Score
    {
        private int scorePoints = 0;

        public void AddScore(int points)
        {
            scorePoints += points;
        }

        public int GetPoints()
        {
            return scorePoints;
        }

        public void Reset()
        {
            scorePoints = 0;
        }
    }
}
