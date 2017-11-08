using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GameRater.DAL.Models;

namespace GameRater.Models.Games
{
    public class GameDetailsViewModel
    {
        public GameDetailsViewModel(Game game, string username)
        {
            Game = game;
            Username = username;
        }

        public Game Game { get; set; }
        public string Username { get; set; }
    }
}