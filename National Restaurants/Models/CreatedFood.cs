using Newtonsoft.Json;

namespace National_Restaurants.Models;
public class CreatedFood
{
    /// <summary>
    /// Created Food Id
    /// </summary>
    [JsonProperty("id")]
    public int Id { get; set; }
    /// <summary>
    /// Created Chef Id
    /// </summary>
    [JsonProperty("chef_id")]
    public int ChefId { get; set; }
    /// <summary>
    /// Food Name
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }
    /// <summary>
    /// Food Description
    /// </summary>
    [JsonProperty("description")]
    public string Description { get; set; }
    /// <summary>
    /// Food price , food price gets by decimal number
    /// </summary>
    [JsonProperty("price")]
    public decimal Price { get; set; }
    /// <summary>
    /// Included_drinks
    /// </summary>
    [JsonProperty("included_drinks")]
    public List<string> Included_Drinks { get; set; }
}
