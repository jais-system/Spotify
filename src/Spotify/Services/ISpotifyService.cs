namespace Spotify.Services;

public interface ISpotifyService
{
    public Task<string> GetDisplayNameAsync();
}