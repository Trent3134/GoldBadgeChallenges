using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class Program_UI
{
    private readonly BadgeRepository _bRepo = new BadgeRepository();
    public void run()
    {
        RunApplication2();
        SeedData();
    }

    private void SeedData()
    {
        Badge badgeA = new Badge(new List<string>{"a1", "a5"});
        Badge badgeB = new Badge(new List<string>{"a4", "a7"});
        Badge badgeC = new Badge(new List<string>{"a3", "a5"});
        _bRepo.AddBadgeList(badgeA);
        _bRepo.AddBadgeList(badgeB);
        _bRepo.AddBadgeList(badgeC);

    }

    private void RunApplication2()
    {
        bool isRunning = true;
        while (isRunning)
        {
            Console.Clear();
            System.Console.WriteLine("WELCOME");
            System.Console.WriteLine("please make a selction: \n" +
            "1. Add a Badge. \n" +
            "2. Edit a Badge. \n" +
            "3. List All Badges.");
            var userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    AddBadge();
                    break;
                case "2":
                    editABadge();
                    break;
                case "3":
                    SeeAllBadges();
                    break;
                case "4":
                    isRunning = CloseApplication();
                    break;
                default:
                    System.Console.WriteLine("Invalid Selction");
                    pressAnyKeyToContinue();
                    break;
            }
        }
    }

    private void pressAnyKeyToContinue()
    {
        System.Console.WriteLine("press any key to continue");
        Console.ReadKey();
    }

    private bool CloseApplication()
    {
        Console.Clear();
        pressAnyKeyToContinue();
        return false;
    }

    private void SeeAllBadges()
    {
        Console.Clear();
        var BadgeInDb = _bRepo.GetAllBadgesAndDoors();
        if (BadgeInDb.Count > 0)
        {
            foreach (var badge in BadgeInDb.Values)
            {
                displayBadgeDoorData(badge);
            }
        }
        else
        {
            System.Console.WriteLine("there is no data.");
        }
        pressAnyKeyToContinue();
    }

    private void displayBadgeDoorData(Badge badge)
    {
        System.Console.WriteLine($"BadgeId: {badge.ID} \n"
        );
        System.Console.WriteLine($"dooraccess:  ");
        foreach (var door in badge.Doors)
        {
            System.Console.WriteLine(door);
        }
    }

    private void editABadge()
    {
        Console.Clear();
        var allBadges = _bRepo.GetAllBadgesAndDoors();
        foreach (var badge in allBadges)
        {
            displayBadgeDoorData(badge.Value);
        }
        System.Console.WriteLine("please enter a badge id.");
        var userInputBadgeID = int.Parse(Console.ReadLine());
        var userSelectedBadge = _bRepo.GetBadgeByKey(userInputBadgeID);
        displayBadgeDoorData(userSelectedBadge);
        if (userSelectedBadge != null)
        {
            Console.Clear();
            var currentBadge = new Badge();
            var currentDoors = _bRepo.GetAllBadgesAndDoors();
            System.Console.WriteLine("what would you like to do?");
            System.Console.WriteLine(" ADD OR REMOVE? \n" +
            "1. ADD \n" +
            "2. REMOVE \n");
            var userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    AddUpdatedDoor();
                    break;
                case "2":
                    RemoveUpdatedDoor();
                    break;
                default:
                    System.Console.WriteLine("Invalid Selction");
                    pressAnyKeyToContinue();
                    break;
            }
        }
    }
    private void RemoveUpdatedDoor()
    {
        System.Console.WriteLine("please input a valid badge ID");
        var userInputBadgeID = int.Parse(Console.ReadLine());
        System.Console.WriteLine("please input a door number to delete");
        var userInputDoorName = Console.ReadLine();
        if (_bRepo.RemoveDoorFromBadge(userInputBadgeID, userInputDoorName))
        {
            System.Console.WriteLine("Door was deleted");
        }
        else
        {
            System.Console.WriteLine("door failed to be deleted.");
        }
    }

    private void AddUpdatedDoor()
    {
        System.Console.WriteLine("please input a valid badge ID");
        var userInputBadgeID = int.Parse(Console.ReadLine());
        System.Console.WriteLine("please input a door name");
        var userInputDoorName = Console.ReadLine();
        if (_bRepo.AddDoor(userInputBadgeID, userInputDoorName))
        {
            System.Console.WriteLine("SUCESS");
        }
        else
        {
            System.Console.WriteLine("FAIL");
        }
        pressAnyKeyToContinue();

    }

    private void AddBadge()
    {
        Console.Clear();
        var newBadgeData = new Badge();
        System.Console.WriteLine("create new Badge");
        bool hasAddedAllDoors = false;
        while (!hasAddedAllDoors)
        {
            System.Console.WriteLine("please enter the door name");
            newBadgeData.Doors.Add(Console.ReadLine());
            System.Console.WriteLine("do you want to add another door? y/n");
            var userInputAnotherDoor = Console.ReadLine();
            if (userInputAnotherDoor == "Y".ToLower())
            {
                continue;

            }
            else
            {
                hasAddedAllDoors = true;
            }
        }
        bool isSucessful = _bRepo.AddBadgeList(newBadgeData);
        if (isSucessful)
        {
            System.Console.WriteLine("badge was added!!");
        }
        else
        {
            System.Console.WriteLine("badge failed to be added");
        }


        pressAnyKeyToContinue();

    }


}
