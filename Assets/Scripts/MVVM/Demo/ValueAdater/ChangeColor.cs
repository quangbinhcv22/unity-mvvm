using UnityEngine;

namespace MVVM.Demo._02_OneWayToSource
{
    [DefaultExecutionOrder(-1000)]
    public class ChangeColor : MonoBehaviour
    {
        private Material _material;

        public float Gray
        {
            get => default;
            set => _material.color = Color.white * value;
        }

        private void Awake()
        {
            _material = GetComponent<Renderer>().material;
        }
    }
}