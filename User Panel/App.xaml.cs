using EFCore_LibrarySystem.Services;
using EFCore_LibrarySystem.Views;
using SimpleInjector;
using System.Windows;
using User_Panel.Data;
using User_Panel.ViewModels;
using User_Panel.Views;
using MainViewModel = User_Panel.ViewModels.MainViewModel;

namespace User_Panel;

public partial class App : Application
{
    public static Container MainContainer { get; set; } = new();
    public App()
    {
        AddOtherServices();
        AddViews();
        AddViewModels();
    }

    private void AddOtherServices()
    {
        MainContainer.RegisterSingleton<UserDbContext>();
        MainContainer.RegisterSingleton<INavigationService, NavigationService>();
    }

    private void AddViewModels()
    {
        MainContainer.RegisterSingleton<MainViewModel>();
        MainContainer.RegisterSingleton<LoginViewModel>();
        MainContainer.RegisterSingleton<LibraryMainView>();
        MainContainer.RegisterSingleton<RegistherViewModel>();

    }

    private void AddViews()
    {
        MainContainer.RegisterSingleton<MainView>();
        MainContainer.RegisterSingleton<LoginView>();
        MainContainer.RegisterSingleton<RegistherView>();
        MainContainer.RegisterSingleton<LibraryView>();

    }

    protected override void OnStartup(StartupEventArgs e)
    {
        var mainView = MainContainer.GetInstance<MainView>();
        mainView.DataContext = MainContainer.GetInstance<MainViewModel>();
        mainView.Show();
        base.OnStartup(e);
    }
}
