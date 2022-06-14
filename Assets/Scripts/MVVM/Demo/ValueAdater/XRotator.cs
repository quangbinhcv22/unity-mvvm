using UnityEngine;

namespace MVVM.Demo._02_OneWayToSource
{
    [DefaultExecutionOrder(-1000)]
    public class XRotator : MonoBehaviour
    {
        private const float EulerUnit = 360;

        private Vector3 _startEuler;

        public float Factor
        {
            get => 1f;
            set => transform.rotation = Quaternion.Euler(value * EulerUnit, _startEuler.y, _startEuler.z);
        }

        private void Awake()
        {
            _startEuler = transform.rotation.eulerAngles;
        }
    }
}