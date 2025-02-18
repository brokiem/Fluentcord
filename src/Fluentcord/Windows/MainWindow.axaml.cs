using System;
using System.Runtime.InteropServices;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Fluentcord.Helpers;

namespace Fluentcord.Windows;

public partial class MainWindow : Window {
    public MainWindow() {
        InitializeComponent();

        // Run only on Windows
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) {
            // Fix the hidden taskbar cannot be triggered when the window is maximized.
            var hwnd = TryGetPlatformHandle()?.Handle;
            if (hwnd != null) {
                RuntimeHelper.SetPropW(hwnd.Value, "NonRudeHWND", new IntPtr(1));
            }
        }
    }

    private void TopLevel_OnOpened(object? sender, EventArgs e) {
        WindowState = WindowState.Maximized;
    }
}