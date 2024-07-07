using Bogus;
using Lib.DTOs;

namespace UnitTest.Fakes.DTOs;

public sealed class LoginDtoFaker : Faker<LoginDto>
{
    public LoginDtoFaker()
    {
        RuleFor(x => x.Username, f => f.Internet.UserName())
            .RuleFor(x => x.Password, f => f.Internet.Password());
    }
}