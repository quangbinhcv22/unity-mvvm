using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestScript : MonoBehaviour
{
    private Dictionary<int, string> a = new();
    private volatile int aa;

    private dynamic aaa;

    // Start is called before the first frame update
    void Awake()
    {
        // Debug.Log(ViewModelProvider.GetViewModelType(typeof(LoginModelView).FullName));

        // ViewModelProvider.Instance.GetViewModelInstance<LoginModelView>();
        
        // GetComponent<Toggle>().onValueChanged
    }

    // Update is called once per frame
    void Update()
    {
    }
}

[Serializable]
public struct Score
{
    public int total;

    public static Score operator +(Score a, Score b) => new Score {total = a.total + b.total};

    public override string ToString() => total.ToString();
}