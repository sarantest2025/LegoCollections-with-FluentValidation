using Microsoft.AspNetCore.Identity;
namespace LegoCollections.Models
{
  public class ApplicationUser : IdentityUser
  {
    public string Name { get; set; } = string.Empty;
    public ICollection<LegoList> LegoLists { get; set; } = new List<LegoList>();
    
  }
}

