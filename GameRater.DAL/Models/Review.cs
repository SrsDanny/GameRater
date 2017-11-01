using System.ComponentModel.DataAnnotations.Schema;

namespace GameRater.DAL.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int Score { get; set; }

        [ForeignKey("Game")]
        public int GameId { get; set; }
        public Game Game { get; set; }

        public string UserId { get; set; }
    }
}
