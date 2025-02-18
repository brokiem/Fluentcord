using System;
using NetCord;

namespace Fluentcord.Models.Messages.Embed;

public class EmbedVideoModel : ModelBase {
    public string? Url { get; set; }
    public string? ProxyUrl { get; set; }
    public int? Height { get; set; }
    public int? Width { get; set; }

    public EmbedVideoModel(string? url, string? proxyUrl = null, int? height = null, int? width = null) {
        Url = url;
        ProxyUrl = proxyUrl;
        Height = height;
        Width = width;
    }

    public EmbedVideoModel(EmbedVideo embedVideo) {
        Url = embedVideo.Url;
        ProxyUrl = embedVideo.ProxyUrl;
        Height = embedVideo.Height;
        Width = embedVideo.Width;
    }
}