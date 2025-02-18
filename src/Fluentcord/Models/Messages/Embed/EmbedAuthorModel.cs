using System;
using NetCord;

namespace Fluentcord.Models.Messages.Embed;

public class EmbedAuthorModel : ModelBase {
    public string? Name { get; set; }
    public string? Url { get; set; }
    public string? IconUrl { get; set; }
    public string? ProxyIconUrl { get; set; }

    public EmbedAuthorModel(string? name, string? url = null, string? iconUrl = null, string? proxyIconUrl = null) {
        Name = name;
        Url = url;
        IconUrl = iconUrl;
        ProxyIconUrl = proxyIconUrl;
    }

    public EmbedAuthorModel(EmbedAuthor embedAuthor) {
        Name = embedAuthor.Name;
        Url = embedAuthor.Url;
        IconUrl = embedAuthor.IconUrl;
        ProxyIconUrl = embedAuthor.ProxyIconUrl;
    }
}