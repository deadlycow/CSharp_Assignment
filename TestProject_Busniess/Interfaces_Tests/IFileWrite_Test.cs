using Busniess.Interfaces;
using Moq;

namespace TestProject_Busniess.Interfaces_Tests;
public class IFileWrite_Test
{
  private readonly IFileServices _fileServices;
  public IFileWrite_Test()
  {

    var mockFileService = new Mock<IFileServices>();
    mockFileService.Setup(fs => fs.SaveToFile(It.IsAny<IUserModel>())).Returns(true);
    mockFileService.Setup(fs => fs.SaveToFile(null!)).Returns(false);

    _fileServices = mockFileService.Object;
  }

  [Fact]
  public void SaveToFile_ShouldReturnTrue_WhenUserModelIsValid()
  {
    //Arrange
    var userModels = new Mock<IUserModel>().Object;
    
    //Act
    var result = _fileServices.SaveToFile(userModels);

    //Assert 
    Assert.True(result);
  }

  [Fact]
  public void SaveToFile_ShouldReturnFalse_WhenUserModelIsNull()
  {
    //Act
    var result = _fileServices.SaveToFile(null!);

    //Assert
    Assert.False(result);
  }
}
