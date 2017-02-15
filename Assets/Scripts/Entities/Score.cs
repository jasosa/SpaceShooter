using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Entities
{
    public class Score
    {
        private int scorePoints = 0;

        public void AddScore()
        {
            scorePoints++;
        }

        public int GetPoints()
        {
            return scorePoints;
        }
    }
}
