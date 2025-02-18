using System;
using NetCord;

namespace Fluentcord.Models.Messages.Attachment;

public abstract class AttachmentModel : ModelBase {
    public abstract ulong Id { get; }
    public abstract string FileName { get; }

    public abstract string? Description { get; }
    public abstract string? ContentType { get; }

    public abstract int Size { get; }
    public abstract string Url { get; }
    public abstract string ProxyUrl { get; }

    public abstract bool Ephemeral { get; }
    public abstract AttachmentFlags? Flags { get; }

    public static AttachmentModel CreateAttachmentModel(NetCord.Attachment attachment) {
        return attachment switch {
            ImageAttachment imageAttachment => new ImageAttachmentModel(imageAttachment),
            VoiceAttachment voiceAttachment => new VoiceAttachmentModel(voiceAttachment),
            _ => new FileAttachmentModel(attachment),
        };
    }
}