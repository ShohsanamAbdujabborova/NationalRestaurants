using National_Restaurants.Interfaces;
using National_Restaurants.Models;
using Newtonsoft.Json;
namespace National_Restaurants.Services;
public class RestaurantService : IRestaurantService
{
    private FoodService FoodService;

    public RestaurantService(FoodService foodService)
    {
        FoodService = foodService;
    }

    public async ValueTask<Food> AddFoodAsync(int restaurantId, int foodId)
    {
        var content = File.ReadAllText(Constants.RESTAURANTS_PATH);
        var Restaurants = JsonConvert.DeserializeObject<List<Restaurant>>(content);

        var foundRestaurant = false;
        Food found = null;
        foreach (var item in Restaurants)
        {
            if (item.Id == restaurantId)
            {
                if (item.RestaurantType == Enums.RestaurantType.National)
                {
                    var food = await FoodService.GetByIdNational(foodId);
                    if (food == null)
                    {
                        throw new Exception($"food is not found with id {foodId}");
                    }
                    if (item.Menu == null)
                    {
                        item.Menu = new List<Food>();
                    }
                    item.Menu.Add(food);
                    found = food;
                    foundRestaurant = true;
                    break;
                }
                else if (item.RestaurantType == Enums.RestaurantType.Other)
                {
                    var food = await FoodService.GetByIdOthers(foodId);
                    if (food == null)
                    {
                        throw new Exception($"food is not found with id {foodId}");
                    }
                    if (item.Menu == null)
                    {
                        item.Menu = new List<Food>();
                    }
                    item.Menu.Add(food);
                    found = food;
                    foundRestaurant = true;
                    break;
                }
            }
        }
        if (foundRestaurant is false)
        {
            throw new Exception($"restaurant is not found with Id {restaurantId}");
        }

        var result = JsonConvert.SerializeObject(Restaurants, Formatting.Indented);
        File.WriteAllText(Constants.RESTAURANTS_PATH, result);
        return found;
    }

    public async ValueTask<Restaurant> CreateAsync(Restaurant restaurant)
    {
        var content = File.ReadAllText(Constants.RESTAURANTS_PATH);
        var Restaurants = JsonConvert.DeserializeObject<List<Restaurant>>(content);

        restaurant.Id = Restaurants.Count + 1;
        //id qo'yish kk avtomatik yozadigan
        restaurant.CreatedAt = DateTime.UtcNow;
        restaurant.EditedAt = DateTime.UtcNow;

        Restaurants.Add(restaurant);

        var result = JsonConvert.SerializeObject(Restaurants, Formatting.Indented);
        File.WriteAllText(Constants.RESTAURANTS_PATH, result);

        return restaurant;
    }

    public async ValueTask<bool> DeleteAsync(int id)
    {
        var content = File.ReadAllText(Constants.RESTAURANTS_PATH);
        var Restaurants = JsonConvert.DeserializeObject<List<Restaurant>>(content);

        var foundRestaurant = false;

        foreach (var restaurant in Restaurants)
        {
            if (restaurant.Id == id)
            {
                Restaurants.Remove(restaurant);
                foundRestaurant = true;
                break;
            }
        }
        if (!foundRestaurant)
        {
            return foundRestaurant;
        }
        var result = JsonConvert.SerializeObject(Restaurants, Formatting.Indented);
        File.WriteAllText(Constants.RESTAURANTS_PATH, result);

        return foundRestaurant;
    }

    public async ValueTask<List<Restaurant>> GetAllAsync()
    {
        var content = File.ReadAllText(Constants.RESTAURANTS_PATH);
        return JsonConvert.DeserializeObject<List<Restaurant>>(content);
    }

    public async ValueTask<Restaurant> GetByIdAsync(int id)
    {
        var content = File.ReadAllText(Constants.RESTAURANTS_PATH);
        var Restaurants = JsonConvert.DeserializeObject<List<Restaurant>>(content);

        Restaurant foundRestaurant = null;

        foreach (var restaurant in Restaurants)
        {
            if (restaurant.Id == id)
            {
                foundRestaurant = restaurant;
                break;
            }
        }
        return foundRestaurant;
    }

    public async ValueTask<bool> RemoveFoodAsync(int foodId, int restaurantId)
    {
        var content = File.ReadAllText(Constants.RESTAURANTS_PATH);
        var Restaurants = JsonConvert.DeserializeObject<List<Restaurant>>(content);


        var foundRestaurant = false;
        var foundfood = false;
        foreach (var item in Restaurants)
        {
            if (item.Id == restaurantId)
            {
                foreach (var food in item.Menu)
                {
                    if (food.Id == foodId)
                    {
                        item.Menu.Remove(food);
                        foundfood = true;
                        break;
                    }
                }
                if (foundfood is false)
                {
                    throw new Exception("food is not found");
                }
                foundRestaurant = true;
                break;
            }
        }
        if (foundRestaurant is false)
        {
            throw new Exception($"restaurant is not found with Id {restaurantId}");
        }

        var result = JsonConvert.SerializeObject(Restaurants, Formatting.Indented);
        File.WriteAllText(Constants.RESTAURANTS_PATH, result);

        return true;
    }

    public async ValueTask<Restaurant> UpdateAsync(int id, Restaurant restaurant)
    {
        var content = File.ReadAllText(Constants.RESTAURANTS_PATH);
        var Restaurants = JsonConvert.DeserializeObject<List<Restaurant>>(content);

        var found = false;
        foreach (var item in Restaurants)
        {
            if (item.Id == id)
            {
                item.RestaurantType = restaurant.RestaurantType;
                item.Name = restaurant.Name;
                item.Location = restaurant.Location;
                item.CreatedAt = restaurant.CreatedAt;
                item.EditedAt = DateTime.UtcNow;
                found = true;
                break;
            }
        }
        if (found is false)
        {
            return null;
        }
        var result = JsonConvert.SerializeObject(Restaurants, Formatting.Indented);
        File.WriteAllText(Constants.RESTAURANTS_PATH, result);
        return restaurant;
    }
}
