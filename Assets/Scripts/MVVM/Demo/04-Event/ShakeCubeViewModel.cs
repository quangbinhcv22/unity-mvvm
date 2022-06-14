namespace MVVM.Demo
{
    [Binding]
    public class ShakeCubeViewModel : IBindingEvent
    {
        [Binding] public object OnShake { get; private set; }
        public BindingEvent BindingEvent { get; set; }

        [Binding]
        public void Shake()
        {
            BindingEvent.Invoke(nameof(OnShake));
        }

        public ShakeCubeViewModel()
        {
            BindingEvent = new();
        }
    }
}