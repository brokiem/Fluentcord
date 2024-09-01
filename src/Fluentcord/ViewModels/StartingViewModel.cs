using System;
using System.Timers;
using CommunityToolkit.Mvvm.ComponentModel;
using Fluentcord.Services;

namespace Fluentcord.ViewModels;

public partial class StartingViewModel : ViewModelBase
{
    private readonly Timer _timer;

    private readonly string[] _loadingMessages =
    [
        "Warming up the servers... Shouldn't be long now",
        "Warming up the client... Shouldn't be long now",
        "Good vibes are on the way... Just a few more seconds",
        "Time flies when you’re waiting for something awesome",
        "Hold tight! We’re aligning the stars for you",
        "Loading your personalized experience... Just a bit more",
        "Our code monkeys are working hard on this",
        "Hang on! We’re untangling the digital spaghetti",
        "Loading... We promise it’s worth the wait",
        "Your patience is legendary. Thanks for sticking around",
        "We’re adding the final sprinkles to your digital cupcake",
        "Just a few more seconds and we'll be in full swing",
        "Fetching the awesomeness... Please hold the line",
        "Cooking up something special... Almost ready to serve",
        "Just a sec! We’re putting the pieces together",
        "Your experience is being fine-tuned to perfection",
        "Prepping your custom experience...",
        "Syncing the stars, just for you...",
        "Almost ready, setting the stage...",
        "Gathering all the right vibes...",
        "Hold tight, bringing everything together...",
        "Making sure everything’s perfect...",
        "Loading... greatness takes a moment...",
        "Stay with us, good things are coming...",
        "Finalizing the details...",
        "We’re almost there, just a sec...",
        "Just a moment, assembling the awesomeness...",
        "Hang on, good things are worth the wait...",
        "Dotting the i’s and crossing the t’s...",
        "Almost there... perfecting the final touches...",
        "Loading your personalized experience...",
        "Just making sure everything’s in order...",
        "Bringing your content to life...",
        "Hold tight, magic is happening...",
        "Loading... patience is a virtue...",
        "Hang tight, the best is yet to come...",
        "Prepping something special for you...",
        "We’re almost there, hang tight...",
        "Loading... your experience matters...",
        "Putting the pieces together...",
        "Loading... good things are on the way...",
        "Just a moment, crafting the perfect experience...",
        "Loading... because quality takes time...",
        "We’re on it! Just a few more seconds...",
        "Fine-tuning your experience...",
        "Loading... making sure everything’s just right..."
    ];

    [ObservableProperty] private string? _loadingMessage;

    public StartingViewModel()
    {
    }

    public StartingViewModel(INavigationService navigationService)
    {
        LoadingMessage = GetRandomLoadingMessage();

        _timer = new Timer(1000);
        _timer.Elapsed += (_, _) => { LoadingMessage = GetRandomLoadingMessage(); };
        _timer.AutoReset = true;
        _timer.Enabled = true;
        
        // TODO: Just for early phase using timer to navigate to main model instead of real loading
        var navigationTimer = new Timer(3000);
        navigationTimer.Elapsed += (_, _) => { navigationService.Navigate<MainViewModel>(); };
        navigationTimer.AutoReset = false;
        navigationTimer.Enabled = true;
    }

    private string GetRandomLoadingMessage()
    {
        var random = new Random();
        return _loadingMessages[random.Next(_loadingMessages.Length)];
    }
}