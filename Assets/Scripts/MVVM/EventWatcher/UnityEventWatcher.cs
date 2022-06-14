using System;
using System.Linq;
using System.Reflection;
using UnityEngine.Assertions;
using UnityEngine.Events;

namespace MVVM
{
    [Serializable]
    public sealed class UnityEventWatcher : EventWatcher
    {
        private object _owner;
        private string _eventName;
        private Action _callback;

        private UnityEventBinderBase _eventBinder;

        public UnityEventWatcher(object owner, string eventName, Action callback)
        {
            Assert.IsNotNull(owner);
            Assert.IsFalse(string.IsNullOrEmpty(eventName));
            Assert.IsNotNull(callback);

            _owner = owner;
            _eventName = eventName;
            _callback = callback;
        }

        public override void Watch()
        {
            var eventMembers = _owner.GetType().GetMember(_eventName);
            var eventMember = eventMembers.First();


            var unityEvent = eventMember.MemberType switch
            {
                MemberTypes.Field => ((FieldInfo) eventMember).GetValue(_owner) as UnityEventBase,
                MemberTypes.Property => ((PropertyInfo) eventMember).GetValue(_owner) as UnityEventBase,
                _ => null,
            };

            _eventBinder = UnityEventBinderFactory.Create(unityEvent, OnUnityEventInvoke);
        }

        public override void Dispose()
        {
            if (_eventBinder is null) return;

            _eventBinder.Dispose();
            _eventBinder = null;
        }

        public void OnUnityEventInvoke()
        {
            _callback?.Invoke();
        }
    }
}