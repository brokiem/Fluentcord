using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Fluentcord.Services;

namespace Fluentcord.ViewModels;

public partial class LoginViewModel : ViewModelBase {
    // ReSharper disable once InconsistentNaming
    private readonly INavigationService NavigationService;
    public ICommand LoginCommand { get; }
    public string Token { get; set; } = string.Empty;

    // Default constructor for designer
    public LoginViewModel() { }

    public LoginViewModel(INavigationService navigationService) {
        NavigationService = navigationService;
        LoginCommand = new RelayCommand(Login);
    }

    private void Login() {
        NavigationService.Navigate<StartingViewModel>();

        // TODO: Implement discord client service and login
    }
}