using EFCore_LibrarySystem.Models.Abstract;
using EFCore_LibrarySystem.Models.Concretes;

namespace User_Panel.Models;

public class User : BaseEntity
{
    public string? FullName { get; set; }
    public string? Mail { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Password { get; set; }
    public List<Book> BooksBorrowed { get; set; } = new();
    public List<Book> BooksReturends { get; set; } = new();

}
