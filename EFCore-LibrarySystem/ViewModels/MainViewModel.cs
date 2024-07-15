using EFCore_LibrarySystem.Services;
using EFCore_LibrarySystem.Views;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace EFCore_LibrarySystem.ViewModels;

public class MainViewModel : ViewModel , INotifyPropertyChanged
{

    private static INavigationService? NavigationService;

    LibraryMainViewModel lMainModel = new(NavigationService!);

    private Page currentPage;

    public Page? CurrentPage
    {
        get => currentPage;
        set { currentPage = value!; OnPropertyChanged(); }
    }

    //private Page currentPage2;

    public Page? CurrentPage2
    {
        get => lMainModel.CurrentPage2;
        set { lMainModel.CurrentPage2 = value!; OnPropertyChanged(); }
    }


    public MainViewModel(INavigationService navigationService)
    {
        NavigationService = navigationService;
        //-------------------------------------------------
        currentPage = App.MainContainer.GetInstance<AdminLoginView>();
        currentPage.DataContext = App.MainContainer.GetInstance<AdminLoginViewModel>();
        //-------------------------------------------------

    }





    //-------------------------------------------------------------
    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? paramName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(paramName));
    //-------------------------------------------------------------
}
