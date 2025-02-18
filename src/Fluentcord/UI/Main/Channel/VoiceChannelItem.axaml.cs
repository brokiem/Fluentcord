using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using Fluentcord.Models.GuildChannels;
using Fluentcord.ViewModels;

namespace Fluentcord.UI.Main.Channel;

public partial class VoiceChannelItem : UserControl {
    public VoiceChannelItem() {
        InitializeComponent();
    }

    private void OnChannelClicked(object? sender, TappedEventArgs e) {
        var voiceChannelModel = (VoiceChannelModel)DataContext!;
        var mainViewModel = App.GetService<MainViewModel>();

        mainViewModel.SelectChannel(voiceChannelModel);
    }
}