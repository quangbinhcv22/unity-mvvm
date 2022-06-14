using System;
using UnityEngine;

namespace MVVM.Demo
{
    [Binding, Serializable]
    public class NumberViewModel : IBindingEvent
    {
        [SerializeField] private int number;

        [Binding]
        public int Number
        {
            get => number;
            set
            {
                number = value;
                BindingEvent.Invoke(nameof(Number));
            }
        }

        public BindingEvent BindingEvent { get; set; }

        public NumberViewModel()
        {
            BindingEvent = new();
        }
    }
}