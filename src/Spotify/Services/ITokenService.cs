using System.Reactive.Subjects;

namespace Spotify.Services;

public interface ITokenService
{
    IObservable<string?> AccessToken { get; }
}