using Busniess.Interfaces;
using Moq;

namespace TestProject_Busniess.Interfaces_Tests;
public class IFileRead_Test
{
  private readonly IFileServices _fileServices;
  public IFileRead_Test()
  {
    var userModels = new List<IUserModel>
    {
      new Mock<IUserModel>().Object,
      new Mock<IUserModel>().Object,
    };

    var mockFileService = new Mock<IFileServices>();
    mockFileService.Setup(fs => fs.LoadFromFile()).Returns(userModels);

    _fileServices = mockFileService.Object;
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
