using FluentAssertions;
using Lib.DataAccess;
using Moq;

namespace UnitTest.DataAccess;

public class LocalFileStorageDataAccessTests : BaseTest
{
    private readonly Mock<LocalFileStorageDataAccess.IFileStreamWrapper> _mockStreamWrapper;
    private readonly LocalFileStorageDataAccess _testDataAccess;

    private readonly string _testFilePath;
    
    public LocalFileStorageDataAccessTests()
    {
        _mockStreamWrapper = new Mock<LocalFileStorageDataAccess.IFileStreamWrapper>(MockBehavior.Strict);
        _testDataAccess = new LocalFileStorageDataAccess(_mockStreamWrapper.Object);
        _testFilePath = TestDataGenerator.System.FilePath();
    }
    
    [Fact]
    public async Task Store_WritesStreamToFile()
    {
        // given
        var fileContent = System.Text.Encoding.UTF8.GetBytes(Guid.NewGuid().ToString());
        var memoryStream = new MemoryStream(fileContent);
        var mockFileStream = new MemoryStream();

        _mockStreamWrapper.Setup(f => f.GetNew(_testFilePath, FileMode.Create, FileAccess.Write)).Returns(mockFileStream);
        

        // when
        await _testDataAccess.Store(_testFilePath, memoryStream);

        // then
        var resultFileContent = mockFileStream.ToArray();
        resultFileContent.Should().Equal(fileContent);
    }
    
    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public async Task Store_InvalidFilePath_DoesNothing(string filePath)
    {
        // given
        var fileContent = System.Text.Encoding.UTF8.GetBytes(Guid.NewGuid().ToString());
        var memoryStream = new MemoryStream(fileContent);

        // when
        await _testDataAccess.Store(filePath, memoryStream);

        // then
        _mockStreamWrapper.Verify(f => f.GetNew(It.IsAny<string>(), It.IsAny<FileMode>(), It.IsAny<FileAccess>()), Times.Never);
    }
    
    [Fact]
    public async Task Retrieve_ReadsFileContent()
    {
        // given
        var fileContent = System.Text.Encoding.UTF8.GetBytes(Guid.NewGuid().ToString());
        var memoryStream = new MemoryStream(fileContent);

        _mockStreamWrapper.Setup(f => f.GetNew(_testFilePath, FileMode.Open, FileAccess.Read)).Returns(memoryStream);

        // when
        var resultStream = await _testDataAccess.Retrieve(_testFilePath);

        // then
        var resultFileContent = (resultStream as MemoryStream)!.ToArray();
        resultFileContent.Should().Equal(fileContent);
    }
    
    [Fact]
    public void Delete_DeletesSpecifiedFile()
    {
        // given
        _mockStreamWrapper.Setup(x => x.Delete(_testFilePath));

        // when
        _testDataAccess.Delete(_testFilePath);

        // then
        _mockStreamWrapper.Verify(f => f.Delete(_testFilePath), Times.Once);
    }
}