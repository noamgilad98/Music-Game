using System;

namespace Music_Game.Models
{
    public class Card
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string SongId { get; set; } = string.Empty;
        public string SongName { get; set; } = string.Empty;
        public string Artist { get; set; } = string.Empty;
        public DateTime ReleaseDate { get; set; }
        public string GameLogo { get; set; } = string.Empty;
    }
}
