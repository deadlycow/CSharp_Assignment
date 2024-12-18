using Busniess.Interfaces;
using Busniess.Services;
using System.Text.Json;

namespace TestProject_Busniess.Interfaces_Tests;
public class ISerializerService_Tests
{
  private readonly ISerializerService _serializerService;
  public ISerializerService_Tests()
  {
    _serializerService = new SerializerService();
  }
  [Fact]
  public void Serialize_ShouldReturnValidJsonString()
  {
    //Arrange
    var testObject = new { Name = "Andreas", Age = "37" };

    //Act
    var json = _serializerService.Serialize(testObject);

    //Assert
    Assert.NotNull(json);
    Assert.Contains($"{testObject.Name}", json);
    Assert.Contains($"{testObject.Age}", json);
  }
  [Fact]
  public void Deserialize_ShouldReturnValidObject_FromJsonString()
  {
    //Arrange
    var json = "{\"Name\":\"Andreas\",\"Age\":\"37\"}";
    Dictionary<string, string> expectedResult = new()
    {
      {"Name", "Andreas" },
      {"Age", "37" }
    };

    //Act
    var result = _serializerService.Deserialize<Dictionary<string, string>>(json);

    //Assert
    Assert.NotNull(result);
    Assert.Equal(expectedResult["Name"], result["Name"]);
    Assert.Equal(expectedResult["Age"], result["Age"]);
  }
}
