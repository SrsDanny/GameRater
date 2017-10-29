using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRater.DAL.Models
{
    public interface IGameRaterContext : IDisposable
    {
        DbSet<Game> Games { get; set; }
        DbSet<Review> Reviews { get; set; }
    }
}
