using System;
using System.Globalization;
using Avalonia.Controls;
using Avalonia.Data.Converters;
using Fluentcord.Models.Messages;
using Fluentcord.UI.Main.Message;

namespace Fluentcord.Converters;

public class MessageModelToRepliedMessageConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        var model = (MessageModel?)value;
        if (model is null) return new TextBlock { Text = "UI not found for model: null" };

        if (model.IsReply)
        {
            var repliedMessage = new RepliedMessage
            {
                DataContext = model
            };
            return repliedMessage;
        }

        return null;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}