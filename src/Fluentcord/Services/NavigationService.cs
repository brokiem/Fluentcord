using System;
using CommunityToolkit.Mvvm.ComponentModel;
using Fluentcord.ViewModels;

namespace Fluentcord.Services;

public interface INavigationService {
    ViewModelBase CurrentView { get; }
    void Navigate<T>() where T : ViewModelBase;
}

public partial class NavigationService(Func<Type, ViewModelBase> viewModelFactory)
    : ObservableObject, INavigationService {
    [ObservableProperty] private ViewModelBase? _currentView;

    public void Navigate<TViewModel>() where TViewModel : ViewModelBase {
        var viewModel = viewModelFactory.Invoke(typeof(TViewModel));
        CurrentView = viewModel;
    }
}