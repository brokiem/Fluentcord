using System;
using System.Linq;
using NetCord;

namespace Fluentcord.Models.Messages.Embed;

public class EmbedModel : ModelBase {
    public string? Title { get; }
    public EmbedType? Type { get; }
    public string? Description { get; }
    public string? Url { get; }
    public DateTimeOffset? Timestamp { get; }
    public object? Color { get; }

    public EmbedFooterModel? Footer { get; }
    public EmbedImageModel? Image { get; }
    public EmbedThumbnailModel? Thumbnail { get; }
    public EmbedVideoModel? Video { get; }
    public EmbedProviderModel? Provider { get; }
    public EmbedAuthorModel? Author { get; }
    public EmbedFieldsModel[]? Fields { get; }

    public EmbedModel(string? title = null,
        EmbedType? type = null,
        string? description = null,
        string? url = null,
        DateTimeOffset? timestamp = null,
        object? color = null,
        EmbedFooterModel? footer = null,
        EmbedImageModel? image = null,
        EmbedThumbnailModel? thumbnail = null,
        EmbedVideoModel? video = null,
        EmbedProviderModel? provider = null,
        EmbedAuthorModel? author = null,
        EmbedFieldsModel[]? fields = null
    ) {
        Title = title;
        Type = type;
        Description = description;
        Url = url;
        Timestamp = timestamp;
        Color = color;
        Footer = footer;
        Image = image;
        Thumbnail = thumbnail;
        Video = video;
        Provider = provider;
        Author = author;
        Fields = fields;
    }

    public EmbedModel(NetCord.Embed embed) {
        Title = embed.Title;
        Type = embed.Type;
        Description = embed.Description;
        Url = embed.Url;
        Timestamp = embed.Timestamp;
        Color = Utils.Utils.NetCordColorToBrush(embed.Color);
        Footer = embed.Footer != null ? new EmbedFooterModel(embed.Footer) : null;
        Image = embed.Image != null ? new EmbedImageModel(embed.Image) : null;
        Thumbnail = embed.Thumbnail != null ? new EmbedThumbnailModel(embed.Thumbnail) : null;
        Video = embed.Video != null ? new EmbedVideoModel(embed.Video) : null;
        Provider = embed.Provider != null ? new EmbedProviderModel(embed.Provider) : null;
        Author = embed.Author != null ? new EmbedAuthorModel(embed.Author) : null;
        Fields = embed.Fields.Select(f => new EmbedFieldsModel(f)).ToArray();
    }
}