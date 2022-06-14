#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

namespace MVVM
{
    [Serializable]
    public class ComponentProperty
    {
        [SerializeField, BoxGroup] private Component component;

        [ValueDropdown(nameof(GetAllProperties)), SerializeField, BoxGroup]
        private string propertyName;


        public PropertyEndPoint ToEndPoint()
        {
            return new PropertyEndPoint(component, propertyName);
        }


#if UNITY_EDITOR
        public List<string> GetAllProperties()
        {
            if (component is null) return new List<string>();
            return component.GetType().GetProperties().Select(property => property.Name).ToList();
        }

        [OnInspectorGUI]
        public void Validate()
        {
            if (GetAllProperties().Contains(propertyName)) return;
            propertyName = string.Empty;
        }
#endif
    }
}
#endif