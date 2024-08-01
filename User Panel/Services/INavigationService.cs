using EFCore_LibrarySystem.ViewModels;
using System.Windows.Controls;

namespace User_Panel.Services;

public interface INavigationService
{
    void Navigate<TView, TViewModel>() where TView : Page where TViewModel : ViewModel;

}
