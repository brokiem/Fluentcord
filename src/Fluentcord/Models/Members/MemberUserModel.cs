namespace Fluentcord.Models.Members;

public enum Status {
    Online,
    Idle,
    DoNotDisturb,
    Invisible,
}

public sealed class MemberUserModel : MemberModel {
    public ulong Id { get; set; }
    public override string Name { get; set; }

    public string AvatarUrl { get; set; }

    public bool IsBot { get; set; }

    private Status _status;

    public Status Status {
        get => _status;
        set {
            _status = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(StatusColor));
        }
    }

    public string StatusColor {
        get {
            return Status switch {
                Status.Online => "#22a75a",
                Status.Idle => "#eab63a",
                Status.DoNotDisturb => "#ec4047",
                Status.Invisible => "#81848e",
                _ => "#81848e",
            };
        }
    }
}