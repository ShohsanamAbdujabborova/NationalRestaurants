using Newtonsoft.Json;
namespace National_Restaurants.Models;
public class Chef
{
    /// <summary>
    /// Chef Id
    /// </summary>
    [JsonProperty("id")]
    public int Id { get; set; }
    /// <summary>
    /// Chef Name
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }
    /// <summary>
    /// Chef Specialization
    /// </summary>
    [JsonProperty("specialization")]
    public string Specialization { get; set; }
    /// <summary>
    /// Chef Level,levels get by ChefLevel Enum Model automatically ,users must choose level by number
    /// </summary>
    [JsonProperty("level")]
    public string Level { get; set; }//enum
    /// <summary>
    /// Chef's Experience
    /// </summary>
    [JsonProperty("experience")]
    public float Experience { get; set; }
    /// <summary>
    /// Chef is what is cooking ?
    /// </summary>
    [JsonProperty("cooks")]
    public string Cooks { get; set; }//nima pishiragni 
}
