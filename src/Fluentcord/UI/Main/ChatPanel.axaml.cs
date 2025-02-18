using Avalonia.Controls;
using Avalonia.Input;
using Fluentcord.ViewModels;

namespace Fluentcord.UI.Main;

public partial class ChatPanel : UserControl {
    public ChatPanel() {
        InitializeComponent();
    }

    private void CloseReplyingButton_OnTapped(object? sender, TappedEventArgs e) {
        var mainViewModel = (MainViewModel)DataContext!;
        mainViewModel.SelectedReplyMessage = null;
    }
}