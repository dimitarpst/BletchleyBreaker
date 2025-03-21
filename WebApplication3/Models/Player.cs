namespace WebApplication3.Models
{
    public class Player
    {
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public bool IsComputer { get; set; } // True if the player is the computer, false if human
    }

}
