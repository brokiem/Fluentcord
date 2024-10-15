namespace Fluentcord.Models.Members;

public sealed class MembersGroupModel : MemberModel
{
    public override string Name { get; set; }
    
    public int OnlineCount { get; set; }

    public string FormattedString => $"{Name.ToUpper()}  —  {OnlineCount}";
}