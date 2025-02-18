using NetCord;

namespace Fluentcord.Models.Messages.Embed;

public class EmbedFooterModel : ModelBase {
    public string Text { get; set; }
    public string? IconUrl { get; set; }
    public string? ProxyIconUrl { get; set; }

    public EmbedFooterModel(string text, string? iconUrl = null, string? proxyIconUrl = null) {
        Text = text;
        IconUrl = iconUrl;
        ProxyIconUrl = proxyIconUrl;
    }

    public EmbedFooterModel(EmbedFooter embedFooter) {
        Text = embedFooter.Text;
        IconUrl = embedFooter.IconUrl;
        ProxyIconUrl = embedFooter.ProxyIconUrl;
    }
}