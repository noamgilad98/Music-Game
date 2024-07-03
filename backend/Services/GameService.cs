using Music_Game.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
            var tracks = await _spotifyService.GetTrackAsync("track_id");
            return tracks.PreviewUrl; // Adjust as necessary
        }
    }
}
