using Busniess.Interfaces;
using Moq;

namespace TestProjectConsole.Interfaces_Tests;
public class IFileWrite_Test
{
  private readonly IFileWrite _fileWrite;
  public IFileWrite_Test()
  {

    var fileWriteMock = new Mock<IFileWrite>();
    fileWriteMock.Setup(fw => fw.SaveToFile(It.Is<List<IUserModel>>(l => l.Count() > 0))).Returns(true);
    fileWriteMock.Setup(fw => fw.SaveToFile(It.Is<List<IUserModel>>(l => l.Count() == 0))).Returns(false);

    _fileWrite = fileWriteMock.Object;
  }

  [Fact]
  public void SaveToFile_ShouldReturnTrue_WhenListIsNotEmpty()
  {
    //Arrange
    var userModels = new List<IUserModel>
    {
      new Mock<IUserModel>().Object,
    };

    //Act
    var result = _fileWrite.SaveToFile(userModels);

    //Assert 
    Assert.True(result);
  }

  [Fact]
  public void SaveToFile_ShouldReturnFalse_WhenListIsEmpty()
  {
    //Arrange
    var emptyList = new List<IUserModel>();

    //Act
    var result = _fileWrite.SaveToFile(emptyList);

    //Assert
    Assert.False(result);
  }
}
