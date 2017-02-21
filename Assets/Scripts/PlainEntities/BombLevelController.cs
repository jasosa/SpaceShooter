using System;
using System.Threading;

namespace Assets.Scripts.PlainEntities
{
    public class BombLevelController
    {
        public event EventHandler onBombActivated;

        public int BombLevel { get; set; }

        public BombLevelController()
        {
            BombLevel = 100;
        }

        public void DeactivateBomb()
        {
            BombLevel = 0;
            ThreadStart ts = new ThreadStart(Recharging);
            Thread thread = new Thread(ts);
            thread.Start();
        }

        private void Recharging()
        {
            for (int i = 0; BombLevel < 100; i++)
            {
                BombLevel = i*20;
                Thread.Sleep(1000);
            }

            if (onBombActivated != null)
                onBombActivated.Invoke(this, new EventArgs());
        }
    }
}
