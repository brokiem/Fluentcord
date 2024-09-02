using NetCord;

namespace Fluentcord.Models.Messages;

// Documentation: https://discord.com/developers/docs/resources/message#message-reference-structure
public class MessageReferenceModel : ModelBase
{
    public ulong MessageId { get; }
    
    public string AuthorAvatarUrl { get; }
    public string AuthorUsername { get; }
    public string MessageContent { get; }
    public bool ContainAttachments { get; }

    public MessageReferenceModel(ulong messageId, string authorAvatarUrl, string authorUsername, string messageContent, bool containAttachments)
    {
        MessageId = messageId;
        AuthorAvatarUrl = authorAvatarUrl;
        AuthorUsername = authorUsername;
        MessageContent = messageContent;
        ContainAttachments = containAttachments;
    }
    
    public MessageReferenceModel(MessageModel message)
    {
        MessageId = message.MessageId;
        AuthorAvatarUrl = message.Author.AvatarUrl;
        AuthorUsername = message.Author.Username;
        MessageContent = message.Content;
        ContainAttachments = message.Attachments.Length > 0;
    }

    public MessageReferenceModel(MessageReference messageReference)
    {
        // TODO: Implement this
    }
}