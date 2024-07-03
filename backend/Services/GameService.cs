using Music_Game.Models;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Music_Game.Services
{
    public class GameService
    {
        private readonly DataContext _context;
        private readonly SpotifyService _spotifyService;
        private readonly ILogger<GameService> _logger;

        // List of known track IDs with preview URLs
        private readonly string[] _trackIds = new[]
        {
            "3n3Ppam7vgaVa1iaRUc9Lp", // Mr. Brightside
            "11dFghVXANMlKmJXsNCbNl", // Example track ID
            "6rqhFgbbKwnb9MLmUQDhG6", // Example track ID
            "7ouMYWpwJ422jRcDASZB7P"  // Example track ID
            // Add more known track IDs here
        };

        public GameService(DataContext context, SpotifyService spotifyService, ILogger<GameService> logger)
        {
            _context = context;
            _spotifyService = spotifyService;
            _logger = logger;
        }

        public async Task<Game> StartGameAsync()
        {
            var game = new Game();
            _context.Games.Add(game);
            await _context.SaveChangesAsync();
            return game;
        }

        public async Task PlayerTurnAsync(Game game, Player player, Card card)
        {
            player.Hand.Add(card);
            game.CurrentPlayerIndex = (game.CurrentPlayerIndex + 1) % game.Players.Count;
            _context.Games.Update(game);
            await _context.SaveChangesAsync();
        }

        public bool ValidatePlacement(Game game, Card card, DateTime placementDate)
        {
            return card.ReleaseDate == placementDate;
        }

        public async Task<string> GetRandomSongUrlAsync()
        {
            foreach (var trackId in _trackIds)
            {
                try
                {
                    _logger.LogInformation($"Attempting to fetch track with ID: {trackId}");
                    var track = await _spotifyService.GetTrackAsync(trackId);
                    if (!string.IsNullOrEmpty(track.PreviewUrl))
                    {
                        _logger.LogInformation($"Fetched track: {track.Name} with preview URL: {track.PreviewUrl}");
                        return track.PreviewUrl;
                    }
                    else
                    {
                        _logger.LogWarning($"Track preview URL is empty for track: {track.Name}");
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"An error occurred while fetching the track with ID: {trackId}");
                }
            }

            _logger.LogWarning("No valid track preview URLs found.");
            return null;
        }
    }
}
