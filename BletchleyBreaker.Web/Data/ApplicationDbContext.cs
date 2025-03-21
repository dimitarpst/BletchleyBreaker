using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BletchleyBreaker.Web.Models;

namespace BletchleyBreaker.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<GameSession> GameSessions { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Guess> Guesses { get; set; }
    }
}
