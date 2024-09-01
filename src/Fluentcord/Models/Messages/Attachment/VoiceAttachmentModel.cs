using System.Collections.Generic;
using NetCord;

namespace Fluentcord.Models.Messages.Attachment;

public sealed class VoiceAttachmentModel : AttachmentModel
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

    public double DurationSecs { get; }
    public IReadOnlyList<byte> Waveform { get; }

    public VoiceAttachmentModel(
        ulong id,
        string fileName,
        string? description,
        string? contentType,
        int size,
        string url,
        string proxyUrl,
        bool ephemeral,
        AttachmentFlags? flags,
        double durationSecs,
        IReadOnlyList<byte> waveform)
    {
        Id = id;
        FileName = fileName;
        Description = description;
        ContentType = contentType;
        Size = size;
        Url = url;
        ProxyUrl = proxyUrl;
        Ephemeral = ephemeral;
        Flags = flags;
        DurationSecs = durationSecs;
        Waveform = waveform;
    }

    public VoiceAttachmentModel(VoiceAttachment voiceAttachment)
    {
        Id = voiceAttachment.Id;
        FileName = voiceAttachment.FileName;
        Description = voiceAttachment.Description;
        ContentType = voiceAttachment.ContentType?.MediaType;
        Size = voiceAttachment.Size;
        Url = voiceAttachment.Url;
        ProxyUrl = voiceAttachment.ProxyUrl;
        Ephemeral = voiceAttachment.Ephemeral;
        Flags = voiceAttachment.Flags;
        DurationSecs = voiceAttachment.Duration.TotalSeconds;
        Waveform = voiceAttachment.Waveform;
    }
}