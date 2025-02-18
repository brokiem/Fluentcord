using System;
using System.Collections.Generic;
using System.Globalization;
using Avalonia.Controls;
using Avalonia.Data.Converters;
using Fluentcord.Models.GuildChannels;
using Fluentcord.Models.Members;
using Fluentcord.UI.Main.Channel;
using Fluentcord.UI.Main.Members;

namespace Fluentcord.Converters;

public class MemberModelToUiConverter : IValueConverter {
    public object Convert(object? model, Type targetType, object? parameter, CultureInfo culture) {
        if (model is null) {
            return new TextBlock { Text = "UI not found for model: null" };
        }

        UserControl? control = model switch {
            MembersGroupModel => new MembersGroupItem(),
            MemberUserModel => new MemberUserItem(),
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