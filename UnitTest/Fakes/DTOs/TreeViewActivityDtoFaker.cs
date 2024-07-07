using Bogus;
using Lib.DTOs;
using UnitTest.Fakes.Models;

namespace UnitTest.Fakes.DTOs;

public class TreeViewActivityDtoFaker : Faker<TreeViewActivityDto>
{
    public TreeViewActivityDtoFaker()
    {
        new ActivityFaker().Populate(this);
    }
}