using System.Text.Json;
using Bogus;
using Lib.Models;

namespace UnitTest.Fakes.Models;

public class MediaFaker : Faker<Media>
{
    public MediaFaker()
    {
        this.RuleForBaseModel()
            .RuleFor(x => x.MediaId, f => f.Random.Guid())
            .RuleFor(x => x.OriginalFilename, f => f.System.FileName())
            .RuleFor(x => x.Extension, f => f.System.FileExt())
            .RuleFor(x => x.MimeType, f => f.System.MimeType())
            .RuleFor(x => x.Size, f => f.Random.Long(0, 1000000))
            .RuleFor(x => x.StoragePath, f => f.System.DirectoryPath())
            .RuleFor(x => x.Hash, f => f.Random.AlphaNumeric(32))
            .RuleFor(x => x.Metadata,
                f => JsonSerializer.Serialize(new { Prop1 = f.Lorem.Word(), Prop2 = f.Lorem.Sentence() }));
    }
}