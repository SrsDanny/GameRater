using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GameRater.DAL;
using GameRater.DAL.Exceptions;
using GameRater.DAL.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shouldly;
using System.Transactions;


namespace GameRater.Tests.DAL
{
    [TestClass]
    public class RepositoryTest
    {
        private GameRaterRepository repository;

        #region Test data

        private static Game CreateTestGame()
        {
            return new Game
            {
                Title = "Bioshock",
                Summary = "FPS set in an underwater city."
            };
        }

        private static Review CreateTestReview(int gameId, int? score = null)
        {
            return new Review
            {
                GameId = gameId,
                Content = "Great game!",
                Score = score ?? 4
            };
        }

        #endregion

        #region Set up & teardown

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            var dir = Directory.GetCurrentDirectory();
            AppDomain.CurrentDomain.SetData("DataDirectory", dir);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            Database.Delete("GameRaterDb");
        }

        [TestInitialize]
        public void SetUp()
        {
            var ctx = new GameRaterContext();
            repository = new GameRaterRepository(ctx);
            ctx.Database.BeginTransaction();
        }


        [TestCleanup]
        public void TearDown()
        {
            repository.Dispose();
        }

        #endregion

        [TestMethod]
        public async Task CanAddGame()
        {
            var testGame = CreateTestGame();
            await repository.AddGame(testGame);
            var game = await repository.GetGameById(testGame.Id);

            game.ShouldNotBeNull();
            game.Id.ShouldBe(testGame.Id);
        }

        [TestMethod]
        public async Task CanAddReview()
        {
            var testGame = CreateTestGame();
            await repository.AddGame(testGame);

            var testReview = CreateTestReview(testGame.Id);
            await repository.AddReview(testReview);
            var review = await repository.GetReviewById(testReview.Id);

            review.ShouldNotBeNull();
            review.Id.ShouldBe(testReview.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(EntityNotFoundException))]
        public async Task CantAddReviewWithoutGame()
        {
            var testReview = CreateTestReview(42);
            await repository.AddReview(testReview);
        }

        [TestMethod]
        public async Task CanAddMultipleReviews()
        {
            var testGame = CreateTestGame();
            await repository.AddGame(testGame);

            for (var i = 0; i < 10; i++)
            {
                var testReview = CreateTestReview(testGame.Id);
                await repository.AddReview(testReview);
            }

            var game = await repository.GetGameById(testGame.Id, true);
            game.Reviews.Count.ShouldBe(10);
        }

        [TestMethod]
        public async Task GameScoreUpdatesCorrectly()
        {
            var testGame = CreateTestGame();
            await repository.AddGame(testGame);

            var scores = new List<double>();
            for (var score = 1; score <= 5; score++)
            {
                var testReview = CreateTestReview(testGame.Id, score);
                await repository.AddReview(testReview);
                var game = await repository.GetGameById(testGame.Id);

                scores.Add(score);
                var expectedScore = scores.Average();
                game.ReviewScore.ShouldBe(expectedScore, 1e-10);
            }
        }
    }
}
