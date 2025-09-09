namespace LegoCollections.Models;

public class LegoList
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<LegoFigure> Figures { get; set; } = new();
    public string UserId { get; set; } = string.Empty;
    public ApplicationUser User { get; set; } =null!;
}
 
