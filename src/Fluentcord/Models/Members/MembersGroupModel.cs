namespace Fluentcord.Models.Members;

public sealed class MembersGroupModel : MemberModel
{
    public override required string Name { get; set; }
    
    public int OnlineCount { get; set; }
}