using National_Restaurants.API;
using National_Restaurants.Interfaces;
using National_Restaurants.Models;

namespace National_Restaurants.Services;
public class FoodService : IFoodService
{
    private FoodAPI foodAPI;
    public FoodService(FoodAPI foodAPI)
    {
        this.foodAPI = foodAPI;
    }

    public async ValueTask<List<Food>> GetAllNationalFoods()
    {
        return foodAPI.GetNationalFoods();
    }
    public async ValueTask<Food> GetByIdNational(int id)
    {
        var nationalfoods = foodAPI.GetOtherFoods();
        Food food = null;
        foreach (var item in nationalfoods)
        {
            if (item.Id == id)
            {
                food = item;
                break;
            }
        }
        return food;
    }
    public async ValueTask<Food> GetByIdOthers(int id)

    {
        var otherfoods = foodAPI.GetNationalFoods();
        Food found = null;
        foreach (var food in otherfoods)
        {
            if (food.Id == id)
            {
                found = food;
                break;
            }
        }
        return found;
    }
    public async ValueTask<List<Food>> GetAllOtherFoods()
    {
        return foodAPI.GetOtherFoods();
    }
    public async ValueTask<List<Food>> SortByHigherPrice()
    {
        List<Food> AllFoodsFromAPI = new List<Food>();
        List<Food> SortedByHigherPrive = new List<Food>();

        var nationalfoods = foodAPI.GetOtherFoods();
        var otherfoods = foodAPI.GetNationalFoods();

        AllFoodsFromAPI.AddRange(nationalfoods);
        AllFoodsFromAPI.AddRange(otherfoods);

        AllFoodsFromAPI.Sort((food1, food2) => food2.Price.CompareTo(food1.Price));

        return AllFoodsFromAPI;

    }
    public async ValueTask<List<Food>> SortByLowerPrice()
    {
        List<Food> AllFoodsFromAPI = new List<Food>();
        List<Food> SortedByHigherPrive = new List<Food>();

        var nationalfoods = foodAPI.GetOtherFoods();
        var otherfoods = foodAPI.GetNationalFoods();

        AllFoodsFromAPI.AddRange(nationalfoods);
        AllFoodsFromAPI.AddRange(otherfoods);

        AllFoodsFromAPI.Sort((food1, food2) => food1.Price.CompareTo(food2.Price));

        return AllFoodsFromAPI;
    }
}

