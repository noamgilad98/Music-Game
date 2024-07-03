namespace Music_Game.Models
{
    public class PlayerTurnRequest
    {
        public Game Game { get; set; } = new Game();
        public Player Player { get; set; } = new Player();
        public Card Card { get; set; } = new Card();
    }
}
