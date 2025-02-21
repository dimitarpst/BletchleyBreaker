namespace BetchleyBreaker.Models
{
    public class Guess
    {
        public int Attempt { get; set; }
        public int[] GuessCode { get; set; }
        public int CorrectNumbers { get; set; }
        public int CorrectPositions { get; set; }
    }

}
