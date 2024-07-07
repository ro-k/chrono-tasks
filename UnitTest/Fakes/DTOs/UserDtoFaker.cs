using Bogus;
using Lib.DTOs;
using Lib.Models;

namespace UnitTest.Fakes.DTOs;

public sealed class UserDtoFaker : Faker<UserDto>
{
    public UserDtoFaker()
    {
        RuleFor(x => x.UserId, f => f.Random.Guid())
            .RuleFor(x => x.Username, f => f.Internet.UserName())
            .RuleFor(x => x.Email, f => f.Internet.Email())
            .RuleFor(x => x.EmailConfirmed, f => f.Random.Bool())
            .RuleFor(x => x.PhoneNumber, f => f.Phone.PhoneNumber())
            .RuleFor(x => x.PhoneNumberConfirmed, f => f.Random.Bool())
            .RuleFor(x => x.TwoFactorEnabled, f => f.Random.Bool())
            .RuleFor(x => x.ProfilePictureMediaId, f => f.Random.Guid())
            .RuleFor(x => x.FirstName, f => f.Name.FirstName())
            .RuleFor(x => x.LastName, f => f.Name.LastName())
            .RuleFor(x => x.CreatedAt, f => f.Date.Past())
            .RuleFor(x => x.ModifiedAt, f => f.Date.Recent())
            .RuleFor(x => x.ConcurrencyStamp, f => f.Random.Guid())
            .RuleFor(x => x.Status, f => f.PickRandom<Status>());
    }
}