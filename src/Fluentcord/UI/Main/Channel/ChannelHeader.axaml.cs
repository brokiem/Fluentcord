using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Media;
using Fluentcord.Utils;
using Fluentcord.ViewModels;

namespace Fluentcord.UI.Main.Channel;

public partial class ChannelHeader : UserControl
{
    public ChannelHeader()
    {
        InitializeComponent();
    }
    
    private void Control_OnLoaded(object? sender, RoutedEventArgs e)
    {
        var mainViewModel = (MainViewModel)DataContext!;
        
        MemberListToggleIcon.Foreground = mainViewModel.ShowMemberList ? Brushes.White : ColorUtils.TextFillColorSecondaryBrush;
    }

    private void MemberListToggle_OnTapped(object? sender, TappedEventArgs e)
    {
        var mainViewModel = (MainViewModel)DataContext!;
        
        mainViewModel.ShowMemberList = !mainViewModel.ShowMemberList;
        MemberListToggleIcon.Foreground = mainViewModel.ShowMemberList ? Brushes.White : ColorUtils.TextFillColorSecondaryBrush;
    }
}