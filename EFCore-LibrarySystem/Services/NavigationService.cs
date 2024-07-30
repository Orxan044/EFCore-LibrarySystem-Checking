using EFCore_LibrarySystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace EFCore_LibrarySystem.Services;

public class NavigationService : INavigationService
{
    public void Navigate<TView, TViewModel>() where TView : Page where TViewModel : ViewModel
    {
        var mainVm1 = System.Windows.Application.Current.MainWindow.DataContext as MainViewModel;
        var mainVm2 = System.Windows.Application.Current.MainWindow.DataContext as LibraryMainViewModel;
        if (mainVm1 is not null || mainVm2 is not null)
        {
            mainVm1!.CurrentPage = App.MainContainer.GetInstance<TView>();
            mainVm1.CurrentPage.DataContext = App.MainContainer.GetInstance<TViewModel>();

        }
    }
}
