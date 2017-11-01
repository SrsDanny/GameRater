using System.Data.Entity;

namespace GameRater.DAL.Models
{
    public class GameRaterContext : DbContext
    {
        public GameRaterContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
        }

        public GameRaterContext() : base("GameRaterDb")
        {
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}
