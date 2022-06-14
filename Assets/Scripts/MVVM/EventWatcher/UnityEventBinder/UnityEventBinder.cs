using System;
using UnityEngine.Events;

namespace MVVM
{
    internal class UnityEventBinder : UnityEventBinderBase
    {
        private readonly UnityEvent _unityEvent;
        private readonly Action _action;

        public UnityEventBinder(UnityEventBase unityEvent, Action action)
        {
            _unityEvent = (UnityEvent) unityEvent;
            _unityEvent.AddListener(HandleEvent);

            _action = action;
        }

        public override void Dispose()
        {
            _unityEvent.RemoveListener(HandleEvent);
        }

        private void HandleEvent()
        {
            _action();
        }
    }

    internal class UnityEventBinder<T0> : UnityEventBinderBase
    {
        private readonly UnityEvent<T0> _unityEvent;
        private readonly Action _action;

        public UnityEventBinder(UnityEventBase unityEvent, Action action)
        {
            _unityEvent = (UnityEvent<T0>) unityEvent;
            _unityEvent.AddListener(HandleEvent);

            _action = action;
        }

        public override void Dispose()
        {
            _unityEvent.RemoveListener(HandleEvent);
        }

        private void HandleEvent(T0 arg1)
        {
            _action();
        }
    }

    internal class UnityEventBinder<T0, T1> : UnityEventBinderBase
    {
        private readonly UnityEvent<T0, T1> _unityEvent;
        private readonly Action _action;

        public UnityEventBinder(UnityEventBase unityEvent, Action action)
        {
            _unityEvent = (UnityEvent<T0, T1>) unityEvent;
            _unityEvent.AddListener(HandleEvent);

            _action = action;
        }

        public override void Dispose()
        {
            _unityEvent.RemoveListener(HandleEvent);
        }

        private void HandleEvent(T0 arg1, T1 arg2)
        {
            _action();
        }
    }
}