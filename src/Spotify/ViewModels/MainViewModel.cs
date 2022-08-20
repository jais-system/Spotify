using System.Reactive;
using System.Reactive.Linq;
using ReactiveUI;
using Spotify.Services;
using SpotifyAPI.Web;

namespace Spotify.ViewModels;

public class MainViewModel : ReactiveObject
{
    private SpotifyClient? _client;

    private readonly ObservableAsPropertyHelper<string> _displayName;
    public string DisplayName => _displayName.Value;

    
    public MainViewModel(ITokenService tokenService)
    {
        GetDisplayNameCommand = ReactiveCommand.CreateFromTask<Unit, string>(async _ => await GetDisplayNameAsync());
        _displayName = GetDisplayNameCommand.ToProperty(
            this, nameof(DisplayName));
        tokenService.AccessToken.Subscribe(x =>
        {
            _client = string.IsNullOrEmpty(x) ? null : new SpotifyClient(x);
            GetDisplayNameCommand.Execute();
        });
    }

    private ReactiveCommand<Unit, string> GetDisplayNameCommand { get; }

    private async Task<string> GetDisplayNameAsync()
    {
        if (_client == null)
        {
            return string.Empty;
        }
       
        var current =  await _client.UserProfile.Current();
        var displayName =  current.DisplayName;
        return displayName;
    }
}