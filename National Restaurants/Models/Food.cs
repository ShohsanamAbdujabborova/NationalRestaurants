using Newtonsoft.Json;
namespace National_Restaurants.Models;
public class Food
{
    /// <summary>
    /// Food Id
    /// </summary>
    [JsonProperty("id")]
    public int Id { get; set; }
    /// <summary>
    /// Food Name
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }
    /// <summary>
    /// Food description
    /// </summary>
    [JsonProperty("description")]
    public string Description { get; set; }
    /// <summary>
    /// Food price
    /// </summary>
    [JsonProperty("price")]
    public decimal Price { get; set; }
    /// <summary>
    /// Included_drinks list
    /// </summary>
    [JsonProperty("included_drinks")]
    public List<string> Included_Drinks { get; set; }
}
