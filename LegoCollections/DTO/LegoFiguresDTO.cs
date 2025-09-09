using LegoCollections.Models;

namespace LegoCollections.DTOs;

public class LegoFiguresDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string BrickLinkCode { get; set; } = string.Empty;
    public string Conditions { get; set; } = string.Empty;
    public int LegoListId { get; set; }
    public LegoList ListId { get; set; } = null!;
}