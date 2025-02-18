using Avalonia.Media;
using Avalonia.Media.Immutable;

namespace Fluentcord.Utils;

public static class ColorUtils {
    public static IImmutableSolidColorBrush TextFillColorTertiaryBrush => new ImmutableSolidColorBrush(new Color(255, 204, 204, 204));
    public static IImmutableSolidColorBrush TextFillColorSecondaryBrush => new ImmutableSolidColorBrush(new Color(255, 204, 204, 204));
}