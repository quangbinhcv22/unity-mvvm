using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace MVVM
{
    [Serializable]
    public class ViewModelProperty
    {
        [ValueDropdown(nameof(GetAllModelViews)), SerializeField, BoxGroup, InlineButton(nameof(OpenAsset), "Open")]
        private string viewModelName;

        [ValueDropdown(nameof(GetAllProperties)), SerializeField, BoxGroup]
        private string propertyName;

        public object ViewModel => ViewModelProvider.Instance.GetViewModel(viewModelName);

        public PropertyEndPoint ToEndPoint()
        {
            return new PropertyEndPoint(ViewModel, propertyName);
        }

        public BindingEventWatcher ToWatcher(Action callback)
        {
            return new BindingEventWatcher(ViewModel, propertyName, callback);
        }

#if UNITY_EDITOR
        public List<string> GetAllModelViews() => MvvmUtility.GetAllModelViewsName();
        public List<string> GetAllProperties() => MvvmUtility.GetAllModelViewProperties(viewModelName);

        [OnInspectorGUI]
        public void Validate()
        {
            if (GetAllModelViews().Contains(viewModelName) is false) viewModelName = string.Empty;
            if (GetAllProperties().Contains(propertyName) is false) propertyName = string.Empty;
        }

        public void OpenAsset() => MvvmUtility.OpenViewModelAsset(viewModelName);
#endif
    }
}