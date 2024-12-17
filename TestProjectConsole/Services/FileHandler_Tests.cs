using Busniess.Interfaces;
using Busniess.Services;
using Moq;

namespace TestProject_Busniess.Services;
public class FileHandler_Tests
{
  [Fact]
  public void FileExists_ShouldReturnTrue_WhenFileExists()
  {
    //Arrange
    var mockFileHandler = new Mock<IFileHandler>();
    mockFileHandler.Setup(fh => fh.FileExists("test.txt")).Returns(true);

    var fileHandler = mockFileHandler.Object;

    //Act
    var result = fileHandler.FileExists("test.txt");
    //Assert

    Assert.True(result);
  }
  [Fact]
  public void FileExists_ShouldReturnFalse_WhenNoFileExists()
  {
    //Arrange
    var mockFileHandler = new Mock<IFileHandler>();
    mockFileHandler.Setup(fh => fh.FileExists("test.txt")).Returns(false);
    var fileHandler = mockFileHandler.Object;

    //Act
    var result = fileHandler.FileExists("test.txt");

    //Assert
    Assert.False(result);
  }
  [Fact]
  public void ReadFile_ShouldReturnAString()
  {
    //Arrange
    var mockFileHandler = new Mock<IFileHandler>();
    var context = "somthing in the file";
    mockFileHandler.Setup(rf => rf.ReadFile("test.txt")).Returns(context);

    var fileHandler = mockFileHandler.Object;
    //Act
    var result = fileHandler.ReadFile("test.txt");

    //Assert
    Assert.Equal(context, result);
  }
}
