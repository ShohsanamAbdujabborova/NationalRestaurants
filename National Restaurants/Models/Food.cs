using Newtonsoft.Json;
namespace National_Restaurants.Models;
public class Food
{
    [JsonProperty("id")]
    public int Id { get; set; }
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("description")]
    public string Description { get; set; }
    [JsonProperty("price")]
    public decimal Price { get; set; }
    [JsonProperty("included_drinks")]
    public List<string> Included_Drinks { get; set; }
}
