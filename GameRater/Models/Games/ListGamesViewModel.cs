using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GameRater.DAL.Models;

namespace GameRater.Models.Games
{
    public class ListGamesViewModel
    {
        public PagingViewModel Paging { get; set; }
        public List<Game> Games { get; set; }

        public ListGamesViewModel(List<Game> games, PagingViewModel paging)
        {
            Paging = paging;
            Games = games;
        }
    }
}