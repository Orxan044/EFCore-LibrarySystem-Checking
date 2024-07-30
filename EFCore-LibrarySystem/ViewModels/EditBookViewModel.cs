using EFCore_LibrarySystem.Command;
using EFCore_LibrarySystem.Data;
using EFCore_LibrarySystem.Models.Concretes;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
namespace EFCore_LibrarySystem.ViewModels;

public class EditBookViewModel : ViewModel , INotifyPropertyChanged
{

    private ObservableCollection<Book>? books;
    public ObservableCollection<Book> Books { get => books!; set { books = value; OnPropertyChanged(); } }

    private Book newBook = new();
    public Book NewBook { get => newBook; set { newBook = value; OnPropertyChanged(); } }

    private readonly LibraryDbContext _dbContext;

    public RelayCommand SaveBookCommand { get; set; }
    public EditBookViewModel(LibraryDbContext dbContext)
    {
        _dbContext = dbContext;
        Books = new ObservableCollection<Book>([.. _dbContext.Books]);
        SaveBookCommand = new RelayCommand(SaveBookClick);
        
    }

    private void SaveBookClick(object? id)
    {
        var editBook = _dbContext.Books.FirstOrDefault(b => b.Id == Convert.ToInt32(id));
        //editBook = newBook;
        _dbContext.Books.Update(newBook!);
        _dbContext.SaveChanges();
    }


    //-------------------------------------------------------------
    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? paramName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(paramName));
    //-------------------------------------------------------------
}
