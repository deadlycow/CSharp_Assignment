namespace Busniess.Interfaces;
public interface ISerializerService
{
  string Serialize<T>(T data);
  T? Deserialize<T>(string json);
}
