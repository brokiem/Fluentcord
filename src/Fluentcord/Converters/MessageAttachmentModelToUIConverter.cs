using System;
using System.Globalization;
using Avalonia.Controls;
using Avalonia.Data.Converters;
using Fluentcord.Models.Messages.Attachment;
using Fluentcord.UI.Main.Message.Attachment;

namespace Fluentcord.Converters;

public class MessageAttachmentModelToUiConverter : IValueConverter
{
    public object? Convert(object? model, Type targetType, object? parameter, CultureInfo culture)
    {
        if (model is null)
            return new TextBlock { Text = "UI not found for model: null" };
        
        UserControl? control = model switch
        {
            FileAttachmentModel => new FileAttachment(),
            ImageAttachmentModel => new ImageAttachment(),
            _ => null
        };

        if (control is null)
            return new TextBlock { Text = $"UI not found for model: {model.GetType().Name}" };

        control.DataContext = model;
        return control;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}