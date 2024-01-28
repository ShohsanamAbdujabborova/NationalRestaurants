using National_Restaurants.Models;
namespace National_Restaurants.Interfaces;
public interface IRestaurantService
{
    ValueTask<Restaurant> CreateAsync(Restaurant restaurant);
    ValueTask<Restaurant> UpdateAsync(int id, Restaurant restaurant);
    ValueTask<Food> AddFoodAsync(int restaurantId, int foodId);
    ValueTask<bool> RemoveFoodAsync(int foodId, int restaurantId);
    ValueTask<bool> DeleteAsync(int id);
    ValueTask<Restaurant> GetByIdAsync(int id);
    ValueTask<List<Restaurant>> GetAllAsync();
}
