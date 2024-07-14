using System.Windows.Controls;
using EFCore_LibrarySystem.ViewModels;

namespace EFCore_LibrarySystem.Services;

public interface INavigationService
{
    void Navigate<TView, TViewModel>() where TView : Page where TViewModel : ViewModel;
}
