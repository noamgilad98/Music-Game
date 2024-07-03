using SpotifyAPI.Web;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Music_Game.Services
{
    public class SpotifyService
    {
        private readonly SpotifyClient _spotifyClient;

        public SpotifyService(IConfiguration configuration)
        {
            var clientId = configuration["Spotify:ClientId"] ?? throw new ArgumentNullException("Spotify:ClientId");
            var clientSecret = configuration["Spotify:ClientSecret"] ?? throw new ArgumentNullException("Spotify:ClientSecret");

            var config = SpotifyClientConfig.CreateDefault()
                .WithAuthenticator(new ClientCredentialsAuthenticator(clientId, clientSecret));

            _spotifyClient = new SpotifyClient(config);
        }

        public async Task<FullTrack> GetTrackAsync(string trackId)
        {
            return await _spotifyClient.Tracks.Get(trackId);
        }
    }
}
