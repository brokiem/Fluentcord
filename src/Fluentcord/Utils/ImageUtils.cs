using System;

namespace Fluentcord.Utils;

public class ImageUtils {
    private const string DiscordCdnUrl = "cdn.discordapp.com";
    private const string DiscordMediaUrl = "media.discordapp.net";
    private const int MaxImageWidth = 550; //884;
    private const int MaxImageHeight = 349; //497;

    /// <summary>
    /// Formats the dimensions of an image. The width and height are automatically calculated to preserve the aspect ratio.
    /// </summary>
    /// <param name="width">The original width of the image.</param>
    /// <param name="height">The original height of the image.</param>
    /// <param name="maxWidth">The maximum allowed width of the image. If null, the default maximum width is used.</param>
    /// <param name="maxHeight">The maximum allowed height of the image. If null, the default maximum height is used.</param>
    /// <returns>A tuple containing the formatted width and height of the image.</returns>
    private static (int, int) FormatDimensions(int width, int height, int? maxWidth = null, int? maxHeight = null) {
        var maxWidthOrDefault = maxWidth ?? MaxImageWidth;
        var maxHeightOrDefault = maxHeight ?? MaxImageHeight;

        // Calculate the ratio to scale the image by, ensuring that neither dimension exceeds its maximum.
        // If the original dimensions are smaller than the maximum, use the original dimensions.
        var ratio = Math.Min(1.0, Math.Min(maxWidthOrDefault / (double)width, maxHeightOrDefault / (double)height));

        var formattedWidth = (int)(width * ratio);
        var formattedHeight = (int)(height * ratio);

        return (formattedWidth, formattedHeight);
    }

    /// <summary>
    /// Formats the width of an image. The height is automatically calculated to preserve the aspect ratio.
    /// </summary>
    /// <param name="width">The original width of the image.</param>
    /// <param name="height">The original height of the image.</param>
    /// <param name="maxWidth">The maximum allowed width of the image. If null, the default maximum width is used.</param>
    /// <param name="maxHeight">The maximum allowed height of the image. If null, the default maximum height is used.</param>
    /// <returns>The formatted width of the image.</returns>
    public static int FormatWidth(int width, int height, int? maxWidth = null, int? maxHeight = null) {
        var (formattedWidth, _) = FormatDimensions(width, height, maxWidth, maxHeight);
        return formattedWidth;
    }

    /// <summary>
    /// Formats the height of an image. The width is automatically calculated to preserve the aspect ratio.
    /// </summary>
    /// <param name="width">The original width of the image.</param>
    /// <param name="height">The original height of the image.</param>
    /// <param name="maxWidth">The maximum allowed width of the image. If null, the default maximum width is used.</param>
    /// <param name="maxHeight">The maximum allowed height of the image. If null, the default maximum height is used.</param>
    /// <returns>The formatted height of the image.</returns>
    public static int FormatHeight(int width, int height, int? maxWidth = null, int? maxHeight = null) {
        var (_, formattedHeight) = FormatDimensions(width, height, maxWidth, maxHeight);
        return formattedHeight;
    }

    /// <summary>
    /// Formats the URL of an image to include the formatted width and height as query parameters.
    /// </summary>
    /// <param name="url">The original URL of the image.</param>
    /// <param name="width">The original width of the image.</param>
    /// <param name="height">The original height of the image.</param>
    /// <param name="maxWidth">The maximum allowed width of the image. If null, the default maximum width is used.</param>
    /// <param name="maxHeight">The maximum allowed height of the image. If null, the default maximum height is used.</param>
    /// <returns>A string representing the formatted URL of the image.</returns>
    public static string FormatImageUrl(string url, int width, int height, int? maxWidth = null, int? maxHeight = null) {
        var formattedWidth = FormatWidth(width, height, maxWidth, maxHeight);
        var formattedHeight = FormatHeight(width, height, maxWidth, maxHeight);

        return $"{url.Replace(DiscordCdnUrl, DiscordMediaUrl)}?width={formattedWidth}&height={formattedHeight}";
    }

    public static string FormatCdnUrl(string url, int size) => url.StartsWith(DiscordCdnUrl) ? $"{url}?size={size}" : url;
}