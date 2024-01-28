using National_Restaurants.Enums;
using National_Restaurants.Models;
using National_Restaurants.Services;
using System.Net.Security;
namespace National_Restaurants.Menu.SubMenus;
public class ChefMenu
{
    private readonly ChefService chefService;

    public ChefMenu(ChefService chefService)
    {
        this.chefService = chefService;
    }

    public async ValueTask Show()
    {
        while (true)
        {
            Console.WriteLine("=====Chef Menu\n===== ");
            Console.WriteLine("1.Create");
            Console.WriteLine("2.Update");
            Console.WriteLine("3.Delete");
            Console.WriteLine("4.Get All");
            Console.WriteLine("5.Get By Id");
            Console.WriteLine("6.Created New Food");
            Console.WriteLine("7.RemoveCreated Food");
            Console.WriteLine("8.Exit");
            Console.WriteLine("Choose an option");
            string choice = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(choice))
            {
                Console.WriteLine("Choose a valid option");
                choice = Console.ReadLine();
            }
            switch (choice)
            {
                case "1":
                    Console.Clear();
                    await CreateAsync();
                    Console.WriteLine();
                    break;
                case "2":
                    Console.Clear();
                    await UpdateAsync();
                    Console.WriteLine();
                    break;
                case "3":
                    Console.Clear();
                    await DeleteAsync();
                    Console.WriteLine();
                    break;
                case "4":
                    Console.Clear();
                    await GetAllAsync();
                    Console.WriteLine();
                    break;
                case "5":
                    Console.Clear();
                    await GetByIdAsync();
                    Console.WriteLine();
                    return;
                case "6":
                    Console.Clear();
                    await CreatedNewFoodAsync();
                    Console.WriteLine();
                    return;
                case "7":
                    Console.Clear();
                    await RemoveCreatedFoodAsync();
                    Console.WriteLine();
                    return;
                case "8":
                    Console.Clear();
                    Console.WriteLine("Exit");
                    Console.WriteLine();
                    return;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid choice,Please try again one more time");
                    Console.WriteLine();
                    break;

            }
        }
    }

    private async ValueTask CreatedNewFoodAsync()
    {
        Console.WriteLine("\n=== Create new food ===");
        Console.WriteLine("Enter Id:");
        int chefid;
        while (!int.TryParse(Console.ReadLine(), out chefid))
        {
            Console.WriteLine("Enter a valid id");
        }
        var newFood = new Food();

        Console.Write("Enter food Name: ");
        string Name = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(Name))
        {
            Console.Write("Enter valid input: ");
            Name = Console.ReadLine();
        }
        Console.Write("Enter the Description: ");
        string Description = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(Description))
        {
            Console.Write("Enter valid input: ");
            Description = Console.ReadLine();
        }
        Console.WriteLine("Enter the price(by decimal number)");
        decimal Price;
        while (!decimal.TryParse(Console.ReadLine(), out Price))
        {
            Console.WriteLine("Please enter a valid input");
        }
        reenterdrinks:
        await Console.Out.WriteLineAsync("How many drinks you want to include, 1-3");
        var drinkscount = Console.ReadLine();
        List<string> drinks = null;
        if (drinkscount == "3") 
        {
            drinks = new List<string>();
            await Console.Out.WriteLineAsync("enter first drink's name");
            var first=  Console.ReadLine(); 
            await Console.Out.WriteLineAsync("enter first drink's name");
            var second = Console.ReadLine(); 
            await Console.Out.WriteLineAsync("enter first drink's name");
            var last = Console.ReadLine();
            
            drinks.Add(first);
            drinks.Add(second);
            drinks.Add(last);
        } else if (drinkscount == "2") 
        {
            drinks = new List<string>();
            await Console.Out.WriteLineAsync("enter first drink's name");
            var first = Console.ReadLine();
            await Console.Out.WriteLineAsync("enter first drink's name");
            var second = Console.ReadLine();

            drinks.Add(first);
            drinks.Add(second);
        } else if (drinkscount == "1")
        {
            drinks = new List<string>();
            await Console.Out.WriteLineAsync("enter first drink's name");
            var first = Console.ReadLine();

            drinks.Add(first);
        } else
        {
            await Console.Out.WriteLineAsync("enter valid number. press any key to reenter...");
            Console.ReadLine();
            goto reenterdrinks;
        }

        CreatedFood createdFood = new CreatedFood();
        createdFood.Name = Name;
        createdFood.ChefId = chefid;
        createdFood.Description = Description;
        createdFood.Price = Price;
        createdFood.Included_Drinks = drinks;

        var result = await chefService.CreateNewFood(chefid, createdFood);
        if (result != null)
        {
            await Console.Out.WriteLineAsync("Food Created Successfully");
        }
    }

    private async ValueTask RemoveCreatedFoodAsync()
    {
        Console.WriteLine("\n=== Remove created food ===");
        Console.WriteLine("Enter chefId:");
        int chefid = 0;
        while (!int.TryParse(Console.ReadLine(), out chefid))
        {
            Console.WriteLine("Enter a valid id");
        }
        Console.WriteLine("Enter foodId:");
        int foodid = 0 ;
        while (!int.TryParse(Console.ReadLine(), out chefid))
        {
            Console.WriteLine("Enter a valid id");
        }
        var result = await chefService.RemoveCreatedFood(chefid, foodid);
        if (result is false)
        {
            await Console.Out.WriteLineAsync("Food Successfully deleted");
        }
    }

    private async ValueTask CreateAsync()
    {
        var newChef = new Chef();
        Console.WriteLine("\n=== Create Chef ===");
        Console.Write("Enter Name: ");
        string Name = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(Name))
        {
            Console.Write("Enter valid input: ");
            Name = Console.ReadLine();
        }
        Console.Write("Enter Specialization: ");
        string Specialization = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(Specialization))
        {
            Console.Write("Enter valid input: ");
            Specialization = Console.ReadLine();
        }

    reentertypecreate:
        Console.WriteLine("Enter Chef Level");
        Console.WriteLine(" 1.CommisChef");
        Console.WriteLine(" 2.ChefDePartie");
        Console.WriteLine(" 3.SousChef");
        Console.WriteLine(" 4.HeadChef");
        Console.WriteLine("5.ChefPatron");

        string cheflevel = Console.ReadLine();
        switch (cheflevel)
        {
            case "1":
                newChef.Level = Convert.ToString(ChefLevel.CommisChef);
                break;
            case "2":
                newChef.Level = Convert.ToString(ChefLevel.ChefDePartie);

                break;
            case "3":
                newChef.Level = Convert.ToString(ChefLevel.SousChef);

                break;
            case "4":
                newChef.Level = Convert.ToString(ChefLevel.HeadChef);
                break;
            case "5":
                newChef.Level = Convert.ToString(ChefLevel.ChefPatron);
                break;

            default:
                Console.WriteLine("wrong choice, Press any key to re-enter");
                goto reentertypecreate;
        }

        Console.WriteLine("Enter the working Experience by floating number");
        float experience;
        while (!float.TryParse(Console.ReadLine(), out experience))
        {
            Console.WriteLine("Please enter a valid input");
        }
        Console.Write("Enter Cooks(What is the chef cooking ?) : ");
        string cooks = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(cooks))
        {
            Console.Write("Enter valid input: ");
            cooks = Console.ReadLine();
        }
        await chefService.CreateAsync(newChef);
        Console.WriteLine("Chef information created successfully.");
    }



    private async ValueTask UpdateAsync()
    {
        var newChef = new Chef();

        Console.WriteLine("\n=== update Chef information ===");
        Console.WriteLine("Enter Id:");
        int id;
        while (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("Enter a valid id");
        }
        Console.Write("Enter Name: ");
        string updateName = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(updateName))
        {
            Console.Write("Enter valid input: ");
            updateName = Console.ReadLine();
        }
        Console.Write("Enter Specialization: ");
        string updateSpecialization = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(updateSpecialization))
        {
            Console.Write("Enter valid input: ");
            updateSpecialization = Console.ReadLine();
        }
    reentertypecreate:
        Console.WriteLine("Enter Chef Level");
        Console.WriteLine(" 1.CommisChef");
        Console.WriteLine(" 2.ChefDePartie");
        Console.WriteLine(" 3.SousChef");
        Console.WriteLine(" 4.HeadChef");
        Console.WriteLine("5.ChefPatron");

        string cheflevel = Console.ReadLine();
        switch (cheflevel)
        {
            case "1":
                newChef.Level = Convert.ToString(ChefLevel.CommisChef);
                break;
            case "2":
                newChef.Level = Convert.ToString(ChefLevel.ChefDePartie);

                break;
            case "3":
                newChef.Level = Convert.ToString(ChefLevel.SousChef);

                break;
            case "4":
                newChef.Level = Convert.ToString(ChefLevel.HeadChef);
                break;
            case "5":
                newChef.Level = Convert.ToString(ChefLevel.ChefPatron);
                break;

            default:
                Console.WriteLine("wrong choice, Press any key to re-enter");
                goto reentertypecreate;
        }

        Console.WriteLine("Enter the working Experience to update by floating number");
        float updateExperience;
        while (!float.TryParse(Console.ReadLine(), out updateExperience))
        {
            Console.WriteLine("Please enter a valid input");
        }
        Console.Write("Enter Cooks(What is the chef cooking ?) : ");
        string updateCooks = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(updateCooks))
        {
            Console.Write("Enter valid input: ");
            updateCooks = Console.ReadLine();
        }
        await chefService.UpdateAsync(id, newChef);
        Console.WriteLine("Chef information  updated successfully.");
    }

    private async ValueTask DeleteAsync()
    {
        Console.WriteLine("===Delete Chef===");
        Console.WriteLine("Enter chef Id to delete");
        int id;
        while (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("Please enter a valid id");
        }
        if (await chefService.DeleteAsync(id))
        {
            Console.WriteLine("chef deleted successfully");
        }
        else
        {
            Console.WriteLine($"Chef with Id {id} not found");
        }
    }

    private async ValueTask GetAllAsync()
    {
        Console.WriteLine("===View all Chef==");
        List<Chef> chefs = await chefService.GetAllAsync();
        if (chefs.Count > 0)
        {
            foreach (var chef in chefs)
            {
                Console.WriteLine($"{chef.Id} {chef.Name} {chef.Specialization} {chef.Level}" +
                    $"{chef.Experience} {chef.Cooks}");

            }
        }
        else
        {
            Console.WriteLine("Sorry, Chef not found");
        }
    }
    private async ValueTask GetByIdAsync()
    {
        Console.WriteLine("====Get By Id====");
        Console.WriteLine("Enter the Id:");
        int id;
        while (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("Enter a valid id");
        }
        var chef = await chefService.GetByIdAsync(id);
        if (chef == null)
        {
            Console.WriteLine("Chef not found");
        }
        else
        {
            Console.WriteLine($"Id:{chef.Id} | ChefName {chef.Name} | ChefLevel {chef.Level} " +
                $" Chef Specialization{chef.Specialization} Chef Experience {chef.Experience} " +
                $"Chef Cooks{chef.Cooks}");
        }
    }
}