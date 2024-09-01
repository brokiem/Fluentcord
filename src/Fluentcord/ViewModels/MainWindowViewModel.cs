using CommunityToolkit.Mvvm.ComponentModel;
using Fluentcord.Services;

namespace Fluentcord.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty] private INavigationService _navigationService;
    
    // Default constructor for designer
    public MainWindowViewModel()
    {
    }

    public MainWindowViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;
        navigationService.Navigate<StartingViewModel>();
    }
}