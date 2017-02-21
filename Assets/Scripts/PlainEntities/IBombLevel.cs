using System;

namespace Assets.Scripts.PlainEntities
{
    public interface IBombLevel
    {
        int BombLevel { get; set; }

        void DeactivateBomb();

        event EventHandler onBombActivated;
    }
}