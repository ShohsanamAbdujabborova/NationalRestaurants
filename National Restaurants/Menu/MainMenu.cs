using National_Restaurants.API;
using National_Restaurants.Menu.SubMenus;
using National_Restaurants.Services;
using Spectre.Console;
namespace National_Restaurants.Menu;
public class MainMenu
{
    private FoodAPI foodAPI;

    private readonly ChefMenu chefMenu;
    private readonly FoodMenu foodMenu;
    private readonly RestaurantMenu restaurantMenu;

    private readonly ChefService chefService;
    private readonly FoodService foodService;
    private readonly RestaurantService restaurantService;

    public MainMenu()
    {
        foodAPI = new FoodAPI();
        foodAPI.GetDataAsync().Wait();
     
        chefService = new ChefService(foodService);
        foodService = new FoodService(foodAPI);
        restaurantService = new RestaurantService(foodService);

        chefMenu = new ChefMenu(chefService);
        foodMenu = new FoodMenu(foodService);
        restaurantMenu = new RestaurantMenu(restaurantService);
    }

    public async ValueTask Show()
    {
        // spectre console figlet
        while (true)
        {
            Console.Clear();
            AnsiConsole.Write(new Markup("[green]====National Restaurant====[/]\n\n"));
            AnsiConsole.Write(new Markup("[green]====MainMenu=====[/]\n\n"));
            AnsiConsole.Write(new Markup("[yellow]1.Chef Menu:[/]\n\n"));
            AnsiConsole.Write(new Markup("[yellow]2.Food Menu:[/]\n\n"));
            AnsiConsole.Write(new Markup("[yellow]3.Restaurant Menu:[/]\n\n"));
            AnsiConsole.Write(new Markup("[red]4.Exit[/]\n"));
            Console.WriteLine();
            Console.WriteLine("Enter your choice:");
            string choice = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(choice))
            {
                Console.WriteLine("Enter a valid choice");
                choice = Console.ReadLine();
            }
            switch (choice)
            {
                case "1":
                    Console.Clear();
                    await chefMenu.Show();
                    Console.WriteLine();
                    break;
                case "2":
                    Console.Clear();
                    await foodMenu.Show();
                    Console.WriteLine();
                    break;
                case "3":
                    Console.Clear();
                    await restaurantMenu.Show();
                    Console.WriteLine();
                    break;
                case "4":
                    Console.Clear();
                    Console.WriteLine("Exiting the application.Goodbye");
                    Environment.Exit(0);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid choice, try again one more time");
                    Console.WriteLine();
                    break;
            }
        }
    }
}