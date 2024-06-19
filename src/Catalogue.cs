using System.Collections;

namespace LexGarage;

public class Catalogue<T>(int size) : IEnumerable<T>, ICollection<T>, IList<T> {

    private T[] _items = new T[size];

    private int _count = 0;

    public int Count => _count;

    public bool IsReadOnly => false;

    ////////////////////////////////////////////////////////////////////////////////

    public Catalogue() : this(8) { }

    ////////////////////////////////////////////////////////////////////////////////

    public void IncreaseSize(int newSize) {
        if (newSize <= _items.Length) {
            throw new ArgumentOutOfRangeException(nameof(newSize), "New size must be greater than current size");
        }
        var newItems = new T[newSize];
        _items.CopyTo(newItems, 0);
        _items = newItems;
    }

    public List<T> ToList() => [.. _items];

    public T this[int index] {
        get => _items[index];
        set => _items[index] = value;
    }

    public void Add(T item) {
        CheckCatalogueFull();
        for (var i = 0; i < _items.Length; i++) {
            if (_items[i] == null) {
                _items[i] = item;
                break;
            }
        }
        Recount();
    }

    public bool Remove(T item) {
        var index = IndexOf(item);
        if (index < 0) {
            return false;
        }

        _items = _items.Where((val, i) => i != index).ToArray();
        Recount();
        return true;
    }

    public void Clear() {
        _items = new T[_items.Length];
        _count = 0;
    }

    public bool Contains(T item) => _items.Contains(item);

    public void CopyTo(T[] array, int arrayIndex) {
        throw new NotImplementedException();
    }

    public IEnumerator<T> GetEnumerator() {
        for (int i = 0; i < _count; i++) {
            yield return _items[i];
        }
    }

    public int IndexOf(T item) => Array.IndexOf(_items, item);

    public void Insert(int index, T item) {
        CheckCatalogueFull();
        Array.Copy(_items, index, _items, index + 1, _items.Length - index - 1);
        _items[index] = item;
        Recount();
    }

    public void RemoveAt(int index) {
        _items = _items.Where((val, i) => i != index).ToArray();
        Recount();
    }

    private void Recount() {
        _count = 0;
        foreach (var item in _items) {
            if (item != null) {
                _count++;
            }
        }
    }

    private void CheckCatalogueFull() {
        if (_count >= _items.Length) {
            throw new InvalidOperationException("Catalogue is full");
        }
    }

    private void SortArray() {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}