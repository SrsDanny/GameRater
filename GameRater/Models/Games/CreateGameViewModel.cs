using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GameRater.Models.Games
{
    public class CreateGameViewModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Summary { get; set; }

        [Required]
        [Display(Name = "Cover image")]
        public HttpPostedFileBase CoverImage { get; set; }
    }
}