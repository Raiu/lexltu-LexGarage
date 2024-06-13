using System.Collections;

namespace LexGarage;

public class Catalogue<T> : IEnumerable<T>, ICollection<T>, IList<T> {

    private T[] _items;


    ////////////////////////////////////////////////////////////////////////////////

    public Catalogue() : this(0) { }

    public Catalogue(int size) {
        _items = new T[size];        
    }

    ////////////////////////////////////////////////////////////////////////////////

    // Only allow positive, maybe allow both later ChangeSize
    public void IncreaseSize(int newSize) {
        var newItems = new T[newSize];
        _items.CopyTo(newItems, 0);
        _items = newItems;
    }

    public T this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public int Count => throw new NotImplementedException();

    public bool IsReadOnly => throw new NotImplementedException();

    public void Add(T item) => _items.Append(item);

    public void Clear()
    {
        throw new NotImplementedException();
    }

    public bool Contains(T item)
    {
        throw new NotImplementedException();
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        throw new NotImplementedException();
    }

    public IEnumerator<T> GetEnumerator() {
        throw new NotImplementedException();
    }

    public int IndexOf(T item)
    {
        throw new NotImplementedException();
    }

    public void Insert(int index, T item)
    {
        throw new NotImplementedException();
    }

    public bool Remove(T item)
    {
        throw new NotImplementedException();
    }

    public void RemoveAt(int index)
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator() {
        throw new NotImplementedException();
    }
}