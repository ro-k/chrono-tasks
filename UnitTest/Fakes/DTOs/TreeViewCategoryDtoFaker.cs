using Bogus;
using Lib.DTOs;
using UnitTest.Fakes.Models;

namespace UnitTest.Fakes.DTOs;

public class TreeViewCategoryDtoFaker : Faker<TreeViewCategoryDto>
{
    public TreeViewCategoryDtoFaker()
    {
        this.RuleForBaseModel()
            .RuleFor(x => x.CategoryId, f => f.Random.Guid())
            .RuleFor(x => x.Name, f => f.Lorem.Word())
            .RuleFor(x => x.Description, f => f.Lorem.Sentence())
            .RuleFor(x => x.TreeViewActivities, f => new TreeViewActivityDtoFaker().Generate(3))
            .RuleFor(x => x.TreeViewJobs, f => new TreeViewJobDtoFaker().Generate(3));
    }
}