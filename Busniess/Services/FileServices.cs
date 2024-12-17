using Busniess.Interfaces;
using Busniess.Models;
using System.Diagnostics;

namespace Busniess.Services
{
  public class FileServices(string directoryPath, string filePath, IFileHandler fileHandler, ISerializerService serializer) : IFileServices
  {
    private readonly IFileHandler _fileHandler = fileHandler;
    private readonly ISerializerService _serializer = serializer;

    private readonly string _directoryPath = directoryPath;
    private readonly string _filePath = Path.Combine(directoryPath, filePath);
    

    public IEnumerable<IUserModel> LoadFromFile()
    {
      try
      {
        if (!_fileHandler.FileExists(_filePath)) return [];

        string json = _fileHandler.ReadFile(_filePath);
        return _serializer.Deserialize<List<UserModel>>(json) ?? [];
      }
      catch (Exception ex)
      {
        Debug.WriteLine(ex.Message);
        return [];
      }
    }
    public bool SaveToFile(IUserModel user)
    {
      try
      {
        var users = LoadFromFile().ToList();
        users.Add(user);

        _fileHandler.DirectoryExists(_directoryPath);

        var json = _serializer.Serialize(users);
        _fileHandler.WriteFile(_filePath, json);
        return true;
      }
      catch (Exception ex)
      {
        Debug.WriteLine(ex.Message);
        return false;
      }
    }
  }
}
