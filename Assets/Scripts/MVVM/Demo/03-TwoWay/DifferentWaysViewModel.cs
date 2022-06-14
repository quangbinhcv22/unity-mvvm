using System;
using UnityEngine;

namespace MVVM.Demo
{
    [Binding, Serializable]
    public class DifferentWaysViewModel : IBindingEvent
    {
        [SerializeField] private float slideValue;

        [Binding]
        public float SlideValue
        {
            get => slideValue;
            set
            {
                slideValue = value;
                BindingEvent.Invoke(nameof(SlideValue));
            }
        }

        public BindingEvent BindingEvent { get; set; }

        public DifferentWaysViewModel()
        {
            BindingEvent = new();
        }
    }
}