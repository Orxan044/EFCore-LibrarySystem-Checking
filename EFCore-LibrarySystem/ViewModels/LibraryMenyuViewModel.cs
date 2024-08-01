using EFCore_LibrarySystem.Command;
using EFCore_LibrarySystem.Data;
using EFCore_LibrarySystem.Models.Concretes;
using EFCore_LibrarySystem.Services;
using EFCore_LibrarySystem.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace EFCore_LibrarySystem.ViewModels;

public class LibraryMenyuViewModel : ViewModel , INotifyPropertyChanged
{
    private ObservableCollection<Book>? books;
    public ObservableCollection<Book> Books { get => books!; set { books = value; OnPropertyChanged(); } }

    private readonly LibraryDbContext _dbContext;
    public RelayCommand DeleteBookCommand { get; set; }

    private readonly INavigationService _navigationService;
    public LibraryMenyuViewModel(LibraryDbContext dbContext,INavigationService navigationService)
    {
        _dbContext = dbContext;
        _navigationService = navigationService;

        Books = new ObservableCollection<Book>([.. _dbContext.Books]);
        DeleteBookCommand = new RelayCommand(DeleteBookClick);        
        
    }


    private void DeleteBookClick(object? id)
    {
        var deleteBook = _dbContext.Books.FirstOrDefault(b => b.Id == Convert.ToInt32(id));
        _dbContext.Books.Remove(deleteBook!);
        _dbContext.SaveChanges();
        LibraryMainViewModel mainView = new LibraryMainViewModel(_navigationService);
        mainView.CurrentPage2 = App.MainContainer.GetInstance<LibraryMenyuView>();
        mainView.CurrentPage2.DataContext = App.MainContainer.GetInstance<LibraryMenyuViewModel>();
    }



    //-------------------------------------------------------------
    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? paramName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(paramName));
    //-------------------------------------------------------------





}
