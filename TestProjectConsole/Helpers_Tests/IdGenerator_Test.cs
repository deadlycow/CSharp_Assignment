using Busniess.Helpers;
namespace TestProject_Busniess.Helpers_Tests;
public class IdGenerator_Test
{
  [Fact]
  public void GenerateId_ShouldReturnValidGuid()
  {
    //Act
    var result = IdGenerator.GenerateId();

    //Assert
    Assert.IsType<Guid>(result);
    Assert.NotEqual(Guid.Empty, result);
  } 
  [Fact]
  public void GenerateId_ShouldReturnUniqueId()
  {
    //Act
    var firstId = IdGenerator.GenerateId();
    var secondId = IdGenerator.GenerateId();

    //Assert
    Assert.NotEqual(firstId, secondId);
  }
}
