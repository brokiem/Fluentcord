using Fluentcord.Utils;
using NetCord;

namespace Fluentcord.Models.Messages.Attachment;

public sealed class ImageAttachmentModel : AttachmentModel
{
    public override ulong Id { get; }
    public override string FileName { get; }
    public override string? Description { get; }
    public override string? ContentType { get; }
    public override int Size { get; }
    public override string Url { get; }
    public override string ProxyUrl { get; }
    public override bool Ephemeral { get; }
    public override AttachmentFlags? Flags { get; }

    public int Height { get; }
    public int Width { get; }

    public ImageAttachmentModel(
        ulong id,
        string fileName,
        string? description,
        string? contentType,
        int size,
        string url,
        string proxyUrl,
        bool ephemeral,
        AttachmentFlags? flags,
        int height,
        int width)
    {
        Id = id;
        FileName = fileName;
        Description = description;
        ContentType = contentType;
        Size = size;
        ProxyUrl = proxyUrl;
        Ephemeral = ephemeral;
        Flags = flags;

        Width = ImageUtils.FormatWidth(width, height);
        Height = ImageUtils.FormatHeight(width, height);
        Url = ImageUtils.FormatImageUrl(url, Width, Height);
    }

    public ImageAttachmentModel(ImageAttachment imageAttachment)
    {
        Id = imageAttachment.Id;
        FileName = imageAttachment.FileName;
        Description = imageAttachment.Description;
        ContentType = imageAttachment.ContentType?.MediaType;
        Size = imageAttachment.Size;
        ProxyUrl = imageAttachment.ProxyUrl;
        Ephemeral = imageAttachment.Ephemeral;
        Flags = imageAttachment.Flags;
        
        Width = ImageUtils.FormatWidth(imageAttachment.Width, imageAttachment.Height);
        Height = ImageUtils.FormatHeight(imageAttachment.Width, imageAttachment.Height);
        Url = ImageUtils.FormatImageUrl(imageAttachment.Url, Width, Height);
    }
}