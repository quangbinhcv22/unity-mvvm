#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace MVVM
{
    [Serializable]
    public class ViewModelMethod
    {
        [ValueDropdown(nameof(GetAllModelViews)), SerializeField, BoxGroup, InlineButton(nameof(OpenAsset), "Open")]
        private string viewModelName;

        [ValueDropdown(nameof(GetAllMethods)), BoxGroup, SerializeField]
        private string methodName;


        private object ViewModel => ViewModelProvider.Instance.GetViewModel(viewModelName);


        public MethodEndPoint ToEndPoint() => new MethodEndPoint(ViewModel, methodName);

        public BindingEventWatcher ToWatcher(Action callback)
        {
            return new BindingEventWatcher(ViewModel, methodName, callback);
        }


#if UNITY_EDITOR
        public List<string> GetAllModelViews() => MvvmUtility.GetAllModelViewsName();
        public List<string> GetAllMethods() => MvvmUtility.GetAllModelViewMethods(viewModelName);


        [OnInspectorGUI]
        public void Validate()
        {
            if (GetAllModelViews().Contains(viewModelName) is false) viewModelName = string.Empty;
            if (GetAllMethods().Contains(methodName) is false) methodName = string.Empty;
        }

        public void OpenAsset() => MvvmUtility.OpenViewModelAsset(viewModelName);
#endif
    }
}
#endif