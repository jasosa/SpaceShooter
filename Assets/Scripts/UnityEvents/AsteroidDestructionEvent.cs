using System;
using UnityEngine.Events;

namespace Assets.Scripts.UnityEvents
{
    [Serializable]
    public class AsteroidDestructionEvent : UnityEvent<string>
    {
    }
}
