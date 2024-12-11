namespace Busniess.Interfaces
{
  public interface IUserModel
  {
    string? Address { get; set; }
    string? City { get; set; }
    string Email { get; set; }
    string FirstName { get; set; }
    Guid Id { get; set; }
    string LastName { get; set; }
    int PhoneNumber { get; set; }
    int? Zip { get; set; }
  }
}