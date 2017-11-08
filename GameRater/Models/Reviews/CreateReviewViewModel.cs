using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GameRater.Models.Reviews
{
    public class CreateReviewViewModel
    {
        [Range(1, 5)]
        public int Score { get; set; }

        [MinLength(10)]
        public string Content { get; set; }
        public int GameId { get; set; }
    }
}