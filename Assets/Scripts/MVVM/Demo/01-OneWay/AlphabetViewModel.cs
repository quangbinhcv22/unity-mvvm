using System;
using System.Threading.Tasks;
using UnityEngine;
using Random = System.Random;

namespace MVVM.Demo
{
    [Binding]
    public class AlphabetViewModel : IBindingEvent
    {
        public BindingEvent BindingEvent { get; set; }


        [SerializeField] private char _alphabet;

        [Binding]
        public char Alphabet
        {
            get => _alphabet;
            set
            {
                _alphabet = value;
                BindingEvent.Invoke(nameof(Alphabet));
            }
        }


        public AlphabetViewModel()
        {
            BindingEvent = new();
            StartCycle();
        }


        private async void StartCycle()
        {
            while (true)
            {
                await Task.Delay(TimeSpan.FromSeconds(1));
                Alphabet = GetRandomAlphabet();
            }
        }

        private static char GetRandomAlphabet()
        {
            return (char) new Random().Next('A', 'Z');
        }
    }
}