using EFCore_LibrarySystem.Command;
using EFCore_LibrarySystem.Services;
using EFCore_LibrarySystem.ViewModels;
using System.Windows;
using User_Panel.Data;
using User_Panel.Models;
using User_Panel.Views;

namespace User_Panel.ViewModels;

public class LoginViewModel : ViewModel
{
    public UserDbContext DbContext { get; set; }
    public RelayCommand SignUpCommand { get; set; }
    public RelayCommand SignInCommand { get; set; }

    public User UserSerach { get; set; } = new();

    private readonly INavigationService _navigationService;
    public LoginViewModel(INavigationService navigationService, UserDbContext dbContext)
    {
        DbContext = dbContext;
        _navigationService = navigationService;
        SignUpCommand = new RelayCommand(SignUpClick);
        SignInCommand = new RelayCommand(SignInClick);
    }

    private void SignInClick(object? obj)
    {
        try
        {
            var Users = DbContext.Users.ToList();
            foreach (var user in Users)
            {
                if (UserSerach.Mail! == user.Mail && UserSerach.Password! == user.Password)
                {
                    _navigationService.Navigate<LibraryView, LibraryViewModel>();
                }
            }
        }
        catch (Exception)
        {
            MessageBox.Show("Not Found User!!!");
        }
    }

    private void SignUpClick(object? obj)
    {
         _navigationService.Navigate<RegistherView, RegistherViewModel>();
    }
}
