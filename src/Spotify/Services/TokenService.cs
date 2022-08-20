using System.Reactive.Linq;
using System.Reactive.Subjects;
using ReactiveUI;
using SpotifyAPI.Web;

namespace Spotify.Services;

public class TokenService : ITokenService
{
    public ReplaySubject<string?> AccessTokenSubject = new ReplaySubject<string?>(1);
    public IObservable<string?> AccessToken => AccessTokenSubject.AsObservable();

    public TokenService()
    {
        var config = SpotifyClientConfig.CreateDefault();
        var request =
            new PKCETokenRefreshRequest(string.Empty, string.Empty); // todo
        var response = new OAuthClient(config).RequestToken(request);
        var accessToken = response.Result.AccessToken;
        AccessTokenSubject.OnNext(accessToken);
    }
}