using System.Collections.Generic;
using MVVM;

[Binding]
public class CollectionModel : IBindingEvent
{
    public BindingEvent BindingEvent { get; set; }


    private List<int> _scores;

    [Binding]
    public List<int> Scores
    {
        get => _scores;
        set
        {
            _scores = value;
            BindingEvent?.Invoke(nameof(Scores));
        }
    }

    public CollectionModel()
    {
        BindingEvent = new BindingEvent();
        Scores = new List<int> {1, 2, 3, 4, 5, 6};
    }
}