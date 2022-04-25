using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class Program_UI
{
    private readonly ClaimsRepository _cRepo = new ClaimsRepository();
    public void Run()
    {
        // SeedData();
        RunApplication();
    }

    //  private void SeedData()
    // {
    // Claims claimA = new Claims(100, ClaimTypes.Car, "stolen car", 1, new DateTime(2022,04,07), new DateTime(2022,04,08));
    // Claims claimB = new Claims(100, ClaimTypes.Car, "stolen radio", 100, new DateTime(2022,04,07), new DateTime(2022,04,08));
    // Claims claimC = new Claims(100, ClaimTypes.Home, "stolen phone", 123, new DateTime(2022,04,07), new DateTime(2022,04,08));
    //    _cRepo.AddClaimToQueue(claimA);
    //    _cRepo.AddClaimToQueue(claimB);
    //    _cRepo.AddClaimToQueue(claimC);

    // }
     
 

    private void RunApplication()
    {
        bool isRunning = true;
        while (isRunning)
        {
            Console.Clear();
            System.Console.WriteLine("welcome to Komodo Claims");
            System.Console.WriteLine("Please make a selection\n" +
            "1. See all claims\n" +
            "2. Next Claim\n" +
            "3. Enter A NEW Claim\n" +
            "4. Close Application");
            var userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    SeeAllClaims();
                    break;
                case "2":
                    NextClaim();
                    break;
                case "3":
                    NewClaim();
                    break;
                case "4":
                    isRunning = CloseApplication();
                    break;
                default:
                    System.Console.WriteLine("Invalid Selection");
                    PressAnyKeyToContinue();
                    break;
            }
        }
    }


    private void PressAnyKeyToContinue()
    {
        System.Console.WriteLine("Press Any Key to continue...");
        Console.ReadKey();
    }

    private bool CloseApplication()
    {
        Console.Clear();
        System.Console.WriteLine("Goodbye");
        PressAnyKeyToContinue();
        return false;
    }


    private void DisplayClaimsData(Claims claims)
    {
        System.Console.WriteLine($"ClaimID: {claims.ID}\n" +
        $"Claim type:{claims.ClaimTypes}\n" +
       $"Description: {claims.Description}\n" +
       $"ClaimAmount: {claims.ClaimAmount}\n" +
       $"DateOfIncident: {claims.DateOfIncident}\n" +
       $"DateOfClaim: {claims.DateOfClaim}\n" +
       $"isValid: {claims.IsValid}"); 
    }

    private void NewClaim()
    {
        Console.Clear();
        var newClaimData = new Claims();
        System.Console.WriteLine("Create new claim");
        System.Console.WriteLine("please enter claim number");
        newClaimData.ID = int.Parse(Console.ReadLine());
        System.Console.WriteLine("please enter type of claim");
        System.Console.WriteLine("select a type: \n" +
        "1. Car \n" +
        "2. Auto \n" +
        "3. Theft \n");
        var claimTypes = int.Parse(Console.ReadLine());
        newClaimData.ClaimTypes = (ClaimTypes)claimTypes; // we are casting ClaimsType enum 
        System.Console.WriteLine("please enter a description of accident");
        newClaimData.Description = Console.ReadLine();
        System.Console.WriteLine("please enter the Amount.");
        newClaimData.ClaimAmount = int.Parse(Console.ReadLine());
        System.Console.WriteLine("When did the accident take place?");
        newClaimData.DateOfIncident = DateTime.Parse(Console.ReadLine());
        System.Console.WriteLine("when did you file the claim?");
        newClaimData.DateOfClaim = DateTime.Parse(Console.ReadLine());
        bool isSuccessful = _cRepo.AddClaimToQueue(newClaimData);
        if (isSuccessful) 
        {
            //TimeSpan numberOfDays = newClaimData - DateOfIncident

            System.Console.WriteLine("Claim was added!");
        }
        else
        {
        System.Console.WriteLine("our policey is 30 days after the incident to get your claim in place");
            System.Console.WriteLine("Claim Failed to be added.");
        }
    PressAnyKeyToContinue();

    }

    private void NextClaim()
    {
        Console.Clear();
        System.Console.WriteLine("Next up claims");
        if (_cRepo.GetAllClaims().Count > 0)
        {
            var nextClaim = _cRepo.GetClaim();
            DisplayClaimsData(nextClaim);
            System.Console.WriteLine("would you like to process this claim? y/n");
            var userInput = Console.ReadLine();
            if (userInput == "Y".ToLower())
            {
                if (_cRepo.NextUpClaim())
                {
                    Console.Clear();
                    System.Console.WriteLine("Success");
                }

                else
                {
                    Console.Clear();
                    System.Console.WriteLine("Claim Failed to process");
                }
            }
        }
        else
        {
        System.Console.WriteLine("There are no more claims left!");
        }
    }

    private void SeeAllClaims()
    {
        Console.Clear();
        var ClaimsInDb = _cRepo.GetAllClaims();
        if (ClaimsInDb.Count > 0)
        {
            foreach (var claim in ClaimsInDb)
            {
                DisplayClaimsData(claim);
            }
        }
        else
        {
            System.Console.WriteLine("there are no claims");
        }
        PressAnyKeyToContinue();
    }
}
