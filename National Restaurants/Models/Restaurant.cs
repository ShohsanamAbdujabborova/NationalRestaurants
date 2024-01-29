using National_Restaurants.Enums;
using Newtonsoft.Json;
namespace National_Restaurants.Models;
public class Restaurant
{
    /// <summary>
    /// Restaurant Id
    /// </summary>
    [JsonProperty("id")]
    public int Id { get; set; }
    /// <summary>
    /// Restaurant Type
    /// </summary>
    [JsonProperty("restaurantType")]
    public string RestaurantType { get; set; }
    /// <summary>
    /// Restaurant Name
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }
    /// <summary>
    /// Restaurant Location
    /// </summary>
    [JsonProperty("location")]
    public string Location { get; set; }
    /// <summary>
    /// Restaurant's Menu , takes from Food 
    /// </summary>
    [JsonProperty("menu")]
    public List<Food> Menu { get; set; }
    /// <summary>
    /// DateTime Created At,it will take automatically
    /// </summary>
    [JsonProperty("createdAt")]
    public DateTime CreatedAt { get; set; }
    /// <summary>
    /// DateTime EditedAt,it will take automatically
    /// </summary>
    [JsonProperty("editedAt")]
    public DateTime EditedAt { get; set; }
}