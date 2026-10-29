namespace lab11v12;

public class InMemoryRepository<T> : IRepository<T> where T : IEntity
{
    private readonly List<T> _items = new();
    private int _nextId = 1;

    public void Add(T item)
    {
        if (item is null) throw new ArgumentNullException(nameof(item));
        item.Id = _nextId++;
        _items.Add(item);
    }

    public T? GetById(int id) => _items.FirstOrDefault(x => x.Id == id);

    public IEnumerable<T> GetAll() => _items.ToList();

    public void Update(T item)
    {
        if (item is null) throw new ArgumentNullException(nameof(item));
        var existing = _items.FirstOrDefault(x => x.Id == item.Id);
        if (existing is null)
            throw new InvalidOperationException($"Car with Id={item.Id} not found");

        var index = _items.IndexOf(existing);
        _items[index] = item;
    }

    public void Delete(int id)
    {
        var existing = _items.FirstOrDefault(x => x.Id == id);
        if (existing is null)
            throw new InvalidOperationException($"Car with Id={id} not found");
        _items.Remove(existing);
    }
}