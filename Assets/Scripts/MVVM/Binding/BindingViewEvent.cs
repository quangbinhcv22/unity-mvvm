using Sirenix.OdinInspector;
using UnityEngine;

namespace MVVM
{
    public class BindingViewEvent : MonoBehaviour
    {
        [Header("When"), HideLabel, SerializeField]
        private ComponentUnityEvent destEvent;

        [Header("Invoke"), HideLabel, SerializeField]
        private ViewModelMethod viewModel;

        private EventWatcher _watcher;

        private void Awake()
        {
            _watcher = destEvent.ToWatcher(viewModel.ToEndPoint().Invoke);
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