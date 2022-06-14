using Sirenix.OdinInspector;
using UnityEngine;

namespace MVVM
{
    public class BindingModelViewEvent : MonoBehaviour
    {
        [Header("When Changed"), HideLabel, SerializeField]
        private ViewModelProperty viewModelProperty;

        [Header("Invoke"), HideLabel, SerializeField]
        private ComponentMethod destMethod;


        private EventWatcher _watcher;

        private void Awake()
        {
            _watcher = viewModelProperty.ToWatcher(destMethod.ToEndPoint().Invoke);
        }

        private void OnEnable()
        {
            _watcher.Watch();
        }

        private void OnDisable()
        {
            _watcher.Dispose();
        }
    }
}