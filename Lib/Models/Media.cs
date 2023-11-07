namespace Lib.Models;

public class Media : BaseModel
{
    public Guid MediaId { get; set; } = Guid.NewGuid();
    public Guid CategoryId { get; set; }
    public Guid? EventId { get; set; }
    public Guid? JobId { get; set; }
    public string OriginalFilename { get; set; }
    public string Extension { get; set; }
    public string MimeType { get; set; }
    public long Size { get; set; }
    public string StoragePath { get; set; }
    public string Hash { get; set; }
    public string Metadata { get; set; }
}