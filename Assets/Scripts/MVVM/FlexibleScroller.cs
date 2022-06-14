using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class FlexibleScroller : MonoBehaviour
{
    private List<int> _data;

    public List<int> Data
    {
        get => _data;
        set
        {
            _data = value;
            ReloadScroller();
        }
    }

    public UnityEvent DataHaveChanged { get; set; }

    private void ReloadScroller()
    {
        Debug.Log("Reload Scroller");

        foreach (var item in Data)
        {
            Debug.Log(item);
        }

        Debug.Log("---------------------------------");
    }

    private void Awake()
    {
        DataHaveChanged = new UnityEvent();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Data.Clear();

            for (int i = 0; i < 10; i++)
            {
                Data.Add(Random.Range(0, 100));
            }

            DataHaveChanged?.Invoke();
        }
    }
}