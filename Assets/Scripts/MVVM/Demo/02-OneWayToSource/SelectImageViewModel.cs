using System;
using UnityEngine;

namespace MVVM.Demos
{
    [Binding, Serializable]
    public class SelectImageViewModel : IBindingEvent
    {
        [SerializeField] private Sprite avatar;

        [Binding]
        public Sprite Avatar
        {
            get => avatar;
            set
            {
                avatar = value;
                BindingEvent.Invoke(nameof(Avatar));
            }
        }

        public BindingEvent BindingEvent { get; set; }
        
        public SelectImageViewModel()
        {
            BindingEvent = new BindingEvent();
        }
    }
}