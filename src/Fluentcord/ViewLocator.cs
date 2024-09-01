using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Fluentcord.ViewModels;
using Fluentcord.Views;

namespace Fluentcord;

public class ViewLocator : IDataTemplate
{
    public Control Build(object? data)
    {
        // TODO: Make a generator instead of hardcoding the code
        return data switch
        {
            LoginViewModel => new LoginView { DataContext = data, },
            MainViewModel => new MainView { DataContext = data, },
            StartingViewModel => new StartingView { DataContext = data, },
            _ => new TextBlock { Text = "View not found: " + data?.GetType().FullName }
        };
    }

    public bool Match(object? data)
    {
        return data is ViewModelBase;
    }
}