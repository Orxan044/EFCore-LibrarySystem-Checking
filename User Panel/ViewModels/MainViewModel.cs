using EFCore_LibrarySystem.ViewModels;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using User_Panel.Views;

namespace User_Panel.ViewModels;

public class MainViewModel : ViewModel , INotifyPropertyChanged
{
    private Page currentPage;

    public Page? CurrentPage
    {
        get => currentPage;
        set { currentPage = value!; OnPropertyChanged(); }
    }
    public MainViewModel()
    {
        currentPage = App.MainContainer.GetInstance<LoginView>();
        currentPage.DataContext = App.MainContainer.GetInstance<LoginViewModel>();
    }






    //-------------------------------------------------------------
    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? paramName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(paramName));
    //-------------------------------------------------------------
}
