using Bogus;
using Lib.DTOs;
using UnitTest.Fakes.Models;

namespace UnitTest.Fakes.DTOs;

public sealed class TreeViewJobDtoFaker : Faker<TreeViewJobDto>
{
    public TreeViewJobDtoFaker()
    {
        new JobFaker().Populate(this);

        RuleFor(x => x.TreeViewActivities, f => new TreeViewActivityDtoFaker().Generate(3));
    }
}