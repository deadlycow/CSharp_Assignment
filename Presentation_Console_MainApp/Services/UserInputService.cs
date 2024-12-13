using Presentation_Console_MainApp.Interfaces;

namespace Presentation_Console_MainApp.Services;
public class UserInputService : IUserInputService
{
  public void UserInputContinue()
  {
    Console.Write("Press any key to continue...");
    Console.ReadKey();
  }
  public int? UserInputInt()
  {
    bool result = int.TryParse(Console.ReadLine(), out int value);
    return result ? value : 0;
  }
  public ConsoleKey UserInputKey() => Console.ReadKey().Key;
  public string? UserInputString() => Console.ReadLine();
}