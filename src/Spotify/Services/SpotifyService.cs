using SpotifyAPI.Web;

namespace Spotify.Services;

public class SpotifyService : ISpotifyService
{
    private readonly ITokenService _tokenService;
    private SpotifyClient? _client;
    
    public string DisplayName { get; set; }

    public SpotifyService(ITokenService tokenService)
    {
        _tokenService = tokenService;

        _tokenService.AccessToken.Subscribe(x =>
        {
            _client = !string.IsNullOrEmpty(x) ? new SpotifyClient(x) : null;


        });
    }

    public async Task<string> GetDisplayNameAsync()
    {
        var userProfile = await _client.UserProfile.Current();
        return userProfile.DisplayName;
    }
}