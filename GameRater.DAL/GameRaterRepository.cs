using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using GameRater.DAL.Exceptions;
using GameRater.DAL.Models;
using GameRater.DAL.Paging;

namespace GameRater.DAL
{
    public class GameRaterRepository : IDisposable
    {
        private GameRaterContext _db;

        public GameRaterRepository(GameRaterContext gameRaterContext)
        {
            _db = gameRaterContext;
        }

        public async Task AddGame(Game game)
        {
            _db.Games.Add(game);
            await _db.SaveChangesAsync();
        }

        public async Task AddReview(Review review)
        {
            var game = _db.Games.Find(review.GameId);
            if (game == null)
            {
                throw new EntityNotFoundException("Game not found for Review entity");
            }

            _db.Reviews.Add(review);
            await UpdateScoresForGame(game);
            await _db.SaveChangesAsync();
        }

        public async Task<Game> GetGameById(int id, bool loadReviews = false)
        {
            var game = await _db.Games.FindAsync(id);
            if (game != null && loadReviews)
            {
                await _db.Entry(game).Collection(g => g.Reviews).Query()
                    .Include(r => r.User).LoadAsync();
            }
            return game;
        }

        public async Task<Review> GetReviewById(int id)
        {
            var review = await _db.Reviews.FindAsync(id);
            if (review != null)
            {
                await _db.Entry(review).Reference(r => r.Game).LoadAsync();
                await _db.Entry(review).Reference(r => r.User).LoadAsync();
            }
            return review;
        }

        public async Task DeleteReviewById(int id)
        {
            var review = await _db.Reviews.FindAsync(id);
            if(review == null) return;

            _db.Reviews.Remove(review);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteGameById(int id)
        {
            var game = await _db.Games.FindAsync(id);
            if(game == null) return;

            await _db.Entry(game).Collection(g => g.Reviews).LoadAsync();
            _db.Reviews.RemoveRange(game.Reviews);
            _db.Games.Remove(game);

            await _db.SaveChangesAsync();
        }

        private async Task UpdateScoresForGame(Game game)
        {
            await _db.Entry(game).Collection(g => g.Reviews).LoadAsync();
            double totalScore = game.Reviews.Sum(r => r.Score);
            if (game.Reviews.Count != 0)
            {
                game.ReviewScore = totalScore / game.Reviews.Count;
            }
            else
            {
                game.ReviewScore = 0;
            }
        }

        public void Dispose()
        {
            _db?.Dispose();
        }

        public PagedQueryable<Game> GetGamesPaged(int pageSize, SortGamesOptions sortGamesOptions)
        {
            IQueryable<Game> games = _db.Games;
            switch (sortGamesOptions.SortBy)
            {
                case SortBy.Title:
                    games = sortGamesOptions.Ascending ? games.OrderBy(g => g.Title) : games.OrderByDescending(g => g.Title);
                    break;
                case SortBy.Score:
                    games = sortGamesOptions.Ascending ? games.OrderBy(g => g.ReviewScore) : games.OrderByDescending(g => g.ReviewScore);
                    break;
            }

            return games.PageBy(pageSize);
        }
    }
}
