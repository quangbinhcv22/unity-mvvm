using System;
using System.Threading.Tasks;

namespace MVVM.Demo
{
    [Binding]
    public class ClockViewModel : IBindingEvent
    {
        private static readonly TimeSpan OneSecond = TimeSpan.FromSeconds(1);

        [Binding] public DateTime UtcTime => DateTime.UtcNow;
        public BindingEvent BindingEvent { get; set; }


        private bool _isCounting;


        public ClockViewModel()
        {
            BindingEvent = new() {OnStartBinding = OnStartBinding, OnEndBinding = OnEndBinding};
        }

        private async void OnStartBinding()
        {
            if (_isCounting) return;

            _isCounting = true;

            while (_isCounting)
            {
                await Task.Delay(OneSecond);
                BindingEvent.Invoke(nameof(UtcTime));
            }
        }

        private void OnEndBinding()
        {
            _isCounting = false;
        }
    }
}