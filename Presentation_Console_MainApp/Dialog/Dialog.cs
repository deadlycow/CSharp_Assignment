using Busniess.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Presentation_Console_MainApp.Dialog;
public class Dialog(IUserFactory userFactory)
{
  private readonly IUserFactory _userFactory = userFactory;

  public static ConsoleKey PromptUserMenuChoice()
  {
    Console.Write("Press a key to select an option: ");
    return Console.ReadKey(true).Key;
  }
  public IUserModel GatherUserDetails()
  {
    IUserModel user = _userFactory.Create();

    user.FirstName = PromptAndValidateString("First name: ", nameof(user.FirstName));
    user.LastName = PromptAndValidateString("Last name: ", nameof(user.LastName));
    user.Email = PromptAndValidateString("Email: ", nameof(user.Email));
    user.PhoneNumber = PromptAndValidateInt("Phonenumber: ", nameof(user.PhoneNumber));
    user.Address = PromptAndValidateString("Address: ", nameof(user.Address));
    user.Zip = PromptAndValidateInt("Zip Code: ", nameof(user.Zip));
    user.City = PromptAndValidateString("City: ", nameof(user.City));

    return user;
  }
  public string PromptAndValidateString(string prompt, string propertyName)
  {
    while (true)
    {
      Console.Write(prompt);
      var input = Console.ReadLine() ?? string.Empty;
      List<ValidationResult> results = [];

      var context = new ValidationContext(_userFactory.Create()) { MemberName = propertyName };
      if (Validator.TryValidateProperty(input, context, results))
      {
        return input;
      }
      Console.WriteLine($"{results[0].ErrorMessage} Please try again.");
    }
  }
  public int PromptAndValidateInt(string prompt, string propertyName)
  {
    while (true)
    {
      Console.Write(prompt);
      var input = Console.ReadLine() ?? string.Empty;
      
      if (!int.TryParse(input, out int value))
      {
        Console.WriteLine("Invalid input. ONLY numbers.");
        continue;
      }

      List<ValidationResult> results = [];
      var context = new ValidationContext(_userFactory.Create()) { MemberName = propertyName};
      if (Validator.TryValidateProperty(value, context, results))
      {
        return value;
      }
      Console.WriteLine($"{results[0].ErrorMessage} Please try again");
    }
  }
  public static bool PromptForAdditinalUsers()
  {
    Console.WriteLine("\nAdd more contacts...? (Y/N)");
    return Console.ReadKey(true).Key == ConsoleKey.Y;
  }
  public static void PromptAnyKeyToContinue()
  {
    Console.Write("Press any key to continue...");
    Console.ReadKey();
  }
}
