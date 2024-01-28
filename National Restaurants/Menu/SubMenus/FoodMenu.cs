using National_Restaurants.Models;
using National_Restaurants.Services;
namespace National_Restaurants.Menu;
public class FoodMenu
{
    private readonly FoodService foodService;

    public FoodMenu(FoodService foodService)
    {
        this.foodService = foodService;
    }
    public async Task Show()
    {
        while (true)
        {
            Console.WriteLine("=====Food Menu\n===== ");
            Console.WriteLine("1.Get National Foods");
            Console.WriteLine("2.Get Other Foods");
            Console.WriteLine("3.Get National Food by id");
            Console.WriteLine("4.Get Other Food by id");
            Console.WriteLine("_____________ Filter _____________");
            Console.WriteLine("  5. ByPrive Higher");
            Console.WriteLine("  6. ByPrice Lower");
            Console.WriteLine("7.Exit");
            Console.WriteLine("Choose an option");
            string choice = Console.ReadLine();
            while (String.IsNullOrWhiteSpace(choice))
            {
                Console.WriteLine("Choose a valid option");
                choice = Console.ReadLine();
            }
            switch (choice)
            {
                case "1":
                    Console.Clear();
                    await GetAllNationalFoods();
                    Console.WriteLine();
                    break;
                case "2":
                    Console.Clear();
                    await GetAllOtherFoods();
                    Console.WriteLine();
                    break;
                case "3":
                    Console.Clear();
                    await GetByIdNationalAsync();
                    Console.WriteLine();
                    break;
                case "4":
                    Console.Clear();
                    await GetByIdOtherslAsync();
                    Console.WriteLine();
                    break;
                case "5":
                    Console.Clear();
                    await GetAllFoodsPyPriceHigher();
                    Console.WriteLine();
                    break;
                case "6":
                    Console.Clear();
                    await GetAllFoodsPyPriceLower();
                    Console.WriteLine();
                    break;
                case "7":
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
    
    private async ValueTask GetAllNationalFoods()
    {
        Console.WriteLine("===View all National Food==");
        List<Food> foods = await foodService.GetAllNationalFoods();
        if (foods.Count > 0)
        {
            foreach (var food in foods)
            {
                Console.WriteLine($"Id:{food.Id} Name:{food.Name} Description:{food.Description}" +
                    $" Price: {food.Price} Included_Drinks:{food.Included_Drinks}");
            }
        }
        else
        {
            Console.WriteLine("Sorry, Foods not found");
        }
    }
    private async ValueTask GetAllOtherFoods()
    {
        Console.WriteLine("===View all Other Food==");
        List<Food> foods = await foodService.GetAllOtherFoods();
        if (foods.Count > 0)
        {
            foreach (var food in foods)
            {
                Console.WriteLine($"Id:{food.Id} Name:{food.Name} Description:{food.Description}" +
                    $" Price: {food.Price} Included_Drinks:{food.Included_Drinks}");
            }
        }
        else
        {
            Console.WriteLine("Sorry, Foods not found");
        }
    }
    private async ValueTask GetByIdNationalAsync()
    {
        Console.WriteLine("====Get By Id national====");
        Console.WriteLine("Enter the Id:");
        int id;
        while (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("Enter a valid id");
        }
        var food = await foodService.GetByIdNational(id);
        if (food == null)
        {
            Console.WriteLine("Food not found");
        }
        else
        {
            Console.WriteLine($"Id:{food.Id} | FoodName {food.Name} | Description:{food.Description}" +
                $"Price:{food.Price} Included_Drinks: {food.Included_Drinks}");
        }
    }
    private async ValueTask GetByIdOtherslAsync()
    {
        Console.WriteLine("====Get By Id Others====");
        Console.WriteLine("Enter the Id:");
        int id;
        while (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("Enter a valid id");
        }
        var food = await foodService.GetByIdOthers(id);
        if (food == null)
        {
            Console.WriteLine("Food not found");
        }
        else
        {
            Console.WriteLine($"Id:{food.Id} | FoodName {food.Name} | Description:{food.Description}" +
                $"Price:{food.Price} Included_Drinks: {food.Included_Drinks}");
        }
    }
    private async ValueTask GetAllFoodsPyPriceHigher()
    {
        Console.WriteLine("===View all Foods by price (Higher)==");
        List<Food> foods = await foodService.SortByHigherPrice();
        if (foods.Count > 0)
        {
            foreach (var food in foods)
            {
                Console.WriteLine($"Id:{food.Id} Name:{food.Name} Description:{food.Description}" +
                    $" Price: {food.Price} Included_Drinks:{food.Included_Drinks}");
            }
        }
        else
        {
            Console.WriteLine("Sorry, Foods not found");
        }
    }
    private async ValueTask GetAllFoodsPyPriceLower()
    {
        Console.WriteLine("===View all Foods by price (Lower)==");
        List<Food> foods = await foodService.SortByLowerPrice();
        if (foods.Count > 0)
        {
            foreach (var food in foods)
            {
                Console.WriteLine($"Id:{food.Id} Name:{food.Name} Description:{food.Description}" +
                    $" Price: {food.Price} Included_Drinks:{food.Included_Drinks}");
            }
        }
        else
        {
            Console.WriteLine("Sorry, Foods not found");
        }
    }
}


