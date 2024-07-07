using Bogus;
using Lib.Models;

namespace UnitTest.Fakes.Models;

public class CategoryFaker : Faker<Category>
{
    public CategoryFaker()
    {
        this.RuleForBaseModel()
            .RuleFor(x => x.CategoryId, f => f.Random.Guid())
            .RuleFor(x => x.Name, f => f.Lorem.Word())
            .RuleFor(x => x.Description, f => f.Lorem.Sentence());
    }
}