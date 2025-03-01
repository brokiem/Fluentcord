﻿using System;
using System.Linq;
using Avalonia.Collections;
using CommunityToolkit.Mvvm.ComponentModel;
using Fluentcord.Models.Messages.Attachment;
using Fluentcord.Models.Messages.Embed;
using Fluentcord.Models.User;
using Fluentcord.Utils;
using NetCord;
using NetCord.Gateway;

namespace Fluentcord.Models.Messages;

public partial class MessageModel : ModelBase {
    public ulong MessageId { get; }
    public ulong ChannelId { get; }
    public UserModel Author { get; }

    [ObservableProperty] private string? _content;
    [ObservableProperty] private bool _isEdited;

    public DateTimeOffset CreatedAt { get; }
    public string Timestamp => TimeUtils.FormatTime(CreatedAt);
    public DateTimeOffset? EditedAt { get; set; }
    public string? EditedTimestamp => EditedAt is null ? null : TimeUtils.FormatTime(EditedAt.Value);

    public bool MentionEveryone { get; set; }

    public AvaloniaList<UserModel> Mentions { get; set; }
    public AvaloniaList<AttachmentModel> Attachments { get; set; }
    public AvaloniaList<EmbedModel> Embeds { get; set; }

    public bool HasAttachment { get; set; }
    public bool Pinned { get; set; }
    public ulong? WebhookId { get; }
    public MessageType MessageType { get; }
    public ulong? ApplicationId { get; }
    public MessageFlags? Flags { get; set; }
    public MessageReferenceModel? MessageReference { get; }

    public bool IsReply { get; }

    public MessageModel(ulong messageId,
        ulong channelId,
        UserModel author,
        string? content = null,
        bool isEdited = false,
        DateTimeOffset createdAt = default,
        DateTimeOffset? editedAt = null,
        bool mentionEveryone = false,
        AvaloniaList<UserModel>? mentions = null,
        AvaloniaList<AttachmentModel>? attachments = null,
        AvaloniaList<EmbedModel>? embeds = null,
        bool pinned = false,
        ulong? webhookId = null,
        MessageType messageType = default,
        ulong? applicationId = null,
        MessageFlags? flags = null,
        MessageReferenceModel? messageReference = null,
        bool isReply = false
    ) {
        MessageId = messageId;
        ChannelId = channelId;
        Author = author;
        Content = content;
        IsEdited = isEdited;
        CreatedAt = createdAt;
        EditedAt = editedAt;
        MentionEveryone = mentionEveryone;
        Mentions = mentions ?? [];
        Attachments = attachments ?? [];
        Embeds = embeds ?? [];
        HasAttachment = Attachments.Count > 0;
        Pinned = pinned;
        WebhookId = webhookId;
        MessageType = messageType;
        ApplicationId = applicationId;
        Flags = flags;
        MessageReference = messageReference;
        IsReply = isReply;
    }

    public MessageModel(Message message) {
        MessageId = message.Id;
        ChannelId = message.ChannelId;
        Author = new UserModel(message.Author);
        Content = message.Content;
        CreatedAt = message.CreatedAt;
        EditedAt = message.EditedAt;
        MentionEveryone = message.MentionEveryone;
        Mentions = new AvaloniaList<UserModel>(message.MentionedUsers.Select(u => new UserModel(u)));
        Attachments = new AvaloniaList<AttachmentModel>(message.Attachments.Select(AttachmentModel.CreateAttachmentModel));
        Embeds = new AvaloniaList<EmbedModel>(message.Embeds.Select(e => new EmbedModel(e)));
        HasAttachment = Attachments.Count > 0;
        Pinned = message.IsPinned;
        WebhookId = message.WebhookId;
        MessageType = message.Type;
        ApplicationId = message.ApplicationId;
        Flags = message.Flags;
        MessageReference = message.MessageReference != null ? new MessageReferenceModel(message.MessageReference) : null;
        IsEdited = message.EditedAt is not null;
        IsReply = message.Type == MessageType.Reply;
    }
}