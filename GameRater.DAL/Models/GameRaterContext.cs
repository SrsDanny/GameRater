using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GameRater.DAL.Models
{
    public class GameRaterContext : IdentityDbContext<ApplicationUser>
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
