using System;
using System.Collections.Generic;

namespace Music_Game.Models
{
    public class Player
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public List<Card> Hand { get; set; } = new List<Card>();
    }
}
