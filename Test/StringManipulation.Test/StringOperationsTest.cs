using Microsoft.Extensions.Logging;
using Moq;
using StringManipulation;
using Xunit;

public class StringOperationsTest
{

  // [Fact]
  // public void ConcatenateStrings()
  // {
  //   var stringOperations = new StringOperations();

  //   var result = stringOperations.ConcatenateStrings("Hello", "World");

  //   Assert.NotNull(result);
  //   Assert.NotEmpty(result);
  //   Assert.Equal("Hello World", result);
  // }

  //! [Theory] -> permite reutilizar las pruebas unitarios haciendo varios casos de prueba por una misma funcion

  [Theory]
  [InlineData("Hello", "World", "Hello World")]
  [InlineData("David", "Triana", "David Triana")]
  public void ConcatenateStrings(string word1, string word2, string expected)
  {
    // arrange => configuremos los datos de prueba
    var stringOperations = new StringOperations();

    // act => ejecutamos el método de prueba y almacenamos el resultado
    var result = stringOperations.ConcatenateStrings(word1, word2);

    // assert => verificamos el resultado
    Assert.NotNull(result);
    Assert.NotEmpty(result);
    Assert.Equal(expected, result);
  }

  [Theory]
  [InlineData("Hello World", "dlroW olleH")]
  [InlineData("Csharp", "prahsC")]
  public void ReverseString(string word, string expected)
  {
    var stringOperations = new StringOperations();
    var result = stringOperations.ReverseString(word);
    Assert.Equal(expected, result);
  }

  [Theory]
  [InlineData("Hello World", 11)]
  [InlineData("David Triana", 12)]
  public void GetStringLength(string word, int expected)
  {
    var stringOperations = new StringOperations();
    var result = stringOperations.GetStringLength(word);
    Assert.Equal(expected, result);
  }

  [Fact]
  public void GetStringLength_Exception()
  {
    var stringOperations = new StringOperations();
    Assert.ThrowsAny<ArgumentNullException>(() => stringOperations.GetStringLength(null));
  }

  [Theory]
  [InlineData("Hello World", "HelloWorld")]
  [InlineData("David Triana", "DavidTriana")]
  public void RemoveWhitespace(string word, string expected)
  {
    var stringOperations = new StringOperations();
    var result = stringOperations.RemoveWhitespace(word);
    Assert.Equal(expected, result);
  }

  [Theory]
  [InlineData("Hello World", 5, "Hello")]
  [InlineData("David Triana", 5, "David")]
  public void TruncateString(string word, int length, string expected)
  {
    var stringOperations = new StringOperations();
    var result = stringOperations.TruncateString(word, length);
    Assert.Equal(expected, result);
  }

  [Fact]
  public void TruncateString_Exception()
  {
    var stringOperations = new StringOperations();

    Assert.ThrowsAny<ArgumentOutOfRangeException>(() => stringOperations.TruncateString("hola", -1));
  }

  [Fact]
  public void TruncateString_FailureLength()
  {
    var stringOperations = new StringOperations();
    var result = stringOperations.TruncateString("hola", 7);
    Assert.Equal("hola", result);
  }

  [Fact]
  public void TruncateString_FailureNull()
  {
    var stringOperations = new StringOperations();
    var result = stringOperations.TruncateString(string.Empty, 7);
    Assert.Equal(string.Empty, result);
  }

  [Theory]
  [InlineData("ana", true)]
  [InlineData("hello", false)]
  public void IsPalindrome(string word, bool expected)
  {
    var stringOperations = new StringOperations();
    var result = stringOperations.IsPalindrome(word);
    Assert.Equal(expected, result);
  }

  [Fact]
  public void CountOccurrencesFact()
  {
    var mockLogger = new Mock<ILogger<StringOperations>>();
    var stringOperations = new StringOperations(mockLogger.Object);

    var result = stringOperations.CountOccurrences("hello world", 'l');

    Assert.Equal(3, result);
  }

  [Theory]
  [InlineData("Hello", 'l', 2)]
  [InlineData("ana", 'a', 2)]
  public void CountOccurrences(string word, char letter, int expected)
  {
    var mockLogger = new Mock<ILogger<StringOperations>>();

    var stringOperations = new StringOperations(mockLogger.Object);

    var result = stringOperations.CountOccurrences(word, letter);
    Assert.Equal(expected, result);
  }

  [Theory]
  [InlineData("cat", "cats")]
  [InlineData("person", "people")]
  public void Pluralize(string word, string expected)
  {
    var stringOperations = new StringOperations();
    var result = stringOperations.Pluralize(word);
    Assert.Equal(expected, result);
  }

  [Theory]
  [InlineData("cat", 2, "two")]
  [InlineData("cat", 5, "five")]
  public void QuantintyInWords(string word, int number, string expected)
  {
    var stringOperations = new StringOperations();
    var result = stringOperations.QuantintyInWords(word, number);
    Assert.StartsWith(expected, result);
    Assert.Contains("cat", result);
  }


  [Theory]
  [InlineData("V", 5)]
  [InlineData("MCV", 1105)]
  public void FromRomanToNumber(string romanNumber, int expected)
  {
    var stringOperations = new StringOperations();
    var result = stringOperations.FromRomanToNumber(romanNumber);
    Console.WriteLine(result);
    Assert.Equal(expected, result);
  }


  [Fact]
  public void ReadFile()
  {
    var stringOperations = new StringOperations();
    var mockFileReader = new Mock<IFileReaderConector>();
    mockFileReader.Setup(p => p.ReadString(It.IsAny<string>())).Returns("Reading file");
    var result = stringOperations.ReadFile(mockFileReader.Object, "file.txt");

    Assert.Equal("Reading file", result);
  }
}

/* 
para mostrar la covertura por consola -> dotnet test -p:CollectCoverage=true
para generar el reporte en xml -> dotnet test -p:CollectCoverage=true -p:CoverletOutputFormat=cobertura
para transformar el reporte xml a html -> reportgenerator "-reports:coverage.cobertura.xml" "-targetdir:coverage-report" -reporttypes:html
*/

