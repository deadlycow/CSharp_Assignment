using Busniess.Interfaces;
using System.Diagnostics;
namespace Busniess.Services;
public class FileHandler : IFileHandler
{
  public bool DirectoryExists(string path)
  {
    try
    {
      if (!Directory.Exists(path))
        Directory.CreateDirectory(path);
      return true;
    }
    catch (Exception ex)
    {
      Debug.WriteLine(ex.Message);
      return false;
    }
  }

  public bool FileExists(string path) => File.Exists(path);

  public string ReadFile(string path) => File.ReadAllText(path);

  public void WriteFile(string path, string content) => File.WriteAllText(path, content);
}
