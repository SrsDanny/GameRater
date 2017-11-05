using System.Collections.Generic;

namespace GameRater.DAL.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public double ReviewScore { get; set; }
        public string ImageUrl { get; set; }

        public List<Review> Reviews { get; set; }
    }
}
