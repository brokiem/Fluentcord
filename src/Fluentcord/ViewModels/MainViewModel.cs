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

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty] private AvaloniaList<GuildModel> _guilds = [];
    [ObservableProperty] private AvaloniaList<ChannelModel> _guildChannels = [];
    [ObservableProperty] private AvaloniaList<MessageModel> _messages = [];
    [ObservableProperty] private AvaloniaList<MemberModel> _members = [];

    [ObservableProperty] private GuildModel? _selectedGuild;
    [ObservableProperty] private ChannelModel? _selectedChannel;

    [ObservableProperty] private ListBoxItem? _selectedGuildListBoxItem;
    [ObservableProperty] private ListBoxItem? _selectedChannelListBoxItem;

    private readonly Random _random = new();
    private readonly IdGenerator _idGenerator = new(0);
    private readonly Faker _faker = new();

    public MainViewModel()
    {
        LoadMockData();
    }

    private ulong CreateId()
    {
        return (ulong)_idGenerator.CreateId();
    }

    private void LoadMockData()
    {
        Dispatcher.UIThread.Post(() =>
        {
            Guilds.Clear();
            GuildChannels.Clear();
            Messages.Clear();

            for (var i = 1; i <= _random.Next(30, 100); i++)
            {
                var guildId = CreateId();
                Guilds.Add(new GuildModel(guildId, $"The guild({i})",
                    _random.Next(-2, 3) > 0
                        ? $"https://cdn.discordapp.com/embed/avatars/{_random.Next(1, 5)}.png"
                        : null));

                for (var j = 1; j <= _random.Next(15, 50); j++)
                {
                    var categoryId = CreateId();
                    GuildChannels.Add(new CategoryChannelModel(categoryId, "Text Channels", [], j, guildId));

                    for (var k = 1; k <= _random.Next(5, 15); k++)
                    {
                        var channelId = CreateId();
                        GuildChannels.Add(new TextChannelModel(channelId, guildId, $"{channelId}", j + k, [], 0, false,
                            "This is the channel topic", null, categoryId));

                        for (var l = 1; l <= _random.Next(10, 50); l++)
                        {
                            var messageId = CreateId();
                            var authorId = CreateId();
                            Messages.Add(new MessageModel(
                                messageId: messageId,
                                channelId: channelId,
                                author: new UserModel(
                                    id: authorId,
                                    username: $"{_faker.Name.FirstName()} {_faker.Name.LastName()}",
                                    discriminator: 0,
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
                                content: _faker.Rant.Review("Discord"),
                                isEdited: false,
                                createdAt: DateTimeOffset.Now,
                                editedAt: null,
                                mentionEveryone: false,
                                mentions: [],
                                attachments:
                                [
                                    new ImageAttachmentModel(1, "Attachment name", null, "image/png", 500,
                                        "https://picsum.photos/536/354",
                                        "https://picsum.photos/536/354",
                                        false, null, 354, 536)
                                ],
                                embeds: [],
                                pinned: false,
                                webhookId: null,
                                messageType: MessageType.Default,
                                applicationId: null,
                                flags: null,
                                messageReference: new MessageReferenceModel(new MessageModel(
                                    messageId: messageId,
                                    channelId: channelId,
                                    author: new UserModel(
                                        id: authorId,
                                        username: $"{_faker.Name.FirstName()} {_faker.Name.LastName()}",
                                        discriminator: 0,
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
                                    content: _faker.Rant.Review("Discord"),
                                    isEdited: false,
                                    createdAt: DateTimeOffset.Now,
                                    editedAt: null,
                                    mentionEveryone: false,
                                    mentions: [],
                                    attachments: [],
                                    embeds: [],
                                    pinned: false,
                                    webhookId: null,
                                    messageType: MessageType.Default,
                                    applicationId: null,
                                    flags: null,
                                    messageReference: null,
                                    isReply: false
                                )),
                                isReply: true
                            ));
                        }
                    }

                    var voiceId = CreateId();
                    GuildChannels.Add(new VoiceChannelModel(voiceId, null, "Voice channel", -1, categoryId, null, null,
                        null, guildId, [], 0, false));
                }
            }
        });
    }

    private void LoadMembers()
    {
        Members.Clear();

        Dispatcher.UIThread.Post(() =>
        {
            for (ulong i = 1; i <= 10; i++)
            {
                Members.Add(new MembersGroupModel
                {
                    Name = _faker.Company.CompanyName(),
                    OnlineCount = 5
                });

                for (int j = 0; j < 5; j++)
                {
                    Members.Add(new MemberUserModel
                    {
                        Name = _faker.Internet.UserName(),
                        AvatarUrl = "https://ia800305.us.archive.org/31/items/discordprofilepictures/discordred.png"
                    });
                }
            }
        }, DispatcherPriority.Background);
    }

    partial void OnSelectedGuildChanged(GuildModel? oldValue, GuildModel? newValue)
    {
    }

    partial void OnSelectedChannelChanged(ChannelModel? oldValue, ChannelModel? newValue)
    {
        LoadMembers();
    }

    public void SelectGuild(GuildModel? guild)
    {
        if (guild is null) return;
        if (SelectedGuild?.Id == guild.Id) return;

        SelectedGuild = guild;
    }

    public void SelectChannel(ChannelModel? channel)
    {
        // Handle text channel
        if (channel is TextChannelModel)
        {
            if (SelectedChannel?.Id == channel.Id) return;

            SelectedChannel = channel;
        }

        // TODO: Handle other channel logic like category and voice
    }
}