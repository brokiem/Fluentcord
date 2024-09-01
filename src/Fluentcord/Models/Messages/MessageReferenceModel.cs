using NetCord;

namespace Fluentcord.Models.Messages;

// Documentation: https://discord.com/developers/docs/resources/message#message-reference-structure
public class MessageReferenceModel : ModelBase
{
    public MessageModel Message { get; }

    public MessageReferenceModel(MessageModel message)
    {
        Message = message;
    }

    public MessageReferenceModel(MessageReference messageReference)
    {
        // TODO: Implement this
    }
}