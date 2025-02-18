using System;
using Avalonia.Collections;
using Avalonia.Controls;
using Avalonia.Threading;
using Bogus;
using CommunityToolkit.Mvvm.ComponentModel;
using Fluentcord.Models;
using Fluentcord.Models.GuildChannels;
using Fluentcord.Models.Members;
using Fluentcord.Models.Messages;
using Fluentcord.Models.Messages.Attachment;
using Fluentcord.Models.User;
using IdGen;
using NetCord;

namespace Fluentcord.ViewModels;

public partial class MainViewModel : ViewModelBase {
    [ObservableProperty] private AvaloniaList<GuildModel> _guilds = [];
    [ObservableProperty] private AvaloniaList<ChannelModel> _guildChannels = [];
    [ObservableProperty] private AvaloniaList<MessageModel> _messages = [];
    [ObservableProperty] private AvaloniaList<MemberModel> _members = [];

    [ObservableProperty] private GuildModel? _selectedGuild;
    [ObservableProperty] private ChannelModel? _selectedChannel;

    [ObservableProperty] private ListBoxItem? _selectedGuildListBoxItem;
    [ObservableProperty] private ListBoxItem? _selectedChannelListBoxItem;

    [ObservableProperty] private bool _showMemberList = true;
    
    [ObservableProperty] private MessageModel? _selectedReplyMessage;
    [ObservableProperty] private bool _mentionReply = true;

    private readonly Random _random = new();
    private readonly IdGenerator _idGenerator = new(0);
    private readonly Faker _faker = new();

    public MainViewModel() {
        LoadMockData();
    }

    private ulong CreateId() => (ulong)_idGenerator.CreateId();

    private void LoadMockData() {
        Dispatcher.UIThread.Post(() => {
            Guilds.Clear();
            GuildChannels.Clear();
            Messages.Clear();

            for (var i = 1; i <= _random.Next(30, 100); i++) {
                var guildId = CreateId();
                Guilds.Add(new GuildModel(guildId, $"The guild({i})",
                    _random.Next(-2, 3) > 0
                        ? $"https://cdn.discordapp.com/embed/avatars/{_random.Next(1, 5)}.png"
                        : null, false));
            }
        });
    }

    private void LoadChannels(ulong guildId) {
        GuildChannels.Clear();

        for (var j = 1; j <= _random.Next(15, 50); j++) {
            var categoryId = CreateId();
            GuildChannels.Add(new CategoryChannelModel(categoryId, "Text Channels", [], j, guildId, false));

            for (var k = 1; k <= _random.Next(5, 15); k++) {
                var channelId = CreateId();
                GuildChannels.Add(new TextChannelModel(channelId, guildId, $"{channelId}", j + k, [], 0, false,
                    "This is the channel topic", null, categoryId, k % 2 == 0, false));
            }

            var voiceId = CreateId();
            GuildChannels.Add(new VoiceChannelModel(voiceId, null, "Voice channel", -1, categoryId, null, null,
                null, guildId, [], 0, false, false));

            // Voice channel member
            var memberId = CreateId();
            GuildChannels.Add(new VoiceChannelMemberModel(voiceId, memberId, categoryId, _faker.Internet.UserName(),
                "https://cdn.discordapp.com/embed/avatars/4.png", true, true, false));
        }
    }

    private void LoadMembers(ulong channelId) {
        Members.Clear();

        Dispatcher.UIThread.Post(() => {
            for (ulong i = 1; i <= 10; i++) {
                Members.Add(new MembersGroupModel {
                    Name = _faker.Company.CompanyName().ToUpper(),
                    OnlineCount = 5,
                });

                for (var j = 0; j < 5; j++) {
                    Members.Add(new MemberUserModel {
                        Name = _faker.Internet.UserName(),
                        AvatarUrl = "https://cdn.discordapp.com/embed/avatars/4.png",
                        Status = _random.Next(0, 3) switch {
                            0 => Status.Online,
                            1 => Status.Idle,
                            2 => Status.DoNotDisturb,
                            _ => Status.Online,
                        },
                    });
                }
            }
        }, DispatcherPriority.Background);
    }

    private void LoadMessages(ulong channelId) {
        Messages.Clear();

        for (var l = 1; l <= _random.Next(40, 100); l++) {
            var messageId = CreateId();
            var authorId = CreateId();
            Messages.Add(new MessageModel(
                (ulong)l,
                channelId,
                new UserModel(
                    authorId,
                    $"{_faker.Name.FirstName()} {_faker.Name.LastName()}",
                    0,
                    globalName: null,
                    avatarUrl: $"https://cdn.discordapp.com/embed/avatars/{_random.Next(1, 5)}.png",
                    isBot: false,
                    isSystemUser: null,
                    mfaEnabled: null,
                    bannerUrl: null,
                    accentColor: null,
                    locale: null,
                    verified: null,
                    email: null,
                    flags: null,
                    premiumType: null,
                    publicFlags: null
                ),
                string.Join(" ", _faker.Rant.Reviews("Discord", _random.Next(1, 20))),
                false,
                DateTimeOffset.Now,
                null,
                false,
                [],
                [
                    new ImageAttachmentModel(1, "Attachment name", null, "image/png", 500,
                        "https://picsum.photos/536/354",
                        "https://picsum.photos/536/354",
                        false, null, 354, 536),
                ],
                [],
                false,
                null,
                MessageType.Default,
                null,
                null,
                new MessageReferenceModel(new MessageModel(
                    5,
                    channelId,
                    new UserModel(
                        authorId,
                        $"{_faker.Name.FirstName()} {_faker.Name.LastName()}",
                        0,
                        globalName: null,
                        avatarUrl: $"https://cdn.discordapp.com/embed/avatars/{_random.Next(1, 5)}.png",
                        isBot: false,
                        isSystemUser: null,
                        mfaEnabled: null,
                        bannerUrl: null,
                        accentColor: null,
                        locale: null,
                        verified: null,
                        email: null,
                        flags: null,
                        premiumType: null,
                        publicFlags: null
                    ),
                    _faker.Rant.Review("Discord"),
                    false,
                    DateTimeOffset.Now,
                    null,
                    false,
                    [],
                    [],
                    [],
                    false,
                    null,
                    MessageType.Default,
                    null,
                    null,
                    null,
                    false
                )),
                true
            ));
        }
    }

    partial void OnSelectedGuildChanged(GuildModel? oldValue, GuildModel? newValue) {
        if (newValue is null) {
            return;
        }

        var guild = newValue;

        LoadChannels(guild.Id);
    }

    partial void OnSelectedChannelChanged(ChannelModel? oldValue, ChannelModel? newValue) {
        if (newValue is null) {
            return;
        }

        var channel = newValue;

        LoadMembers(channel.Id);
        LoadMessages(channel.Id);
    }

    public void SelectGuild(GuildModel? guild) {
        if (guild is null) {
            return;
        }

        if (SelectedGuild?.Id == guild.Id) {
            return;
        }

        SelectedGuild = guild;
    }

    public void SelectChannel(ChannelModel? channel) {
        switch (channel)
        {
            // Handle text channel
            case TextChannelModel:
            {
                if (SelectedChannel?.Id == channel.Id) {
                    return;
                }

                SelectedChannel = channel;
                break;
            }
            case CategoryChannelModel categoryChannel:
            {
                categoryChannel.IsHidden = !categoryChannel.IsHidden;

                // Hide or show the channels in the category
                foreach (var guildChannel in GuildChannels) {
                    switch (guildChannel) {
                        case AnnouncementChannelModel announcementChannel when announcementChannel.ParentId == categoryChannel.Id:
                            announcementChannel.IsHidden = categoryChannel.IsHidden;
                            break;
                        case TextChannelModel textChannel when textChannel.ParentId == categoryChannel.Id:
                            textChannel.IsHidden = categoryChannel.IsHidden;
                            break;
                        case VoiceChannelModel voiceChannel when voiceChannel.ParentId == categoryChannel.Id:
                            voiceChannel.IsHidden = categoryChannel.IsHidden;
                            break;
                        case VoiceChannelMemberModel voiceChannelMember when voiceChannelMember.ChannelParentId == categoryChannel.Id:
                            voiceChannelMember.IsHidden = categoryChannel.IsHidden;
                            break;
                    }
                }

                break;
            }
        }

        // TODO: Handle other channel logic like voice
    }
}