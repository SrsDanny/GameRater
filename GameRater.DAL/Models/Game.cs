using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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

        [NotMapped]
        public string ShortSummary
        {
            get
            {
                if (Summary.Length < 200) return Summary;
                return Summary.Substring(0, 200) + "...";
            }
        }
    }
}
