using System;
using Xunit;

namespace _02_Repositories.Tests;

public class UnitTest1
{
    private readonly ClaimsRepository _crepo;
    private readonly Claims _claim;
    public UnitTest1()
    {
        _crepo = new ClaimsRepository();
        SeedData();
       // _claim = new Claims(ClaimTypes.Car, "hit and run", 100, new DateTime(2022, 11, 11), new DateTime(2022, 11, 21));
    }
    [Fact]
    public void AddClaimToQueue_ShouldReturnTrue()
    {
        //assert
        Assert.True(_crepo.AddClaimToQueue(_claim));
    }
    [Fact]
    public void GetAllClaims_ShouldReturnCount()
    {
        int expected = 1;
        Assert.Equal(expected, _crepo.GetAllClaims().Count);
    }

    [Fact]
    public void GetClaim_ShouldReturnClaim()
    {
      int expected = 3;
      Assert.Equal(expected, _crepo.GetAllClaims().Count);

    }

    [Fact]
    public void NextUpClaim_ShouldReturnNextClaim()
    {
      
        var expected = _crepo.NextUpClaim();
        Assert.True(expected);
    
    }

 private void SeedData()
    {
    Claims claimA = new Claims( ClaimTypes.Car, "stolen car", 1, new DateTime(2022,04,07), new DateTime(2022,04,08));
    Claims claimB = new Claims( ClaimTypes.Car, "stolen radio", 100, new DateTime(2022,04,07), new DateTime(2022,04,08));
    Claims claimC = new Claims( ClaimTypes.Home, "stolen phone", 123, new DateTime(2022,04,07), new DateTime(2022,04,08));
       _crepo.AddClaimToQueue(claimA);
       _crepo.AddClaimToQueue(claimB);
       _crepo.AddClaimToQueue(claimC);

    }

}