using National_Restaurants.Enums;
using National_Restaurants.Models;
using National_Restaurants.Services;
namespace National_Restaurants.Menu.SubMenus;
public class RestaurantMenu
{
    private readonly RestaurantService restaurantService;

    public RestaurantMenu(RestaurantService restaurantService)
    {
        this.restaurantService = restaurantService;
    }
    public async Task Show()
    {
        while (true)
        {
            Console.WriteLine("=====Restaurant Menu\n===== ");
            Console.WriteLine("1.Create");
            Console.WriteLine("2.Add Food");
            Console.WriteLine("3.Update");
            Console.WriteLine("4.Delete");
            Console.WriteLine("5.Remove Food");
            Console.WriteLine("6.Get All");
            Console.WriteLine("7.Get By Id");
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
                    await AddFoodAsync();
                    Console.WriteLine();
                    break;
                case "3":
                    Console.Clear();
                    await UpdateAsync();
                    Console.WriteLine();
                    break;
                case "4":
                    Console.Clear();
                    await DeleteAsync();
                    Console.WriteLine();
                    break;
                case "5":
                    Console.Clear();
                    await RemoveFood();
                    Console.WriteLine();
                    break;
                case "6":
                    Console.Clear();
                    await GetAllAsync();
                    Console.WriteLine();
                    break;
                case "7":
                    Console.Clear();
                    await GetByIdAsync();
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

    private async ValueTask AddFoodAsync()
    {
        await Console.Out.WriteLineAsync("==Addfood==");
        await Console.Out.WriteLineAsync("Enter restaurant id:");
        int restaurantid = 0;
        while (!int.TryParse(Console.ReadLine(), out restaurantid))
        {
            await Console.Out.WriteLineAsync("Enter a valid input");
        }
        await Console.Out.WriteLineAsync("Enter foodid:");
        int foodid = 0;
        while (!int.TryParse(Console.ReadLine(), out foodid))
        {
            await Console.Out.WriteLineAsync("Enter a valid input");
        }
        var result = restaurantService.AddFoodAsync(restaurantid, foodid);
        if (result != null)
        {
            Console.WriteLine("Food added successfully");
        }
    }

    private async ValueTask RemoveFood()
    {
        await Console.Out.WriteLineAsync("==Removefood==");
        await Console.Out.WriteLineAsync("Enter restaurant id:");
        int restaurantid = 0;
        while (!int.TryParse(Console.ReadLine(), out restaurantid))
        {
            await Console.Out.WriteLineAsync("Enter a valid input");
        }
        await Console.Out.WriteLineAsync("Enter foodid:");
        int foodid = 0;
        while (!int.TryParse(Console.ReadLine(), out foodid))
        {
            await Console.Out.WriteLineAsync("Enter a valid input");
        }
        var result = restaurantService.RemoveFoodAsync(foodid, restaurantid);
        if (result != null)
        {
            Console.WriteLine("Food removed successfully");
        }
    }
    private async ValueTask CreateAsync()
    {
        await Console.Out.WriteLineAsync("Create restaurant");
        Restaurant restaurant = new Restaurant();

reentertypecreate:
        Console.WriteLine("Enter Restaurant Type");
        Console.WriteLine(" 1.National");
        Console.WriteLine(" 2.Other");
        string restaurantType = Console.ReadLine();
        switch (restaurantType)
        {
            case "1":
                restaurant.RestaurantType = Convert.ToString(RestaurantType.National);
                break;
            case "2":
                restaurant.RestaurantType = Convert.ToString(RestaurantType.Other);
                break;
            default:
                Console.WriteLine("wrong choice, Press any key to re-enter");
                goto reentertypecreate;
        }

        Console.Write("Enter Restaurant Name: ");
        string Name = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(Name))
        {
            Console.Write("Enter valid input: ");
            Name = Console.ReadLine();
        }
        Console.Write("Enter Restaurant Location: ");
        string Location = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(Location))
        {
            Console.Write("Enter valid input: ");
            Location = Console.ReadLine();
        }

        restaurant.Name = Name;
        restaurant.Location = Location;


        var result = restaurantService.CreateAsync(restaurant);
        if (result != null)
        {
            await Console.Out.WriteLineAsync("restaurant created successfully");
        }
    }
    private async ValueTask UpdateAsync()
    {
        await Console.Out.WriteLineAsync("Update Restaurant");
        Restaurant restaurant = new Restaurant();

        await Console.Out.WriteLineAsync("Enter an Id");
        int id = 0;
        while (!int.TryParse(Console.ReadLine(), out id))
        {
            await Console.Out.WriteLineAsync("Enter a valid input");
        }
reentertypecreate:
        Console.WriteLine("Enter Restaurant Type");
        Console.WriteLine(" 1.National");
        Console.WriteLine(" 2.Other");
        string restaurantType = Console.ReadLine();
        switch (restaurantType)
        {
            case "1":
                restaurant.RestaurantType = Convert.ToString(RestaurantType.National);
                break;
            case "2":
                restaurant.RestaurantType = Convert.ToString(RestaurantType.Other);
                break;
            default:
                Console.WriteLine("wrong choice, Press any key to re-enter");
                goto reentertypecreate;
        }

        Console.Write("Enter Restaurant Name: ");
        string Name = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(Name))
        {
            Console.Write("Enter valid input: ");
            Name = Console.ReadLine();
        }
        Console.Write("Enter Restaurant Location: ");
        string Location = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(Location))
        {
            Console.Write("Enter valid input: ");
            Location = Console.ReadLine();
        }


        restaurant.Name = Name;
        restaurant.Location = Location;

        var result = restaurantService.UpdateAsync(id, restaurant);
        if (result != null)
        {
            await Console.Out.WriteLineAsync("restaurant created successfully");
        }
    }
    private async ValueTask DeleteAsync()
    {
        Console.WriteLine("===Delete Restaurant===");
        Console.WriteLine("Enter restaurant Id to delete");
        int id;
        while (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("Please enter a valid id");
        }
        if (await restaurantService.DeleteAsync(id))
        {
            Console.WriteLine("restaurant deleted successfully");
        }
        else
        {
            Console.WriteLine($"restaurant with Id {id} not found");
        }
    }
    private async ValueTask GetAllAsync()
    {
        Console.WriteLine("===View all Restaurants==");
        List<Restaurant> restaurants = await restaurantService.GetAllAsync();
        if (restaurants is not null)
        {
            foreach (var item in restaurants)
            {
                Console.WriteLine($"{item.Id} {item.Name} {item.Location} {item.CreatedAt}" +
                    $"{item.EditedAt}\n");
            }
        }
        else
        {
            Console.WriteLine("Sorry, restaurants not found");
        }
    }
    private async ValueTask GetByIdAsync()
    {
        Console.WriteLine("===Get Restaurant by id ==");
        List<Restaurant> restaurants = await restaurantService.GetAllAsync();
        if (restaurants is not null)
        {
            foreach (var item in restaurants)
            {
                Console.WriteLine($"{item.Id} {item.Name} {item.Location} {item.CreatedAt}" +
                    $"{item.EditedAt}\n");
            }
        }
        else
        {
            Console.WriteLine("Sorry, restaurants not found");
        }
    }
}
