namespace MVVM.Demo
{
    [Binding]
    public class HelloWorldViewModel : IBindingEvent
    {
        public BindingEvent BindingEvent { get; set; }

        [Binding] public string HelloWorld { get; set; }


        public HelloWorldViewModel()
        {
            BindingEvent = new BindingEvent();
            HelloWorld = "Hello World!";
        }
    }
}