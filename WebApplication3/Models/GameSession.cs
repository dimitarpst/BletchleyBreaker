namespace WebApplication3.Models
{
    public class GameSession
    {
        public int GameSessionId { get; set; }
        public int Player1Id { get; set; }
        public int Player2Id { get; set; }
        public int[] TargetCoordinates { get; set; } // Stores the target coordinates
        public List<Guess> Guesses { get; set; } // List of guesses made during the game
        public int CurrentPlayerId { get; set; } // ID of the player who is currently guessing
        public bool IsGameOver { get; set; } // Flag to track if the game is over
        public int AttemptsLeft { get; set; } // The number of attempts left

        public GameSession()
        {
            Guesses = new List<Guess>();
        }
    }

}
