using Bogus;
using Lib.Models;

namespace UnitTest.Fakes.Models;
public static class BaseModelFakerExtensions
{
    public static Faker<T> RuleForBaseModel<T>(this Faker<T> faker) where T : BaseModel
    {
        faker.RuleFor(x => x.CreatedAt, f => f.Date.Past())
            .RuleFor(x => x.ModifiedAt, f => f.Date.Recent())
            .RuleFor(x => x.UserId, f => f.Random.Guid())
            .RuleFor(x => x.ConcurrencyStamp, f => f.Random.Guid())
            .RuleFor(x => x.Status, f => f.PickRandom<Status>());
        return faker;
    }
}