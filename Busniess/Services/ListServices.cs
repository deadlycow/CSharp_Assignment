namespace Busniess.Services
{
  public class ListServices<T>
  {
    private readonly FileServices _fileServices = new();
    private readonly List<T> _itemsList;

    public ListServices()
    {
      _itemsList = _fileServices.LoadFromFile<T>();
    }
    public List<T> CreateList(T item)
    {
      _itemsList.Add(item);
      return _itemsList;
    }

    public List<T> GetList() {
      return _itemsList;
    }
  }
}
