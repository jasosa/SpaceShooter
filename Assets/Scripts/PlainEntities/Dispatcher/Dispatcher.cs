using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.PlainEntities.Dispatcher
{
    public class Dispatcher : IDispatcher
    {   
        public List<Action> pending = new List<Action>();

        public void InvokeAll()
        {
            lock (pending)
            {
                foreach (var action in pending)
                {
                    action();
                }

                pending.Clear();
            }
        }

        public void Enqueue(Action fn)
        {
            lock (pending)
            {
                pending.Add(fn);
            }
        }
    }
}
