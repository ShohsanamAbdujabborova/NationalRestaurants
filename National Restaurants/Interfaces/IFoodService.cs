using National_Restaurants.Models;
using System.Reflection;
namespace National_Restaurants.Interfaces;
public interface IFoodService
{
    ValueTask<Food> GetByIdNational(int id);
    ValueTask<Food> GetByIdOthers(int id);
    ValueTask<List<Food>> GetAllNationalFoods();
    ValueTask<List<Food>> GetAllOtherFoods();
    ValueTask<List<Food>> SortByHigherPrice();
    ValueTask<List<Food>> SortByLowerPrice();
}
