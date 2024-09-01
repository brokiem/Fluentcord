using NetCord;

namespace Fluentcord.Models.Messages.Embed;

public class EmbedThumbnailModel : ModelBase
{
    public string? Url { get; set; }
    public string? ProxyUrl { get; set; }
    public int? Height { get; set; }
    public int? Width { get; set; }

    public EmbedThumbnailModel(string? url, string? proxyUrl = null, int? height = null, int? width = null)
    {
        Url = url;
        ProxyUrl = proxyUrl;
        Height = height;
        Width = width;
    }

    public EmbedThumbnailModel(EmbedThumbnail embedThumbnail)
    {
        Url = embedThumbnail.Url;
        ProxyUrl = embedThumbnail.ProxyUrl;
        Height = embedThumbnail.Height;
        Width = embedThumbnail.Width;
    }
}