using Music_Game.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace Music_Game.Services
{
    public class GameService
    {
        private readonly DataContext _context;
        private readonly SpotifyService _spotifyService;

        public GameService(DataContext context, SpotifyService spotifyService)
        {
            _context = context;
            _spotifyService = spotifyService;
        }

        public async Task<Game> StartGameAsync()
        {
            var game = new Game();

            // Initialize deck with cards from Spotify
            var trackIds = new List<string> { "3n3Ppam7vgaVa1iaRUc9Lp", "2TpxZ7JUBn3uw46aR7qd6V" }; // Valid track IDs
            foreach (var trackId in trackIds)
            {
                var track = await _spotifyService.GetTrackAsync(trackId);
                var card = new Card
                {
                    SongId = track.Id,
                    SongName = track.Name,
                    Artist = string.Join(", ", track.Artists.Select(a => a.Name)),
                    ReleaseDate = DateTime.Parse(track.Album.ReleaseDate)
                };
                game.Deck.Add(card);
            }

            _context.Games.Add(game);
            await _context.SaveChangesAsync();

            return game;
        }

        public async Task PlayerTurnAsync(Game game, Player player, Card card)
        {
            // Update card details from Spotify
            var track = await _spotifyService.GetTrackAsync(card.SongId);
            card.SongName = track.Name;
            card.Artist = string.Join(", ", track.Artists.Select(a => a.Name));
            card.ReleaseDate = DateTime.Parse(track.Album.ReleaseDate);

            // Add the card to the player's hand
            player.Hand.Add(card);

            // Move to the next player
            game.CurrentPlayerIndex = (game.CurrentPlayerIndex + 1) % game.Players.Count;

            _context.Games.Update(game);
            await _context.SaveChangesAsync();
        }

        public bool ValidatePlacement(Game game, Card card, DateTime placementDate)
        {
            // Validate card placement on timeline
            return card.ReleaseDate == placementDate;
        }
    }
}
