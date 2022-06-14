using MVVM;
using UnityEngine;

[Binding]
public class BlockViewModel : MonoBehaviour, IBindingEvent
{
    [SerializeField] private float sliderValue;

    [Binding]
    public float SliderValue
    {
        get => sliderValue;
        set
        {
            sliderValue = value;
            BindingEvent.Invoke(nameof(SliderValue));
        }
    }

    public BindingEvent BindingEvent { get; set; }
}