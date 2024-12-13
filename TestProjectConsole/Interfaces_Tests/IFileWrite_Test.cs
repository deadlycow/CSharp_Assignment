using Busniess.Interfaces;
using Moq;

namespace TestProject_Busniess.Interfaces_Tests;
public class IFileWrite_Test
{
  private readonly IFileWrite _fileWrite;
  public IFileWrite_Test()
  {

    var fileWriteMock = new Mock<IFileWrite>();
    fileWriteMock.Setup(fw => fw.SaveToFile(It.IsAny<IUserModel>())).Returns(true);
    fileWriteMock.Setup(fw => fw.SaveToFile(null!)).Returns(false);

    _fileWrite = fileWriteMock.Object;
  }

  [Fact]
  public void SaveToFile_ShouldReturnTrue_WhenUserModelIsValid()
  {
    //Arrange
    var userModels = new Mock<IUserModel>().Object;
    
    //Act
    var result = _fileWrite.SaveToFile(userModels);

    //Assert 
    Assert.True(result);
  }

  [Fact]
  public void SaveToFile_ShouldReturnFalse_WhenUserModelIsNull()
  {
    //Act
    var result = _fileWrite.SaveToFile(null!);

    //Assert
    Assert.False(result);
  }
}
