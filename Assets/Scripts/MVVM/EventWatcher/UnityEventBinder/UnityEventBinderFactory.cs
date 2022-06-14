using System;
using System.Linq;
using UnityEngine.Events;

namespace MVVM
{
    internal static class UnityEventBinderFactory
    {
        public static UnityEventBinderBase Create(UnityEventBase unityEvent, Action action)
        {
            var unityEventType = unityEvent.GetType().BaseType;

            if (unityEventType != null)
            {
                var genericArguments = unityEventType.GetGenericArguments();

                if (genericArguments.Any())
                {
                    var unityEventBinderType = typeof(UnityEventBinder<>).MakeGenericType(genericArguments);
                    return Activator.CreateInstance(unityEventBinderType, unityEvent, action) as UnityEventBinderBase;
                }
            }

            return new UnityEventBinder(unityEvent, action);
        }
    }
}