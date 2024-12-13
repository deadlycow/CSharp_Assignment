using Xunit;
using Busniess.Interfaces;
using Moq;

namespace TestProject_Busniess.Interfaces_Tests;
public class IUserFactory_Test
{
  private readonly IUserFactory _userFactory;

  public IUserFactory_Test()
  {
    var userFactoryMock = new Mock<IUserFactory>();
    userFactoryMock.Setup(factory => factory.Create()).Returns(Mock.Of<IUserModel>);

    _userFactory = userFactoryMock.Object;
  }

  [Fact]
  public void Create_ShouldCreateIUserModel_FromUserModel()
  {
    //Act 
    var result = _userFactory.Create();
    //Assert
    Assert.IsAssignableFrom<IUserModel>(result);
  }
}
