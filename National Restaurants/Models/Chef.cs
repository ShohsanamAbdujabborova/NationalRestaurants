namespace National_Restaurants.Models;
public class Chef
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Specialization { get; set; }
    public string Level { get; set; }//enum
    public float Experience { get; set; }
    public string Cooks { get; set; }//nima pishiragni 
}
