using System;
using UnityEngine.Assertions;

namespace MVVM
{
    public sealed class BindingEventWatcher : EventWatcher
    {
        private readonly object _owner;
        private readonly string _propertyName;
        private readonly Action _callback;

        private IBindingEvent _bindingEvent;


        public BindingEventWatcher(object owner, string propertyName, Action callback)
        {
            _owner = owner;
            _propertyName = propertyName;
            _callback = callback;
        }

        public override void Watch()
        {
            _bindingEvent = _owner as IBindingEvent;
            if (_bindingEvent is null) return;

            Assert.IsNotNull(_bindingEvent.BindingEvent, $"Please initialize <color=yellow>{_bindingEvent.GetType()}-{nameof(BindingEvent)}</color> before using");

            _bindingEvent.BindingEvent.Binding(OnPropertyChanged);
        }

        public override void Dispose()
        {
            if (_bindingEvent is null) return;

            Assert.IsNotNull(_bindingEvent.BindingEvent, $"Please initialize <color=yellow>{_bindingEvent.GetType()}-{nameof(BindingEvent)}</color> before using");

            _bindingEvent.BindingEvent.UnBinding(OnPropertyChanged);
            _bindingEvent = null;
        }


        private void OnPropertyChanged(string propertyChangedName)
        {
            if (_propertyName != propertyChangedName) return;
            _callback?.Invoke();
        }
    }
}