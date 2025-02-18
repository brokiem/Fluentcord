using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using Fluentcord.Services;
using Fluentcord.ViewModels;
using Fluentcord.Windows;
using Microsoft.Extensions.DependencyInjection;

namespace Fluentcord;

public partial class App : Application {
    private ServiceProvider? _serviceProvider;

    public static T GetService<T>() where T : class {
        if ((Current as App)!._serviceProvider!.GetService(typeof(T)) is not T service) {
            throw new ArgumentException($"{typeof(T)} needs to be registered in ConfigureServices within App.xaml.cs.");
        }

        return service;
    }

    public override void Initialize() {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted() {
        IServiceCollection services = new ServiceCollection();
        // Register windows
        services.AddSingleton<MainWindowViewModel>();
        services.AddSingleton<MainWindow>(serviceProvider => new MainWindow {
            DataContext = serviceProvider.GetRequiredService<MainWindowViewModel>(),
        });

        // Register view models
        services.AddSingleton<LoginViewModel>();
        services.AddSingleton<StartingViewModel>();
        services.AddSingleton<MainViewModel>();

        // Register services
        services.AddSingleton<INavigationService, NavigationService>();
        services.AddSingleton<Func<Type, ViewModelBase>>(serviceProvider =>
            // Add all the view models to the service for navigation
            viewModelType => (ViewModelBase)serviceProvider.GetRequiredService(viewModelType));
        services.AddSingleton<IDiscordClientService, DiscordClientService>();

        // Build the services
        _serviceProvider = services.BuildServiceProvider();

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop) {
            // Line below is needed to remove Avalonia data validation.
            // Without this line you will get duplicate validations from both Avalonia and CT
            BindingPlugins.DataValidators.RemoveAt(0);

            desktop.MainWindow = GetService<MainWindow>();
        }

        base.OnFrameworkInitializationCompleted();
    }
}