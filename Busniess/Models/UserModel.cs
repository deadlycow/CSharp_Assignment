using Busniess.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Busniess.Models
{
  public class UserModel : IUserModel
  {
    public Guid Id { get; set; }

    [Required(ErrorMessage = "First name can't be EMPTY!")]
    [MinLength(2, ErrorMessage = "First name must contain at least TWO characters!")]
    public string FirstName { get; set; } = null!;

    [Required(ErrorMessage = "Last name can't be EMPTY!")]
    [MinLength(2, ErrorMessage = "Last name must contain at least TWO characters!")]
    public string LastName { get; set; } = null!;

    [Required(ErrorMessage = "Email is required!")]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email format.")]
    public string Email { get; set; } = null!;
    public int? PhoneNumber { get; set; }
    public string? Address { get; set; }
    public int? Zip { get; set; }
    public string? City { get; set; }
  }
}
