using EFCore_LibrarySystem.Command;
using EFCore_LibrarySystem.ViewModels;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace User_Panel.ViewModels;

public class LibraryViewModel : ViewModel , INotifyPropertyChanged
{
    private Page? currentPage2;
    public Page? CurrentPage2
    {
        get => currentPage2;
        set { currentPage2 = value!; OnPropertyChanged(); }
    }

    public RelayCommand BooksCommand { get; set; }
    public RelayCommand MyBooksCommand { get; set; }

    public LibraryViewModel()
    {
        BooksCommand = new RelayCommand(BooksClick);
        MyBooksCommand = new RelayCommand(MyBooksClick);

        //-------------------------------------------------
        //CurrentPage2 = App.MainContainer.GetInstance<LibraryStatusView>();
        //CurrentPage2.DataContext = App.MainContainer.GetInstance<LibraryStatusViewModel>();
        //-------------------------------------------------

    }

    private void BooksClick(object? obj)
    {
        //CurrentPage2 = App.MainContainer.GetInstance<LibraryBooksView>();
        //CurrentPage2.DataContext = App.MainContainer.GetInstance<LibraryBooksViewModel>();
    }

    private void MyBooksClick(object? obj)
    {
        //CurrentPage2 = App.MainContainer.GetInstance<LibraryStatusView>();
        //CurrentPage2.DataContext = App.MainContainer.GetInstance<LibraryStatusViewModel>();
    }





    //-------------------------------------------------------------
    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? paramName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(paramName));
    //-------------------------------------------------------------
}
