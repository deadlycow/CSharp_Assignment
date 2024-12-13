namespace Presentation_Console_MainApp.Interfaces;
public interface IUserInputService
{
  ConsoleKey UserInputKey();
  string? UserInputString();
  int? UserInputInt();
  void UserInputContinue();
}