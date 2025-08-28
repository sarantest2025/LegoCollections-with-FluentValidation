namespace LegoCollections.Models;
public class LegoFigure
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string BrickLinkCode { get; set; } = string.Empty;
    public string Condition { get; set; } = string.Empty;

    public int LegoListId { get; set; }
    public LegoList ListId { get; set; } = null!;

}
    



