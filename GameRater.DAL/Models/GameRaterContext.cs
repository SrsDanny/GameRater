using System.Data.Entity;

namespace GameRater.DAL.Models
{
    public class GameRaterContext : DbContext, IGameRaterContext
    {
        public GameRaterContext() : base("GameRaterDb")
        {
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}
