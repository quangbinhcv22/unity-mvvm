using System;

namespace MVVM
{
    public abstract class EventWatcher : IDisposable
    {
        public abstract void Watch();

        public abstract void Dispose();
    }
}