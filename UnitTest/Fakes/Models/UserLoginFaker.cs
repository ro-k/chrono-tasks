using Bogus;
using Lib.Models;

namespace UnitTest.Fakes.Models
{
    public class UserLoginFaker : Faker<UserLogin>
    {
        public UserLoginFaker()
        {
            this.RuleForBaseModel()
                .RuleFor(x => x.UserLoginId, f => f.Random.Guid())
                .RuleFor(x => x.LoginProvider, f => f.Company.CompanyName())
                .RuleFor(x => x.ProviderKey, f => f.Random.AlphaNumeric(20))
                .RuleFor(x => x.ProviderDisplayName, f => f.Company.CompanyName());
        }
    }
}