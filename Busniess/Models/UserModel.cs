using Busniess.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Busniess.Models
{
  public class UserModel : IUserModel
  {
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required(ErrorMessage = "First name can't be EMPTY!")]
    [MinLength(2, ErrorMessage = "First name must contain at least TWO characters!")]
    public string FirstName { get; set; } = null!;

    [Required(ErrorMessage = "Last name can't be EMPTY!")]
    [MinLength(2, ErrorMessage = "Last name must contain at least TWO characters!")]
    public string LastName { get; set; } = null!;

    [Required(ErrorMessage = "Email is required!")]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email format.")]
    public string Email { get; set; } = null!;

    [Required]
    [RegularExpression(@"^(\+46|0046|0)?(7[0-9]|1[0-9])[-\s]?[0-9]{3}[-\s]?[0-9]{4}$", ErrorMessage = "Ex. +46701234567, 072-123 4567, 0101234567. Phone number must be between 10-15 long.")]
    public int PhoneNumber { get; set; }
    public string? Address { get; set; }
    public int? Zip { get; set; }
    public string? City { get; set; }
  }
}
