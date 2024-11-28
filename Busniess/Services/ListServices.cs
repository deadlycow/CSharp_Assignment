using Busniess.Model;

namespace Busniess.Services
{
  public class ListServices<T>
  {
    private List<T> _itemsList = [];
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
