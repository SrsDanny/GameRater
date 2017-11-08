using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GameRater.DAL;
using GameRater.DAL.Models;

namespace GameRater.Models.Games
{
    public class ListGamesViewModel
    {
        public List<Game> Games { get; set; }
        public PagingViewModel Paging { get; set; }
        public SortGamesOptions SortGamesOptions { get; set; }
        public bool IsAdmin { get; set; }

        public ListGamesViewModel(List<Game> games, PagingViewModel paging, SortGamesOptions sortGamesOptions, bool displayEditAndDelete)
        {
            Paging = paging;
            Games = games;
            SortGamesOptions = sortGamesOptions;
            IsAdmin = displayEditAndDelete;
        }
    }
}