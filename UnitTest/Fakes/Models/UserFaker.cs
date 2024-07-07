using Bogus;
using Lib.Models;

namespace UnitTest.Fakes.Models;

public class UserFaker : Faker<User>
{
    public UserFaker()
    {
        this.RuleForBaseModel()
            .RuleFor(x => x.UserId, f => f.Random.Guid())
            .RuleFor(x => x.Username, f => f.Internet.UserName())
            .RuleFor(x => x.NormalizedUserName, (f, x) => x.Username.ToUpper())
            .RuleFor(x => x.Email, f => f.Internet.Email())
            .RuleFor(x => x.NormalizedEmail, (f, x) => x.Email.ToUpper())
            .RuleFor(x => x.EmailConfirmed, f => f.Random.Bool())
            .RuleFor(x => x.PasswordHash, f => f.Internet.Password())
            .RuleFor(x => x.SecurityStamp, f => f.Random.AlphaNumeric(32))
            .RuleFor(x => x.PhoneNumber, f => f.Phone.PhoneNumber())
            .RuleFor(x => x.PhoneNumberConfirmed, f => f.Random.Bool())
            .RuleFor(x => x.TwoFactorEnabled, f => f.Random.Bool())
            .RuleFor(x => x.LockoutEnd, f => f.PickRandom(f.Date.Future(), (DateTime?)null))
            .RuleFor(x => x.LockoutEnabled, f => f.Random.Bool())
            .RuleFor(x => x.AccessFailedCount, f => f.Random.Int(0, 10))
            .RuleFor(x => x.ProfilePictureMediaId, f => f.Random.Guid())
            .RuleFor(x => x.FirstName, f => f.Name.FirstName())
            .RuleFor(x => x.LastName, f => f.Name.LastName());
    }
}