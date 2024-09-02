using NetCord;

namespace Fluentcord.Models.Messages.Attachment;

public class FileAttachmentModel(NetCord.Attachment attachment) : AttachmentModel
{
    public override ulong Id { get; } = attachment.Id;
    public override string FileName { get; } = attachment.FileName;
    public override string? Description { get; } = attachment.Description;
    public override string? ContentType { get; } = attachment.ContentType?.MediaType;
    public override int Size { get; } = attachment.Size;
    public override string Url { get; } = attachment.Url;
    public override string ProxyUrl { get; } = attachment.ProxyUrl;
    public override bool Ephemeral { get; } = attachment.Ephemeral;
    public override AttachmentFlags? Flags { get; } = attachment.Flags;
}