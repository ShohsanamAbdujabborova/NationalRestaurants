using National_Restaurants.Models;
namespace National_Restaurants.Interfaces;
public interface IRestaurantService
{
    /// <summary>
    /// Create Restaurant
    /// </summary>
    /// <param name="restaurant"></param>
    /// <returns></returns>
    ValueTask<Restaurant> CreateAsync(Restaurant restaurant);
    /// <summary>
    /// Update Restaurant by id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="restaurant"></param>
    /// <returns></returns>
    ValueTask<Restaurant> UpdateAsync(int id, Restaurant restaurant);
    /// <summary>
    /// Add Food to Restaurant 
    /// </summary>
    /// <param name="restaurantId"></param>
    /// <param name="foodId"></param>
    /// <returns></returns>
    ValueTask<Food> AddFoodAsync(int restaurantId, int foodId);
    /// <summary>
    /// Remove Food from Restaurant
    /// </summary>
    /// <param name="foodId"></param>
    /// <param name="restaurantId"></param>
    /// <returns></returns>
    ValueTask<bool> RemoveFoodAsync(int foodId, int restaurantId);
    /// <summary>
    /// Delete Restaurant
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    ValueTask<bool> DeleteAsync(int id);
    /// <summary>
    /// Restaurant gets by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    ValueTask<Restaurant> GetByIdAsync(int id);
    /// <summary>
    /// Get ALl Restaurant
    /// </summary>
    /// <returns></returns>
    ValueTask<List<Restaurant>> GetAllAsync();
}
