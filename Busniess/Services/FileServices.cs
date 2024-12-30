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

    public bool DeleteUser(IUserModel user)
    {
      try
      {
        var users = LoadFromFile().ToList();
        var userToRemove = users.FirstOrDefault(x => x.Id == user.Id);

        if (userToRemove == null) return false;
        users.Remove(userToRemove);

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
    public bool UpdateUser(IUserModel user)
    {
      try
      {
        var users = LoadFromFile().ToList();
        var userToUpdate = users.FirstOrDefault(x => x.Id == user.Id);

        if (userToUpdate == null) return false;

        userToUpdate.FirstName = user.FirstName;
        userToUpdate.LastName = user.LastName;
        userToUpdate.Email = user.Email;
        userToUpdate.PhoneNumber = user.PhoneNumber;
        userToUpdate.Address = user.Address;
        userToUpdate.Zip = user.Zip;
        userToUpdate.City = user.City;

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
