using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.Events;

namespace Assets.Scripts.UnityEvents
{
    [Serializable]
    public class AsteroidDestructionEvent : UnityEvent<string>
    {
    }
}
