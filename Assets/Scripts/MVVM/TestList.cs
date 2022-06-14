using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TestList : MonoBehaviour
{
    [SerializeField] private ObservableList<int> ints;

    private void Start()
    {
        ints = new ObservableList<int>(new List<int> {1, 2, 3});

        // var a = ints.CollectionChanged;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ints.Add(Random.Range(0, 100));
        }
    }
}