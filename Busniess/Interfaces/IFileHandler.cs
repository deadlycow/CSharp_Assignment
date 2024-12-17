namespace Busniess.Interfaces;
public interface IFileHandler
{
  bool FileExists(string path);
  string ReadFile(string path);
  void WriteFile(string path, string content);
  bool DirectoryExists(string path);
}