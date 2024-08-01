﻿using EFCore_LibrarySystem;
using EFCore_LibrarySystem.Services;
using EFCore_LibrarySystem.ViewModels;
using System.Windows.Controls;

namespace User_Panel.Services;

public class NavigationService : INavigationService
{
    public void Navigate<TView, TViewModel>() where TView : Page where TViewModel : ViewModel
    {
        var mainVm = System.Windows.Application.Current.MainWindow.DataContext as MainViewModel;
        if (mainVm is not null)
        {
            mainVm!.CurrentPage = App.MainContainer.GetInstance<TView>();
            mainVm.CurrentPage.DataContext = App.MainContainer.GetInstance<TViewModel>();
        }
    }
}
