using Busniess.Interfaces;

namespace Presentation_Console_MainApp.Interfaces
{
  public interface IDialog
  {
    void GatherUserDetails();
    int? PromptAndValidateInt(string prompt, string propertyName);
    string PromptAndValidateString(string prompt, string propertyName);
  }
}