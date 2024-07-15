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
    public void Navigate<TView, TViewModel>(Page CurenPageSelect) where TView : Page where TViewModel : ViewModel
    {
        var mainVm = App.Current.MainWindow.DataContext as MainViewModel;
        if (mainVm is not null)
        {
            if (CurenPageSelect == mainVm.CurrentPage)
            {
                mainVm!.CurrentPage = App.MainContainer.GetInstance<TView>();
                mainVm.CurrentPage.DataContext = App.MainContainer.GetInstance<TViewModel>();
            }
            else
            {
                mainVm!.CurrentPage2 = App.MainContainer.GetInstance<TView>();
                mainVm.CurrentPage2.DataContext = App.MainContainer.GetInstance<TViewModel>();
            }
        }
    }
}
