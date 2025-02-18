using System;
using System.Collections.Generic;
using System.Globalization;
using Avalonia.Controls;
using Avalonia.Data.Converters;
using Fluentcord.Models.GuildChannels;
using Fluentcord.UI.Main.Channel;

namespace Fluentcord.Converters;

public class ChannelModelToUiConverter : IValueConverter {
    public object Convert(object? model, Type targetType, object? parameter, CultureInfo culture) {
        if (model is null) {
            return new TextBlock { Text = "UI not found for model: null" };
        }

        UserControl? control = model switch {
            CategoryChannelModel => new CategoryChannelItem(),
            TextChannelModel => new TextChannelItem(),
            VoiceChannelModel => new VoiceChannelItem(),
            VoiceChannelMemberModel => new VoiceChannelMember(),
            _ => null,
        };

        if (control is null) {
            return new TextBlock { Text = $"UI not found for model: {model.GetType().Name}" };
        }

        control.DataContext = model;
        return control;
    }


    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) => throw new NotSupportedException();
}