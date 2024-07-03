using System;
using System.Collections.Generic;

namespace Music_Game.Models
{
    public class Game
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public List<Player> Players { get; set; } = new List<Player>();
        public List<Card> Deck { get; set; } = new List<Card>();
        public int CurrentPlayerIndex { get; set; } = 0;
        public List<Card> Timeline { get; set; } = new List<Card>();
    }
}
