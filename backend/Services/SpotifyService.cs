using SpotifyAPI.Web;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Music_Game.Services
{
    public class SpotifyService
    {
        private readonly SpotifyClient _spotifyClient;
        private readonly ILogger<SpotifyService> _logger;

        public SpotifyService(IConfiguration configuration, ILogger<SpotifyService> logger)
        {
            _logger = logger;

            var clientId = configuration["Spotify:ClientId"];
            var clientSecret = configuration["Spotify:ClientSecret"];

            if (string.IsNullOrEmpty(clientId) || string.IsNullOrEmpty(clientSecret))
            {
                throw new ArgumentNullException("Spotify client ID or secret is missing.");
            }

            var config = SpotifyClientConfig
                .CreateDefault()
                .WithAuthenticator(new ClientCredentialsAuthenticator(clientId, clientSecret));

            _spotifyClient = new SpotifyClient(config);
        }

        public async Task<FullTrack> GetTrackAsync(string trackId)
        {
            try
            {
                _logger.LogInformation($"Fetching track with ID: {trackId}");
                return await _spotifyClient.Tracks.Get(trackId);
            }
            catch (APIException ex)
            {
                _logger.LogError(ex, "Spotify API error");
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred");
                throw;
            }
        }
    }
}
