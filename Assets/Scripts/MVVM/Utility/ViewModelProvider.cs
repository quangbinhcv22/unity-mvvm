using System;
using System.Collections.Generic;
using Pattern;
using Sirenix.OdinInspector;
using UnityEngine;

namespace MVVM
{
    public class ViewModelProvider : Singleton<ViewModelProvider>
    {
        [ShowInInspector] private List<object> _componentViewModels = new();
        [ShowInInspector] private List<object> _pureViewModels = new();


        public object GetViewModel(string viewModelName)
        {
            var viewModelType = GetViewModelType(viewModelName);
            var isComponent = viewModelType.IsSubclassOf(typeof(Component));

            return isComponent ? GetViewModelInstance(viewModelType) : GetPureViewModel(viewModelType);
        }

        private static Type GetViewModelType(string viewModelName)
        {
            return Type.GetType(viewModelName);
        }

        private object GetViewModelInstance(Type viewModelType)
        {
            var viewModel = _componentViewModels.Find(viewModel => viewModel.GetType() == viewModelType);
            if (viewModel is null) _componentViewModels.Add(viewModel = gameObject.AddComponent(viewModelType));

            return viewModel;
        }

        private object GetPureViewModel(Type viewModelType)
        {
            var pureViewModel = _pureViewModels.Find(model => model.GetType() == viewModelType);
            if (pureViewModel is null) _pureViewModels.Add(pureViewModel = Activator.CreateInstance(viewModelType));

            return pureViewModel;
        }
    }
}