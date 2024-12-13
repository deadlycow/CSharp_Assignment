namespace Busniess.Interfaces
{
  public interface IUserModel
  {
    Guid Id { get; set; }
    string FirstName { get; set; }
    string LastName { get; set; }
    string Email { get; set; }
    int? PhoneNumber { get; set; }
    string? Address { get; set; }
    int? Zip { get; set; }
    string? City { get; set; }
  }
}