namespace LegoCollections.DTOs;

public class LegoListsDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string OwnerUserId { get; set; } = default!;
    public string? ApplicationUser { get; set; }              
       
}
