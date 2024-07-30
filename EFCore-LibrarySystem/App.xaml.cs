using EFCore_LibrarySystem.ViewModels;
using System.Windows;
using EFCore_LibrarySystem.Views;
using SimpleInjector;
using EFCore_LibrarySystem.Services;
using EFCore_LibrarySystem.Data;
using Microsoft.EntityFrameworkCore;

namespace EFCore_LibrarySystem;


public partial class App : Application
{
    public static Container MainContainer { get; set; } = new();
    public App()
    {
        AddOtherServices();
        AddViews();
        AddViewModels();

        MainContainer.Verify();
    }

    private static void AddOtherServices()
    {
        MainContainer.RegisterSingleton<AdminDbContext>();
        MainContainer.RegisterSingleton<LibraryDbContext>();
        MainContainer.RegisterSingleton<INavigationService,NavigationService>();
    }

    private static void AddViewModels()
    { 
        MainContainer.RegisterSingleton<MainViewModel>();
        MainContainer.RegisterSingleton<AdminLoginViewModel>();
        MainContainer.RegisterSingleton<LibraryMainViewModel>();
        MainContainer.Register<LibraryMenyuViewModel>();
        MainContainer.RegisterSingleton<BookMenyuViewModel>();
        MainContainer.RegisterSingleton<EditBookViewModel>();

    }

    private static void AddViews()
    {
        MainContainer.RegisterSingleton<MainWindow>();
        MainContainer.RegisterSingleton<AdminLoginView>();
        MainContainer.RegisterSingleton<LibraryMainView>();
        MainContainer.RegisterSingleton<LibraryMenyuView>();
        MainContainer.RegisterSingleton<BookMenyuView>();
        MainContainer.RegisterSingleton<EditBookView>();

    }

    protected override void OnStartup(StartupEventArgs e)
    {
        var mainView = MainContainer.GetInstance<MainWindow>();
        mainView.DataContext = MainContainer.GetInstance<MainViewModel>();
        mainView.Show();
        base.OnStartup(e);


    }

}
