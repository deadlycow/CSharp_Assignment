using System.Diagnostics;
using System.Text.Json;

namespace Busniess.Services
{
  public class FileServices (string directoryPath = "Data", string filePath = "list.json")
  {
    private readonly string _directoryPath = directoryPath;
    private readonly string _filePath = Path.Combine(directoryPath, filePath);

    private readonly JsonSerializerOptions _options = new() { WriteIndented = true};

    public List<T> LoadFromFile<T>()
    {
      try
      {
        if ( !File.Exists(_filePath) ) return [];

        string list = File.ReadAllText(_filePath);
        return JsonSerializer.Deserialize<List<T>>(list, _options) ?? [];
      }
      catch ( Exception ex )
      {
        Debug.WriteLine(ex.Message);
        return [];
      }

    }
    public void SaveToFile<T>(List<T> users)
    {
      if ( !Directory.Exists(_directoryPath) )
        Directory.CreateDirectory(_directoryPath);

      var json = JsonSerializer.Serialize(users, _options);
      File.WriteAllText(_filePath, json);
    }
  }
}
