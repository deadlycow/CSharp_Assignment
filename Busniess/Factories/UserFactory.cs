using Busniess.Interfaces;
using Busniess.Models;

namespace Busniess.Factories
{
  public class UserFactory : IUserFactory
  {
    public IUserModel Create() => new UserModel();
  }
}
