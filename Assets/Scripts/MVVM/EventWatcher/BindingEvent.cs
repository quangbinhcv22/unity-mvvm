using System;
using System.Collections.Generic;
using System.Linq;

namespace MVVM
{
    public class BindingEvent
    {
        private readonly List<Action<string>> _actions = new();

        public Action OnStartBinding;
        public Action OnEndBinding;

        public void Binding(Action<string> action)
        {
            if (_actions.Contains(action)) return;

            var isFirstAction = _actions.Any() is false;
            _actions.Add(action);

            if (isFirstAction) OnStartBinding?.Invoke();
        }

        public void UnBinding(Action<string> action)
        {
            if (_actions.Contains(action) is false) return;

            _actions.Remove(action);
            if (_actions.Any() is false) OnEndBinding?.Invoke();
        }

        public void Invoke(string propertyName)
        {
            _actions.ForEach(action => action?.Invoke(propertyName));
        }

        public bool IsBinding()
        {
            return _actions is not null && _actions.Any();
        }
    }
}