namespace Busniess.Model
{
  public class User
  {
    public Guid Id { get; set; } = Guid.NewGuid();
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public int PhoneNumber { get; set; }
    public string Address { get; set; } = string.Empty;
    public int Zip {  get; set; }
    public string City { get; set; } = string.Empty;
  }
}
