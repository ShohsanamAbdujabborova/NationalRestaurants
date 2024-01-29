using National_Restaurants.Models;
namespace National_Restaurants.Interfaces;
public interface IChefService
{
    /// <summary>
    /// Create Chef
    /// </summary>
    /// <param name="chef"></param>
    /// <returns></returns>
    ValueTask<Chef> CreateAsync(Chef chef);
    /// <summary>
    /// Update chef by id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="chef"></param>
    /// <returns></returns>
    ValueTask<Chef> UpdateAsync(int id, Chef chef);
    /// <summary>
    /// Delete chef by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    ValueTask<bool> DeleteAsync(int id);
    /// <summary>
    /// Get by id Chef
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    ValueTask<Chef> GetByIdAsync(int id);
    /// <summary>
    /// Get all
    /// </summary>
    /// <returns></returns>
    ValueTask<List<Chef>> GetAllAsync();
    /// <summary>
    /// Create NewFood by chefId
    /// </summary>
    /// <param name="chefid"></param>
    /// <param name="food"></param>
    /// <returns></returns>
    ValueTask<CreatedFood> CreateNewFood(int chefid, CreatedFood food);
    /// <summary>
    /// Remove CreatedFood by chefId,foodId
    /// </summary>
    /// <param name="chefid"></param>
    /// <param name="foodid"></param>
    /// <returns></returns>
    ValueTask<bool> RemoveCreatedFood(int chefid, int foodid);
}
