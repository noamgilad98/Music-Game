using SpotifyAPI.Web;
using Music_Game.Models; // Ensure this matches your namespace
using System;
using System.Threading.Tasks;

namespace Music_Game.Services
{
    public class SpotifyService
    {
        private readonly SpotifyClient _spotifyClient;

        public SpotifyService(IConfiguration configuration)
        {
            var clientId = configuration["Spotify:ClientId"];
            var clientSecret = configuration["Spotify:ClientSecret"];

            if (clientId == null || clientSecret == null)
            {
                throw new ArgumentNullException("Spotify client ID or secret is missing.");
            }

            var authenticator = new ClientCredentialsAuthenticator(clientId, clientSecret);
            var config = SpotifyClientConfig.CreateDefault().WithAuthenticator(authenticator);

            _spotifyClient = new SpotifyClient(config);
        }

        public async Task<FullTrack> GetTrackAsync(string trackId)
        {
            return await _spotifyClient.Tracks.Get(trackId);
        }
    }
}
