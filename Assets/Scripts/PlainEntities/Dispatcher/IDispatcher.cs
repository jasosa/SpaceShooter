using System;

namespace Assets.Scripts.PlainEntities.Dispatcher
{
    public interface IDispatcher
    {
        void Enqueue(Action fn);
        void InvokeAll();
    }
}
