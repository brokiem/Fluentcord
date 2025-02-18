using NetCord;

namespace Fluentcord.Models.Messages.Embed;

public class EmbedImageModel : ModelBase {
    public string? Url { get; set; }
    public string? ProxyUrl { get; set; }
    public int? Height { get; set; }
    public int? Width { get; set; }

    public EmbedImageModel(string? url, string? proxyUrl = null, int? height = null, int? width = null) {
        Url = url;
        ProxyUrl = proxyUrl;
        Height = height;
        Width = width;
    }

    public EmbedImageModel(EmbedImage embedImage) {
        Url = embedImage.Url;
        ProxyUrl = embedImage.ProxyUrl;
        Height = embedImage.Height;
        Width = embedImage.Width;
    }
}