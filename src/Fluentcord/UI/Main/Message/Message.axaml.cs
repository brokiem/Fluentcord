using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace Fluentcord.UI.Main.Message;

public partial class Message : UserControl {
    public Message() {
        InitializeComponent();
    }


    private void Control_OnLoaded(object? sender, RoutedEventArgs e) {
        MessageGrid.PointerEntered += (o, args) => { MessageActionsBorder.IsVisible = true; };

        MessageGrid.PointerExited += (o, args) => { MessageActionsBorder.IsVisible = false; };
    }
}