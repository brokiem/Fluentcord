using System.Collections.Specialized;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using Fluentcord.ViewModels;

namespace Fluentcord.UI.Main.Message;

public partial class MessageList : UserControl
{
    public MessageList()
    {
        InitializeComponent();
    }


    private void Control_OnLoaded(object? sender, RoutedEventArgs e)
    {
        var mainViewModel = (MainViewModel)DataContext!;
        mainViewModel.Messages.CollectionChanged += MessagesOnCollectionChanged;
    }

    private void Control_OnUnloaded(object? sender, RoutedEventArgs e)
    {
        var mainViewModel = (MainViewModel)DataContext!;
        mainViewModel.Messages.CollectionChanged -= MessagesOnCollectionChanged;
    }

    private void MessagesOnCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        // Check if ScrollViewer offset is at the bottom
        if (MessagesScrollViewer.Offset.Y < MessagesScrollViewer.Extent.Height - MessagesScrollViewer.Viewport.Height - 10)
        {
            return;
        }

        Dispatcher.UIThread.Post(MessagesScrollViewer.ScrollToEnd);
    }
}