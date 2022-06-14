using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace MVVM
{
    [Serializable]
    public class ComponentUnityEvent
    {
        [BoxGroup, SerializeField] private Component component;

        [ValueDropdown(nameof(GetUnityEvents)), BoxGroup, SerializeField]
        public string eventName;


        public UnityEventWatcher ToWatcher(Action callback)
        {
            return new UnityEventWatcher(component, eventName, callback);
        }


#if UNITY_EDITOR
        public List<string> GetUnityEvents()
        {
            if (component is null) return new List<string>();
            return component.GetType().GetMembers()
                .Where(member => member.MemberType is MemberTypes.Property &&
                                 ((PropertyInfo) member).PropertyType.IsSubclassOf(typeof(UnityEventBase)))
                .Select(member => $"{member.Name}").ToList();
        }

        [OnInspectorGUI]
        public void Validate()
        {
            if (GetUnityEvents().Contains(eventName)) return;
            eventName = string.Empty;
        }
#endif
    }
}