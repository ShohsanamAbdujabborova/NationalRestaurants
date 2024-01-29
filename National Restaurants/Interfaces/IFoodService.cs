using National_Restaurants.Models;
using System.Reflection;
namespace National_Restaurants.Interfaces;
public interface IFoodService
{
    /// <summary>
    /// Food Gets By ID( National Food)
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    ValueTask<Food> GetByIdNational(int id);
    /// <summary>
    ///Food Get By Id(Other Food like Chinese food)
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    ValueTask<Food> GetByIdOthers(int id);
    /// <summary>
    /// Get All National Food
    /// </summary>
    /// <returns></returns>
    ValueTask<List<Food>> GetAllNationalFoods();
    /// <summary>
    /// Get ALl Other Food
    /// </summary>
    /// <returns></returns>
    ValueTask<List<Food>> GetAllOtherFoods();
    /// <summary>
    /// Food sorted by Higher Price
    /// </summary>
    /// <returns></returns>
    ValueTask<List<Food>> SortByHigherPrice();
    /// <summary>
    /// Food sorted by Lower Price
    /// </summary>
    /// <returns></returns>
    ValueTask<List<Food>> SortByLowerPrice();
}
