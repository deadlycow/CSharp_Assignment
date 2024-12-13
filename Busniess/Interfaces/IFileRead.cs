namespace Busniess.Interfaces;

public interface IFileRead
{
  IEnumerable<IUserModel> LoadFromFile();
}
