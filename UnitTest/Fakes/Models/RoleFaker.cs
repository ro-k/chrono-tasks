using Bogus;
using Lib.Models;

namespace UnitTest.Fakes.Models;

public sealed class RoleFaker : Faker<Role>
{
    public RoleFaker()
    {
        RuleFor(x => x.RoleId, f => f.Random.Guid())
            .RuleFor(x => x.Name, f => f.Lorem.Word())
            .RuleFor(x => x.NormalizedName, f => f.Lorem.Word().ToUpper())
            .RuleFor(x => x.ConcurrencyStamp, f => f.Random.Guid());
    }
}