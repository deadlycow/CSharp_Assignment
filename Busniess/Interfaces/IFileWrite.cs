namespace Busniess.Interfaces;

public interface IFileWrite
{
  bool SaveToFile(List<IUserModel> users);
}