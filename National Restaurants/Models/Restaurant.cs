using National_Restaurants.Enums;
namespace National_Restaurants.Models;
public class Restaurant
{
    public int Id { get; set; }
    public RestaurantType RestaurantType { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public List<Food> Menu { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime EditedAt { get; set; }
}