using System.Collections.Generic;
using MVVM;
using Sirenix.OdinInspector;
using UnityEngine;

[DefaultExecutionOrder(9999)]
public class BindingProperty : MonoBehaviour
{
    private bool HaveSyncFromDest => mode.HaveSyncFromDest();
    private bool HaveSyncFromSource => mode.HaveSyncFromSource();


    [SerializeField] private BindingMode mode;

    [Header("View Model"), SerializeField, Space, HideLabel]
    private ViewModelProperty viewModel;

    [ShowIf(nameof(HaveSyncFromDest)), SerializeField, BoxGroup(nameof(viewModel), false)]
    private ValueConverterBase toSourceConverter;


    [Header("View"), SerializeField, Space, HideLabel]
    private ComponentProperty destView;

    [ShowIf(nameof(HaveSyncFromSource)), SerializeField, BoxGroup(nameof(ValueConverterBase), false)]
    private ValueConverterBase toDestConverter;


    [ShowIf(nameof(HaveSyncFromDest)), Header("View Event"), HideLabel, SerializeField, Space]
    private ComponentUnityEvent destEvent;


    [SerializeField, Space] private bool keepConnectOnDisable = false;


    private PropertySync _propertySync;
    private readonly List<EventWatcher> _eventWatchers = new();


    private void Awake()
    {
        _propertySync = new PropertySync(viewModel.ToEndPoint(), destView.ToEndPoint(), toSourceConverter, toDestConverter);

        if (mode.HaveSyncFromSource()) _eventWatchers.Add(viewModel.ToWatcher(_propertySync.SyncFromSource));
        if (mode.HaveSyncFromDest()) _eventWatchers.Add(destEvent.ToWatcher(_propertySync.SyncFromDest));
    }

    public void OnEnable()
    {
        if (mode.HaveSyncFromSource()) _propertySync.SyncFromSource();
        _eventWatchers.ForEach(watcher => watcher.Watch());
    }

    public void OnDisable()
    {
        if (keepConnectOnDisable) return;
        _eventWatchers.ForEach(watcher => watcher.Dispose());
    }

    public void OnDestroy()
    {
        _eventWatchers.ForEach(watcher => watcher.Dispose());
    }
}