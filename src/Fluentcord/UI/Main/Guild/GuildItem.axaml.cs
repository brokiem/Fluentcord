using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Fluentcord.Models;
using Fluentcord.ViewModels;

namespace Fluentcord.UI.Main.Guild;

public partial class GuildItem : UserControl
{
    public GuildItem()
    {
        InitializeComponent();
    }
    
    private void Control_OnLoaded(object? sender, RoutedEventArgs e)
    {
        var guildModel = (GuildModel)DataContext!;
        var mainViewModel = App.GetService<MainViewModel>();

        // Extra logic because of virtualization
        if (mainViewModel.SelectedGuild is not null)
        {
            if (mainViewModel.SelectedGuild.Id == guildModel.Id)
            {
                GuildItemControl.IsSelected = true;
                mainViewModel.SelectedGuildListBoxItem = GuildItemControl;
            }
        }
    }
    
    private void Control_OnUnloaded(object? sender, RoutedEventArgs e)
    {
        var guildModel = (GuildModel)DataContext!;
        var mainViewModel = App.GetService<MainViewModel>();

        // Because of virtualization, we need to remove the object from memory
        if (mainViewModel.SelectedGuild is not null)
        {
            if (mainViewModel.SelectedGuild.Id == guildModel.Id)
            {
                if (mainViewModel.SelectedGuildListBoxItem is null) return;

                mainViewModel.SelectedGuildListBoxItem = null;
            }
        }
    }
}