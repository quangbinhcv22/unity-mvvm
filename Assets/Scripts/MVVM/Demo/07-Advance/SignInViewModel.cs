using System;
using UnityEngine;

namespace MVVM.Demo
{
    [Binding, Serializable]
    public class SignInViewModel : IBindingEvent
    {
        [SerializeField] private string name;
        [SerializeField] private int age;
        [SerializeField] private bool agreeTerms;

        [Binding]
        public string Name
        {
            get => name;
            set
            {
                if (name == value) return;

                name = value;

                BindingEvent.Invoke(nameof(Name));
                BindingEvent.Invoke(nameof(CanSign));
            }
        }

        [Binding]
        public int Age
        {
            get => age;
            set
            {
                if (age == value) return;

                age = value;

                BindingEvent.Invoke(nameof(Age));
            }
        }

        [Binding]
        public bool AgreeTerms
        {
            get => agreeTerms;
            set
            {
                if (agreeTerms == value) return;

                agreeTerms = value;

                BindingEvent.Invoke(nameof(AgreeTerms));
            }
        }


        [Binding]
        public bool CanSign
        {
            get
            {
                var haveName = string.IsNullOrEmpty(Name) is false;
                return haveName && AgreeTerms;
            }
        }


        public BindingEvent BindingEvent { get; set; }

        public SignInViewModel()
        {
            BindingEvent = new();
        }
    }
}