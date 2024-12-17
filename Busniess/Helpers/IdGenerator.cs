namespace Busniess.Services;
public class IdGenerator
{
  public static Guid GenerateId() => Guid.NewGuid();
}
