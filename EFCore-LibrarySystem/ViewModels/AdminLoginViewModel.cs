using EFCore_LibrarySystem.Command;
using EFCore_LibrarySystem.Data;
using EFCore_LibrarySystem.Models.Concretes;
using EFCore_LibrarySystem.Services;
using EFCore_LibrarySystem.Views;
using Microsoft.EntityFrameworkCore;

namespace EFCore_LibrarySystem.ViewModels;

public class AdminLoginViewModel : ViewModel
{
    public Admin? Admin { get; set; } = new();

    private readonly INavigationService NavigationService;
    public AdminDbContext DbContext { get; set; }

    public RelayCommand LoginCommand { get; set; } 
    public AdminLoginViewModel(INavigationService navigationService,AdminDbContext dbContext)
    {
        NavigationService = navigationService; 
        DbContext = dbContext;
        LoginCommand = new RelayCommand(LoginClick);

    }

    private void LoginClick(object? obj)
    {
        var Admins= DbContext.Admins.ToList();

        foreach (var SerachAdmin in Admins)
        {
            if(Admin!.AdminName == SerachAdmin.AdminName && Admin!.Password == SerachAdmin.Password)
            {
                NavigationService.Navigate<LibraryMainView, LibraryMainViewModel>();
                //App.Current.MainWindow = new LibraryMainView();
                //--------------------------------------------------------------------------------
                //var newMainWindow = App.Current.MainWindow;
                //newMainWindow.DataContext = new LibraryMainViewModel(NavigationService);
                //newMainWindow.Show();
            }
        }
    
        
    }
}
