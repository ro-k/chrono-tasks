using System.Text.Json;
using Bogus;
using Lib.Models;

namespace UnitTest.Fakes.Models;

public class JobFaker : Faker<Job>
{
    public JobFaker()
    {
        this.RuleForBaseModel()
            .RuleFor(x => x.JobId, f => f.Random.Guid())
            .RuleFor(x => x.CategoryId, f => f.Random.Guid())
            .RuleFor(x => x.Name, f => f.Lorem.Word())
            .RuleFor(x => x.Description, f => f.Lorem.Sentence())
            .RuleFor(x => x.Data,
                f => JsonSerializer.Serialize(new { Prop1 = f.Lorem.Word(), Prop2 = f.Lorem.Sentence() }));
    }
}