using Busniess.Interfaces;
using Moq;

namespace TestProject_Busniess.Interfaces_Tests;
public class IFileRead_Test
{
  private readonly IFileRead _fileRead;
  public IFileRead_Test()
  {
    var userModels = new List<IUserModel>
    {
      new Mock<IUserModel>().Object,
      new Mock<IUserModel>().Object,
    };

    var fileReadMock = new Mock<IFileRead>();
    fileReadMock.Setup(fr => fr.LoadFromFile()).Returns(userModels);

    _fileRead = fileReadMock.Object;
  }

  [Fact]
  public void LoadFromFile_ShouldReturnIEnumerableOfIUserModel()
  {
    //Act
    var result = _fileRead.LoadFromFile();
    //Assert
    Assert.IsAssignableFrom<IEnumerable<IUserModel>>(result);
  }
}
