using Busniess.Interfaces;
using System.Text.Json;

namespace Busniess.Services;
public class SerializerService : ISerializerService
{
  private readonly JsonSerializerOptions _options = new() { WriteIndented = true };
  public T? Deserialize<T>(string json)
  {
    return JsonSerializer.Deserialize<T>(json, _options);
  }

  public string Serialize<T>(T data)
  {
    return JsonSerializer.Serialize(data, _options);
  }
}
