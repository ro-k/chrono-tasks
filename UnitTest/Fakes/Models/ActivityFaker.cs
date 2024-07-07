using Bogus;
using Lib.Models;

namespace UnitTest.Fakes.Models;
public class ActivityFaker : Faker<Activity>
{
    public ActivityFaker()
    {
        this.RuleForBaseModel()
            .RuleFor(x => x.ActivityId, f => f.Random.Guid())
            .RuleFor(x => x.CategoryId, f => f.Random.Guid())
            .RuleFor(x => x.JobId, f => f.Random.Guid())
            .RuleFor(x => x.StartTime, f => f.Date.Past())
            .RuleFor(x => x.EndTime, (f, a) => a.StartTime.AddHours(f.Random.Double(1, 8)))
            .RuleFor(x => x.Name, f => f.Lorem.Word())
            .RuleFor(x => x.Description, f => f.Lorem.Sentence());
    }
}