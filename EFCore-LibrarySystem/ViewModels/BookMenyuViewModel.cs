using EFCore_LibrarySystem.Command;
using EFCore_LibrarySystem.Data;
using EFCore_LibrarySystem.Models.Concretes;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace EFCore_LibrarySystem.ViewModels;

public class BookMenyuViewModel : ViewModel
{
    private Book newBook = new();
    public Book NewBook { get => newBook; set => newBook = value; }

    private readonly LibraryDbContext _dbContext;
    public RelayCommand AddBookCommand { get; set; }

    public BookMenyuViewModel(LibraryDbContext dbContext)
    {
        _dbContext = dbContext;
        AddBookCommand = new RelayCommand(AddBooksClick);
    }

    private void AddBooksClick(object? obj)
    {
        _dbContext.Books.Add(NewBook);
        _dbContext.SaveChanges();
    }
}
