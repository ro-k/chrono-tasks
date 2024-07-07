using Bogus;
using Lib.DTOs;

namespace UnitTest.Fakes.DTOs;

public sealed class RegisterDtoFaker : Faker<RegisterDto>
{
    public RegisterDtoFaker()
    {
        RuleFor(x => x.Email, f => f.Internet.Email())
            .RuleFor(x => x.Username, f => f.Internet.UserName())
            .RuleFor(x => x.Password, f => f.Internet.Password())
            .RuleFor(x => x.FirstName, f => f.Name.FirstName())
            .RuleFor(x => x.LastName, f => f.Name.LastName());
    }
}