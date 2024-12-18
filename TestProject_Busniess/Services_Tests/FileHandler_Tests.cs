using Busniess.Interfaces;
using Busniess.Services;
using Moq;

namespace TestProject_Busniess.Services_Tests;
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
  public void ReadFile_ShouldReturnAString_WhenFileExsists()
  {
    //Arrange
    var path = "testfile.txt";
    var context = "somthing in the file";
    File.WriteAllText(path, context);

    var fileHandler = new FileHandler();
    //Act
    var result = fileHandler.ReadFile("testfile.txt");

    //Assert
    Assert.Equal(context, result);

    //Cleanup
    File.Delete(path);
  }
  [Fact]
  public void ReadFile_ShouldThrowException_WhenFileDoesNotExist()
  {
    //Arrange
    var path = Path.Combine(Path.GetTempPath(), "nonexistingfile.txt");
    var fileHandler = new FileHandler();
    //Act & Assert
    Assert.Throws<FileNotFoundException>(() => fileHandler.ReadFile(path));
  }
  [Fact]
  public void WriteFile_ShouldCreateFile()
  {
    //Arrange
    var path = Path.Combine(Path.GetTempPath(), "WriteFileTest.txt");
    var expectedContent = "something for the file";
    //Act
    var fileHandler = new FileHandler();
    fileHandler.WriteFile(path, expectedContent);
    //Assert
    Assert.True(File.Exists(path), "No file created.");
    var actualContent = File.ReadAllText(path);
    Assert.Equal(expectedContent, actualContent);
    //Clean up
    File.Delete(path);
  }
  [Fact]
  public void DirectoryExists_ShouldReturnTrue_WhenDirectoryExists()
  {
    //Arrange
    var testFilePath = Path.GetTempPath();
    var testFilePath_2 = Path.Combine(Path.GetTempPath(), "nonExistingDirectory");

    //Act
    var existingDirectory = Directory.Exists(testFilePath);
    var nonExsistingDirectory = Directory.Exists(testFilePath_2);

    //Assert
    Assert.True(existingDirectory);
    Assert.False(nonExsistingDirectory);
  }
  [Fact]
  public void CreateDirectory_ShouldCallDirectoryExistsAndCreateDirectroy()
  {
    //Arrange
    var mockFileHandler = new Mock<IFileHandler>();
    var directoryPath = "testDirectory";

    mockFileHandler.Setup(fh => fh.DirectoryExists(directoryPath)).Returns(false);

    //Act
    if (!mockFileHandler.Object.DirectoryExists(directoryPath))
      mockFileHandler.Object.CreateDirectory(directoryPath);

    //Assert
    mockFileHandler.Verify(fh => fh.DirectoryExists(directoryPath), Times.Once);
    mockFileHandler.Verify(fh => fh.CreateDirectory(directoryPath), Times.Once);
  }
  [Fact]
  public void CreateDirectory_ShouldNotCallCreateDirectory_WhenDirectoryExists()
  {
    //Arrange
    var mockFileHandler = new Mock<IFileHandler>();
    var directoryPath = "testDirectory";

    mockFileHandler.Setup(fh => fh.DirectoryExists(directoryPath)).Returns(true);

    //Act
    if (!mockFileHandler.Object.DirectoryExists(directoryPath))
      mockFileHandler.Object.CreateDirectory(directoryPath);

    //Assert
    mockFileHandler.Verify(fh => fh.DirectoryExists(directoryPath), Times.Once);
    mockFileHandler.Verify(fh => fh.CreateDirectory(It.IsAny<string>()), Times.Never);
  }
}
