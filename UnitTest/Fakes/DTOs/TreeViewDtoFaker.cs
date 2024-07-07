using Bogus;
using Lib.DTOs;

namespace UnitTest.Fakes.DTOs;

public sealed class TreeViewDtoFaker : Faker<TreeViewDto>
{
    public TreeViewDtoFaker()
    {
        RuleFor(x => x.Categories, f => new TreeViewCategoryDtoFaker().Generate(3));
    }
}