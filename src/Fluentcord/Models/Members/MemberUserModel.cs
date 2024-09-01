namespace Fluentcord.Models.Members;

public sealed class MemberUserModel : MemberModel
{
    public ulong Id { get; set; }
    public override string Name { get; set; }
    
    public string AvatarUrl { get; set; }
}