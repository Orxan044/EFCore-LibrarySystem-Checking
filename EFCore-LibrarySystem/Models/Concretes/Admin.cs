using EFCore_LibrarySystem.Models.Abstract;

namespace EFCore_LibrarySystem.Models.Concretes;

public class Admin : BaseEntity
{
    public string? Name { get; set; }    
    public string? AdminName { get; set; }
    public string? Password { get; set; }

}
