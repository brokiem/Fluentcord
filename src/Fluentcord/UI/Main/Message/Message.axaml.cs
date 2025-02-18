using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Fluentcord.Models.Messages;
using Fluentcord.ViewModels;

namespace Fluentcord.UI.Main.Message;

public partial class Message : UserControl {
    public Message() {
        InitializeComponent();
    }


    private void Control_OnLoaded(object? sender, RoutedEventArgs e) {
        MessageGrid.PointerEntered += (o, args) => { MessageActionsBorder.IsVisible = true; };

        MessageGrid.PointerExited += (o, args) => { MessageActionsBorder.IsVisible = false; };
    }

    private void ReplyButton_OnTapped(object? sender, TappedEventArgs e) {
        var mainViewModel = App.GetService<MainViewModel>();
        mainViewModel.SelectedReplyMessage = (MessageModel)DataContext!;
    }
}