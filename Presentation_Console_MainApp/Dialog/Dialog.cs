using Busniess.Services;
using Busniess.Interfaces;
using Presentation_Console_MainApp.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Presentation_Console_MainApp.Dialog;
public class Dialog(IUserFactory userFactory, IUserInputService userInputService, IFileServices fileServices) : IDialog
{
  private readonly IUserFactory _userFactory = userFactory;
  private readonly IUserInputService _userInputService = userInputService;
  private readonly IFileServices _fileServices = fileServices;


  public void GatherUserDetails()
  {
    IUserModel user = _userFactory.Create();
    user.Id = IdGenerator.GenerateId();

    user.FirstName = PromptAndValidateString("First name: ", nameof(user.FirstName));
    user.LastName = PromptAndValidateString("Last name: ", nameof(user.LastName));
    user.Email = PromptAndValidateString("Email: ", nameof(user.Email));
    user.PhoneNumber = PromptAndValidateInt("Phonenumber: ", nameof(user.PhoneNumber));
    user.Address = PromptAndValidateString("Address: ", nameof(user.Address));
    user.Zip = PromptAndValidateInt("Zip Code: ", nameof(user.Zip));
    user.City = PromptAndValidateString("City: ", nameof(user.City));
    if (_fileServices.SaveToFile(user))
      Console.WriteLine("Contact added successfully.");

    _userInputService.UserInputKey();
  }
  public string PromptAndValidateString(string prompt, string propertyName)
  {
    while (true)
    {
      Console.Write(prompt);
      var input = _userInputService.UserInputString();

      List<ValidationResult> results = [];
      var context = new ValidationContext(_userFactory.Create()) { MemberName = propertyName };

      if (Validator.TryValidateProperty(input, context, results))
        return input!;

      Console.WriteLine($"{results[0].ErrorMessage} Please try again.");
    }
  }
  public int? PromptAndValidateInt(string prompt, string propertyName)
  {
    while (true)
    {
      Console.Write(prompt);
      var value = _userInputService.UserInputInt();

      List<ValidationResult> results = [];
      var context = new ValidationContext(_userFactory.Create()) { MemberName = propertyName };
      if (Validator.TryValidateProperty(value, context, results))
      {
        return value;
      }
      Console.WriteLine($"{results[0].ErrorMessage} Please try again");
    }
  }
}
