using UnityEngine;

namespace MVVM.Demo._02_OneWayToSource
{
    [DefaultExecutionOrder(-1000)]
    public class Scaler : MonoBehaviour
    {
        private Vector3 _startScale;

        public float Factor
        {
            get => 1f;
            set => transform.localScale = _startScale * value;
        }

        private void Awake()
        {
            _startScale = transform.localScale;
        }
    }
}