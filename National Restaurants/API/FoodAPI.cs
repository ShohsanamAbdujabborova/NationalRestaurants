using National_Restaurants.Models;
using Newtonsoft.Json;
namespace National_Restaurants.API;
public class FoodAPI
{
    string otherfoods_url = "https://nationalfoods.onrender.com/others";
    string nationalfoods_url = "https://nationalfoods.onrender.com/national";

    private HttpClient otherfoods;
    private HttpClient nationalfoods;

    private List<Food> otherfoodslist;
    private List<Food> nationalfoodslist;

    public FoodAPI()
    {
        otherfoodslist = new List<Food>();
        nationalfoodslist = new List<Food>();

        this.otherfoods = new HttpClient();
        this.nationalfoods = new HttpClient();

        this.otherfoods.BaseAddress = new Uri(otherfoods_url);
        this.nationalfoods.BaseAddress = new Uri(nationalfoods_url);
    }

    public async Task GetDataAsync()
    {
        var otherfoodsResponse = await otherfoods.GetAsync(otherfoods_url);
        var nationalfoodsResponse = await nationalfoods.GetAsync(nationalfoods_url);

        var otherfoodsData = await otherfoodsResponse.Content.ReadAsStringAsync();
        var nationalfoodsData = await nationalfoodsResponse.Content.ReadAsStringAsync();

        otherfoodslist = JsonConvert.DeserializeObject<List<Food>>(otherfoodsData);
        nationalfoodslist = JsonConvert.DeserializeObject<List<Food>>(nationalfoodsData);
    }

    public List<Food> GetNationalFoods()
    {
        return nationalfoodslist;
    }
    public List<Food> GetOtherFoods() 
    {
        return otherfoodslist; 
    }
}

