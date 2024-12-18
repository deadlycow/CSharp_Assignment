using Busniess.Interfaces;
using Moq;

namespace TestProject_Busniess.Interfaces_Tests;
public class IFileServices_Test
{
  private readonly IFileServices _fileServices;
  public IFileServices_Test()
  {
    var userModels = new List<IUserModel>
    {
      new Mock<IUserModel>().Object,
      new Mock<IUserModel>().Object,
    };

    var mockFileService = new Mock<IFileServices>();
    mockFileService.Setup(fs => fs.SaveToFile(It.IsAny<IUserModel>())).Returns(true);
    mockFileService.Setup(fs => fs.SaveToFile(null!)).Returns(false);
    mockFileService.Setup(fs => fs.LoadFromFile()).Returns(userModels);

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
  [Fact]
  public void LoadFromFile_ShouldReturnIEnumerableOfIUserModel()
  {
    //Act
    var result = _fileServices.LoadFromFile();
    //Assert
    Assert.IsAssignableFrom<IEnumerable<IUserModel>>(result);
  }
}
