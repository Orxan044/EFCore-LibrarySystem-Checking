using EFCore_LibrarySystem.Command;
using EFCore_LibrarySystem.Services;
using EFCore_LibrarySystem.ViewModels;
using System.Windows;
using User_Panel.Data;
using User_Panel.Models;
using User_Panel.Views;

namespace User_Panel.ViewModels;

public class RegistherViewModel : ViewModel
{
    public RelayCommand SignInCommand { get; set; }
    public RelayCommand SignUpCommand { get; set; }
    public UserDbContext DbContext { get; set; }
    public User NewUser { get; set; } = new();


    private readonly INavigationService _navigationService;
    public RegistherViewModel(INavigationService navigationService, UserDbContext dbContext)
    {
        _navigationService = navigationService;
        SignInCommand = new RelayCommand(SignInClick);
        SignUpCommand = new RelayCommand(SignUpClick);
        DbContext = dbContext;
    }

    private void SignUpClick(object? obj)
    {
        try
        {
            DbContext.Users.Add(NewUser);
            DbContext.SaveChanges();
        }
        catch (Exception)
        {
            MessageBox.Show("Please Enter Correctly!");

        }
    }

    private void SignInClick(object? obj)
    {
        _navigationService.Navigate<LoginView, LoginViewModel>();
    }
}
