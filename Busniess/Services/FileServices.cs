using Busniess.Interfaces;
using Busniess.Models;
using System.Diagnostics;
using System.Text.Json;

namespace Busniess.Services
{
  public class FileServices(string directoryPath, string filePath) : IFileServices
  {
    private readonly string _directoryPath = directoryPath;
    private readonly string _filePath = Path.Combine(directoryPath, filePath);
    private readonly JsonSerializerOptions _options = new() { WriteIndented = true };

    public IEnumerable<IUserModel> LoadFromFile()
    {
      try
      {
        if (!File.Exists(_filePath)) return [];

        string json = File.ReadAllText(_filePath);
        var userList = JsonSerializer.Deserialize<List<UserModel>>(json, _options) ?? [];
        return userList;
      }
      catch (Exception ex)
      {
        Debug.WriteLine(ex.Message);
        return [];
      }
    }
    public bool SaveToFile(IUserModel users)
    {
      try
      {
        List<IUserModel> exsistingUsers = LoadFromFile().ToList();
        exsistingUsers.Add(users);

        if (!Directory.Exists(_directoryPath))
          Directory.CreateDirectory(_directoryPath);

        var json = JsonSerializer.Serialize(exsistingUsers, _options);
        File.WriteAllText(_filePath, json);
        return true;
      }
      catch
      {
        return false;
      }
    }
  }
}
