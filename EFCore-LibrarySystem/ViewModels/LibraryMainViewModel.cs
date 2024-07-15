using EFCore_LibrarySystem.Command;
using EFCore_LibrarySystem.Services;
using EFCore_LibrarySystem.Views;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace EFCore_LibrarySystem.ViewModels;

public class LibraryMainViewModel : ViewModel , INotifyPropertyChanged
{

    //public MainViewModel mainView = new();

    private Page? currentPage2;
    public Page? CurrentPage2
    {
        get => currentPage2;
        set { currentPage2 = value!; OnPropertyChanged(); }
    }

    private readonly INavigationService NavigationService;
    
    public RelayCommand LibraryMenyuCommand { get; set; }
    public RelayCommand BookMenyuCommand { get; set; }
    public LibraryMainViewModel(INavigationService navigationService)
    {
        NavigationService = navigationService;
        LibraryMenyuCommand = new RelayCommand(LibraryMenyuClick);
        BookMenyuCommand = new RelayCommand(BookMenyuClick);

        //-------------------------------------------------
        CurrentPage2 = App.MainContainer.GetInstance<LibraryMenyuView>();
        CurrentPage2.DataContext = App.MainContainer.GetInstance<LibraryMenyuViewModel>();
        //-------------------------------------------------
    }

    private void BookMenyuClick(object? obj)
    {
        NavigationService.Navigate<BookMenyuView, BookMenyuViewModel>(CurrentPage2!);
    }

    private void LibraryMenyuClick(object? obj)
    {
        NavigationService.Navigate<LibraryMenyuView, LibraryMenyuViewModel>(CurrentPage2!);
    }



    //-------------------------------------------------------------
    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? paramName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(paramName));
    //-------------------------------------------------------------
}
