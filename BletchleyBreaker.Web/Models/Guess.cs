namespace BletchleyBreaker.Web.Models
{
    public class Guess
    {
        public int GuessId { get; set; }
        public int GameSessionId { get; set; }
        public int PlayerId { get; set; } // The ID of the player who made the guess
        public int[] GuessedCoordinates { get; set; } // The coordinates guessed by the player
        public int CorrectNumbers { get; set; } // How many numbers are correct (but not in the correct position)
        public int CorrectPositions { get; set; } // How many numbers are correct and in the correct position

        public Guess()
        {
            GuessedCoordinates = new int[4];
        }
    }

}
