using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class Claims
{
    public Claims() { }
    public Claims( ClaimTypes claimTypes, string description, int claimAmount, DateTime dateOfIncident, DateTime dateOfClaim)
    {
        
        ClaimTypes = claimTypes;
        Description = description;
        ClaimAmount = claimAmount;
        DateOfIncident = dateOfIncident;
        DateOfClaim = dateOfClaim;
    }

    public int ID { get; set; }
    public ClaimTypes ClaimTypes { get; set; }
    public string Description { get; set; }
    public int ClaimAmount { get; set; }
    public DateTime DateOfIncident { get; set; }
    public DateTime DateOfClaim { get; set; }
    public bool IsValid
    {
        get
        {
            return IsValidClaim(DateOfIncident, DateOfClaim);
        }
    }
    private bool IsValidClaim(DateTime dateOfIncident, DateTime dateOfClaim)
    {
        TimeSpan spanOfTime = dateOfClaim - dateOfIncident;
        System.Console.WriteLine(spanOfTime);
        if (spanOfTime.Days > 30)
        {
            return false;
        }
        return true;
    }


}
