using UnityEngine;

namespace MVVM.Demo
{
    [Binding]
    public class FpsViewModel : MonoBehaviour, IBindingEvent
    {
        [SerializeField] private float fpsText;

        [Binding]
        public float FpsText
        {
            get => fpsText;
            set
            {
                fpsText = value;
                BindingEvent.Invoke(nameof(FpsText));
            }
        }

        public BindingEvent BindingEvent { get; set; }

        public FpsViewModel()
        {
            BindingEvent = new BindingEvent();
        }

        private void Update()
        {
            FpsText = (Time.frameCount / Time.time);
        }
    }
}