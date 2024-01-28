using National_Restaurants.Models;
namespace National_Restaurants.Interfaces;
public interface IChefService
{
    ValueTask<Chef> CreateAsync(Chef chef);
    ValueTask<Chef> UpdateAsync(int id, Chef chef);
    ValueTask<bool> DeleteAsync(int id);
    ValueTask<Chef> GetByIdAsync(int id);
    ValueTask<List<Chef>> GetAllAsync();
    ValueTask<CreatedFood> CreateNewFood(int chefid, CreatedFood food);
    ValueTask<bool> RemoveCreatedFood(int chefid, int foodid);
}
