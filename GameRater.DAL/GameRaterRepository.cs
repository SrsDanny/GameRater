using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameRater.DAL.Exceptions;
using GameRater.DAL.Models;

namespace GameRater.DAL
{
    public class GameRaterRepository : IDisposable
    {
        private IGameRaterContext _db;

        public GameRaterRepository(IGameRaterContext gameRaterContext)
        {
            _db = gameRaterContext;
        }

        public void AddGame(Game game)
        {
            _db.Games.Add(game);
        }

        public void AddReview(Review review)
        {
            var game = _db.Games.Find(review.GameId);
            if (game == null)
            {
                throw new EntityNotFoundException("Game not found for review entity");
            }
            game.ReviewScore += review.Score;
            _db.Reviews.Add(review);
        }

        public Game GetGameById(int id)
        {
            return _db.Games.Find(id);
        }

        public Review GetReviewById(int id)
        {
            return _db.Reviews.Find(id);
        }

        public void Dispose()
        {
            if (_db != null)
            {
                _db.Dispose();
                _db = null;
            }
        }
    }
}
