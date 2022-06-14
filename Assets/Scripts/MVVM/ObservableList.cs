using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

[Serializable]
public class ObservableList<T> : IList<T>, INotifyCollectionChanged
{
    private readonly List<T> _baseList = new List<T>();

    public event EventHandler<NotifyCollectionChangedEventArgs> CollectionChanged;


    public ObservableList()
    {
    }

    public ObservableList(IEnumerable<T> items)
    {
        _baseList.AddRange(items);
    }

    public IEnumerator<T> GetEnumerator() => _baseList.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public T this[int index]
    {
        get => _baseList[index];
        set => _baseList[index] = value;
    }

    public int Count => _baseList.Count;
    public bool IsReadOnly => false;
    public bool Contains(T item) => _baseList.Contains(item);
    public int IndexOf(T item) => _baseList.IndexOf(item);


    public void Add(T item)
    {
        _baseList.Add(item);
        CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add));
    }

    public void Insert(int index, T item)
    {
        _baseList.Insert(index, item);
        CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add));
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        _baseList.CopyTo(array, arrayIndex);
        CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace));
    }

    public void Clear()
    {
        _baseList.Clear();
        CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
    }

    public bool Remove(T item)
    {
        var result = _baseList.Remove(item);
        CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove));

        return result;
    }

    public void RemoveAt(int index)
    {
        _baseList.RemoveAt(index);
        CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove));
    }
}

public interface INotifyCollectionChanged
{
    event EventHandler<NotifyCollectionChangedEventArgs> CollectionChanged;
}