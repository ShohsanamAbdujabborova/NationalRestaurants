using National_Restaurants.Interfaces;
using National_Restaurants.Models;
using Newtonsoft.Json;
using System.Threading.Channels;
namespace National_Restaurants.Services;
public class ChefService : IChefService
{
    private FoodService foodService;

    public ChefService(FoodService foodService)
    {
        this.foodService = foodService;
    }

    public async ValueTask<Chef> CreateAsync(Chef chef)
    {
        var content = File.ReadAllText(Constants.CHEFS_PATH);
        var Chefs = JsonConvert.DeserializeObject<List<Chef>>(content);


        chef.Id = Chefs.Count + 1;

        Chefs.Add(chef);

        var result = JsonConvert.SerializeObject(Chefs, Formatting.Indented);
        File.WriteAllText(Constants.CHEFS_PATH, result);

        return chef;
    }

    public async ValueTask<CreatedFood> CreateNewFood(int chefid, CreatedFood food)
    {
        var content = File.ReadAllText(Constants.CHEFS_PATH);
        var Chefs = JsonConvert.DeserializeObject<List<Chef>>(content);

        if (Chefs != null)
        {
            foreach (var chef in Chefs)
            {
                if (chef.Id == chefid)
                {

                    var createdFoodsJson = await File.ReadAllTextAsync(Constants.CREATED_FOODS_PATH);
                    var createdFoods = JsonConvert.DeserializeObject<List<CreatedFood>>(createdFoodsJson);

  
                    food.ChefId = chefid;

                    createdFoods.Add(food);

                    var updatedFoodsJson = JsonConvert.SerializeObject(createdFoods);
                    await File.WriteAllTextAsync(Constants.CREATED_FOODS_PATH, updatedFoodsJson);

                    return food;
                }
            }
        }
        return null;
    }

    public async ValueTask<bool> DeleteAsync(int id)
    {
        var content = File.ReadAllText(Constants.CHEFS_PATH);
        var Chefs = JsonConvert.DeserializeObject<List<Chef>>(content);

        var foundChef = false;

        foreach (var chef in Chefs)
        {
            if (chef.Id == id)
            {
                Chefs.Remove(chef);
                foundChef = true;
                break;
            }
        }
        if (!foundChef)
        {
            return foundChef;
        }
        var result = JsonConvert.SerializeObject(Chefs, Formatting.Indented);
        File.WriteAllText(Constants.CHEFS_PATH, result);

        return foundChef;
    }

    public async ValueTask<List<Chef>> GetAllAsync()
    {
        var content = File.ReadAllText(Constants.CHEFS_PATH);
        return JsonConvert.DeserializeObject<List<Chef>>(content);
    }

    public async ValueTask<Chef> GetByIdAsync(int id)
    {
        var content = File.ReadAllText(Constants.CHEFS_PATH);
        var Chefs = JsonConvert.DeserializeObject<List<Chef>>(content);

        Chef foundChef = null;

        foreach (var chef in Chefs)
        {
            if (chef.Id == id)
            {
                foundChef = chef;
                break;
            }
        }
        return foundChef;
    }

    public async ValueTask<bool> RemoveCreatedFood(int chefid, int foodid)
    {
        var content = File.ReadAllText(Constants.CHEFS_PATH);
        var Chefs = JsonConvert.DeserializeObject<List<Chef>>(content);

        if (Chefs != null)
        {
            foreach (var chef in Chefs)
            {
                if (chef.Id == chefid)
                {
                    var createdFoodsJson = await File.ReadAllTextAsync(Constants.CREATED_FOODS_PATH);
                    var createdFoods = JsonConvert.DeserializeObject<List<CreatedFood>>(createdFoodsJson) ?? new List<CreatedFood>();

                    if (createdFoods != null)
                    {
                        foreach (var createdFood in createdFoods)
                        {
                            if (createdFood.Id == foodid && createdFood.ChefId == chefid)
                            {
                                createdFoods.Remove(createdFood);

                                var updatedFoodsJson = JsonConvert.SerializeObject(createdFoods);
                                await File.WriteAllTextAsync(Constants.CREATED_FOODS_PATH, updatedFoodsJson);

                                return true;
                            }
                        }
                    }
                }
            }
        }
        return false;
    }

    public async ValueTask<Chef> UpdateAsync(int id, Chef chef)
    {
        var content = File.ReadAllText(Constants.CHEFS_PATH);
        var Chefs = JsonConvert.DeserializeObject<List<Chef>>(content);

        var found = false;
        foreach (var item in Chefs)
        {
            if (item.Id == id)
            {
                item.Name = chef.Name;
                item.Specialization = chef.Specialization;
                item.Level = chef.Level;
                item.Experience = chef.Experience;
                item.Cooks = chef.Cooks;
                found = true;
                break;
            }
        }
        if (found is false)
        {
            return null;
        }
        var result = JsonConvert.SerializeObject(Chefs, Formatting.Indented);
        File.WriteAllText(Constants.CHEFS_PATH, result);
        return chef;
    }
}
