using System.Collections.Generic;
using Xunit;

namespace _03_Repositories.Tests;

public class UnitTest1
{
    private readonly BadgeRepository _bRepo;
    private readonly Badge _badge;
    public UnitTest1()
    {
        _bRepo = new BadgeRepository();
        SeedData();
        // _badge = new Badge("a5", "a1");
    }
    [Fact]
    public void AddBadgeList_shouldReturnTrue()
    {
        Badge badgeD = new Badge(new List<string> { "a3", "a5", "A8" });
        _bRepo.AddBadgeList(badgeD);
        Assert.True(_bRepo.AddBadgeList(badgeD));
    }

    [Fact]
    public void GetAllBadgesAndDoors_shouldReturnCount()
    {
        int expected = 3;
        Assert.Equal(expected, _bRepo.GetAllBadgesAndDoors().Count);
    }

    [Fact]
    public void GetBadgeByKey_shouldReturnBadgeKey()
    {

        var expected = "a1";
        var expected2 = "a5";
        var actual = _bRepo.GetBadgeByKey(1);

        Assert.True(actual.Doors.Contains(expected));
        Assert.True(actual.Doors.Contains(expected2));
    }
    [Fact]
    public void AddDoor_shouldReturnDoor()
    {
        Badge badgeA = new Badge(new List<string> { "a1", "a5" });

        var expected = _bRepo.AddDoor(1, "a1");
        var actual = _badge;
        Assert.True(expected);

    }
    [Fact]
    public void RemoveDoorFromBadge_shouldReturnTrue()
    {
        Badge badgeB = new Badge(new List<string> { "a4", "a7" });

        var expected = _bRepo.RemoveDoorFromBadge(1,"a5");

        Assert.True(expected);
    }

    private void SeedData()
    {
        Badge badgeA = new Badge(new List<string> { "a1", "a5" });
        Badge badgeB = new Badge(new List<string> { "a4", "a7" });
        Badge badgeC = new Badge(new List<string> { "a3", "a5" });
        _bRepo.AddBadgeList(badgeA);
        _bRepo.AddBadgeList(badgeB);
        _bRepo.AddBadgeList(badgeC);

    }
}