using System.Diagnostics;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Fluentcord.Models.GuildChannels;
using Fluentcord.ViewModels;

namespace Fluentcord.UI.Main.Channel;

public partial class TextChannelItem : UserControl
{
    public TextChannelItem()
    {
        InitializeComponent();
    }

    private void Control_OnLoaded(object? sender, RoutedEventArgs e)
    {
        var textChannelModel = (TextChannelModel)DataContext!;
        var mainViewModel = App.GetService<MainViewModel>();

        // Extra logic because of virtualization
        if (mainViewModel.SelectedChannel is not null)
        {
            if (mainViewModel.SelectedChannel.Id == textChannelModel.Id)
            {
                ChannelItemControl.IsSelected = true;
                mainViewModel.SelectedChannelListBoxItem = ChannelItemControl;
            }
        }
    }

    private void OnChannelClicked(object? sender, TappedEventArgs e)
    {
        var listBoxItem = (ListBoxItem?)sender;
        if (listBoxItem is null) return;
        if (listBoxItem.IsSelected) return;

        var textChannelModel = (TextChannelModel)DataContext!;
        var mainViewModel = App.GetService<MainViewModel>();

        if (mainViewModel.SelectedChannelListBoxItem is not null)
        {
            mainViewModel.SelectedChannelListBoxItem.IsSelected = false;
        }

        mainViewModel.SelectChannel(textChannelModel);
        mainViewModel.SelectedChannelListBoxItem = listBoxItem;
        listBoxItem.IsSelected = true;
    }

    private void Control_OnUnloaded(object? sender, RoutedEventArgs e)
    {
        var textChannelModel = (TextChannelModel)DataContext!;
        var mainViewModel = App.GetService<MainViewModel>();

        // Because of virtualization, we need to remove the object from memory
        if (mainViewModel.SelectedChannel is not null)
        {
            if (mainViewModel.SelectedChannel.Id == textChannelModel.Id)
            {
                if (mainViewModel.SelectedChannelListBoxItem is null) return;

                mainViewModel.SelectedChannelListBoxItem = null;
            }
        }
    }
}