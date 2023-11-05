namespace Lib.DataAccess;

public interface IFileStorageDataAccess
{
    public Task Store(string filePath, Stream contents);
    public Task<Stream> Retrieve(string filePath);
    public Task Delete(string filePath);
}