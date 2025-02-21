namespace BetchleyBreaker.Models
{
    public class Game
    {
        public int[] SecretCode { get; set; }
        public int Attempts { get; set; }
        public List<Guess> Guesses { get; set; }

        public Game()
        {
            SecretCode = GenerateRandomCode();
            Attempts = 0;
            Guesses = new List<Guess>();
        }

        // Метод за генериране на случайна комбинация от 4 числа между 0 и 7
        private int[] GenerateRandomCode()
        {
            Random rand = new Random();
            return new int[4] { rand.Next(0, 8), rand.Next(0, 8), rand.Next(0, 8), rand.Next(0, 8) };
        }

        public Guess MakeGuess(int[] guess)
        {
            Attempts++;
            int correctNumbers = 0;
            int correctPositions = 0;

            for (int i = 0; i < guess.Length; i++)
            {
                if (guess[i] == SecretCode[i])
                {
                    correctPositions++;
                }
                else if (SecretCode.Contains(guess[i]))
                {
                    correctNumbers++;
                }
            }

            Guess newGuess = new Guess
            {
                Attempt = Attempts,
                GuessCode = guess,
                CorrectNumbers = correctNumbers,
                CorrectPositions = correctPositions
            };

            Guesses.Add(newGuess);

            return newGuess;
        }

        public bool IsGameWon()
        {
            return Guesses.Any(g => g.CorrectPositions == 4);
        }
    }

}
