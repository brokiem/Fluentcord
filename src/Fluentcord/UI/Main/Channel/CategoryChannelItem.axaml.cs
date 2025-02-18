using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Threading;
using Fluentcord.Models.GuildChannels;
using Fluentcord.ViewModels;

namespace Fluentcord.UI.Main.Channel;

public partial class CategoryChannelItem : UserControl {
    public CategoryChannelItem() {
        InitializeComponent();
    }

    private void OnChannelClicked(object? sender, TappedEventArgs e) {
        var categoryChannelModel = (CategoryChannelModel)DataContext!;
        var mainViewModel = App.GetService<MainViewModel>();

        // Hide the channels in the category
        mainViewModel.SelectChannel(categoryChannelModel);
    }
}