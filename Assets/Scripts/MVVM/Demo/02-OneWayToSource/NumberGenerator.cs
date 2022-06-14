using UnityEngine;

namespace MVVM.Demo
{
    public class NumberGenerator : MonoBehaviour
    {
        [SerializeField] private int form = 1000;
        [SerializeField] private int to = 10000;

        public int RandomNumber => Random.Range(form, to);
    }
}