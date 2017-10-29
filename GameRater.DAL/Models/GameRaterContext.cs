using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRater.DAL.Models
{
    public class GameRaterContext : DbContext, IGameRaterContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}
