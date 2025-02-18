using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Fluentcord.Models;
using Fluentcord.ViewModels;

namespace Fluentcord.UI.Main.Guild;

public partial class GuildList : UserControl {
    public GuildList() {
        InitializeComponent();
    }

    private void OnGuildClicked(object? sender, TappedEventArgs e) {
        var guildItem = (GuildItem?)sender;
        var listBoxItem = guildItem?.FindControl<ListBoxItem>("GuildItemControl");
        if (listBoxItem is null) {
            return;
        }

        if (listBoxItem.IsSelected) {
            return;
        }

        var guildModel = (GuildModel)listBoxItem.DataContext!;
        var mainViewModel = App.GetService<MainViewModel>();

        if (mainViewModel.SelectedGuildListBoxItem is not null) {
            mainViewModel.SelectedGuildListBoxItem.IsSelected = false;
        }

        mainViewModel.SelectGuild(guildModel);
        mainViewModel.SelectedGuildListBoxItem = listBoxItem;
        listBoxItem.IsSelected = true;
    }
}