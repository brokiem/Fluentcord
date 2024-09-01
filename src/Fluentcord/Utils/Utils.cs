using Avalonia.Media;
using Color = NetCord.Color;

namespace Fluentcord.Utils;

public static class Utils
{
    public static object? NetCordColorToBrush(Color? color)
    {
        var converter = new BrushConverter();
        return color != null
            ? converter.ConvertFromString("#" + color.Value.RawValue.ToString("X6"))
            : converter.ConvertFromString("#4f545c");
    }
}