using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Presenters;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.Threading;
using Fluentcord.Models.Messages;
using Fluentcord.ViewModels;

namespace Fluentcord.UI.Main.Message;

public partial class MessageList : UserControl {
    public MessageList() {
        InitializeComponent();
    }


    private void Control_OnLoaded(object? sender, RoutedEventArgs e) {
        var mainViewModel = (MainViewModel)DataContext!;
        mainViewModel.Messages.CollectionChanged += MessagesOnCollectionChanged;
    }

    private void Control_OnUnloaded(object? sender, RoutedEventArgs e) {
        var mainViewModel = (MainViewModel)DataContext!;
        mainViewModel.Messages.CollectionChanged -= MessagesOnCollectionChanged;
    }

    private void MessagesOnCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e) {
        // Check if ScrollViewer offset is at the bottom
        if (MessagesScrollViewer.Offset.Y <
            MessagesScrollViewer.Extent.Height - MessagesScrollViewer.Viewport.Height - 10) {
            return;
        }

        // TODO: Scroll until unread messages are visible
        Dispatcher.UIThread.Post(MessagesScrollViewer.ScrollToEnd);
    }

    private void RepliedMessage_OnTapped(object? sender, TappedEventArgs e) {
        var mainViewModel = (MainViewModel)DataContext!;
        var listBoxItem = (ListBoxItem)sender!;
        var messageModel = (MessageModel)listBoxItem.DataContext!;
        var repliedMessageId = messageModel.MessageReference?.MessageId;

        if (repliedMessageId == null) {
            return;
        }

        var index = mainViewModel.Messages.IndexOf(mainViewModel.Messages.FirstOrDefault(x => x.MessageId == repliedMessageId));
        if (index == -1)
            // TODO: Fetch the message from the server
        {
            return;
        }

        MessagesRepeater.ScrollIntoView(index);

        var element = (ContentPresenter?)MessagesRepeater.ContainerFromIndex(index);
        if (element != null) {
            HighlightElement(element);
        }
    }

    private void HighlightElement(ContentPresenter element) {
        _ = Task.Run(async () => {
            var colors = new[] { Colors.Orange, Colors.Transparent };
            for (var i = 0; i < 2; i++) {
                foreach (var color in colors) {
                    Dispatcher.UIThread.Post(() => element.Background = new SolidColorBrush(color, 0.1));
                    await Task.Delay(400);
                }
            }
        });
    }
}