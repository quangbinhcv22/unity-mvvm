using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

namespace MVVM
{
    [Serializable]
    public class ComponentMethod
    {
        [SerializeField, BoxGroup] public Component component;

        [ValueDropdown(nameof(GetAllMethods)), SerializeField, BoxGroup]
        public string propertyName;

        public MethodEndPoint ToEndPoint() => new MethodEndPoint(component, propertyName);


#if UNITY_EDITOR
        public List<string> GetAllMethods()
        {
            return component is null
                ? new List<string>()
                : component.GetType().GetMethods().Select(method => method.Name).ToList();
        }

        [OnInspectorGUI]
        public void Validate()
        {
            if (GetAllMethods().Contains(propertyName)) return;
            propertyName = string.Empty;
        }
#endif
    }
}