using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using GameRater.DAL;
using GameRater.DAL.Models;
using GameRater.DAL.Paging;
using GameRater.Helpers;
using GameRater.Models;
using GameRater.Models.Games;
using Microsoft.AspNet.Identity;

namespace GameRater.Controllers
{
    public class GamesController : Controller
    {
        private const int DefaultPageSize = 10;
        private readonly GameRaterRepository _repository;
        private readonly ApplicationUserManager _userManager;

        public GamesController(GameRaterRepository repository, ApplicationUserManager userManager)
        {
            _repository = repository;
            _userManager = userManager;
        }

        // GET: Game
        public async Task<ActionResult> Index(int? page, string sortBy, string sortOrder)
        {
            var currentPage = page ?? 1;
            var sortOptions = new SortGamesOptions(sortBy, sortOrder);

            var pagedGames = _repository.GetGamesPaged(DefaultPageSize, sortOptions);
            var games = await pagedGames.GetPage(currentPage).ToListAsync();
            var pageCount = await pagedGames.GetPageCountAsync();
            var pagingViewModel = new PagingViewModel(pageCount, currentPage, p => Url.Action("Index", new {page = p, sortBy, sortOrder}));
            var isAdmin = User != null && User.IsInRole("Admin");

            var model = new ListGamesViewModel(games,
                pagingViewModel,
                sortOptions,
                isAdmin);
            return View(model);
        }

        // GET: Game/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var game = await _repository.GetGameById(id, true);
            if (game == null) return HttpNotFound();

            var username = "Anonymous";
            if (User.Identity.GetUserId() != null)
            {
                var user = await _userManager.FindByIdAsync(User.Identity.GetUserId());
                username = user.UserName;
            }
            var model = new GameDetailsViewModel(game, username);

            return View(model);
        }

        // GET: Game/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Game/Create
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Create(CreateGameViewModel model)
        {
            if (!ModelState.IsValid) return View();

            Bitmap image;
            try
            {
                image = new Bitmap(model.CoverImage.InputStream);
            }
            catch (ArgumentException)
            {
                ModelState.AddModelError("CoverImage", "Invalid image file uploaded!");
                return View();
            }
            
            var coverImagesPath = Server.MapPath("/Content/cover-images/");
            var imageName = FileNameCleaner.GameNameToFileName(model.Title) + ".jpg";
            var imagePath = Path.Combine(coverImagesPath, imageName);
            image.Save(imagePath);

            var game = new Game
            {
                Summary = model.Summary,
                Title = model.Title,
                ImageUrl = $"/Content/cover-images/{imageName}"
            };

            await _repository.AddGame(game);

            return RedirectToAction("Details", new {id = game.Id});
        }

        // GET: Game/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Edit(int id)
        {
            var game = await _repository.GetGameById(id);
            if (game == null) return HttpNotFound();
            return View(game);
        }

        // POST: Game/Edit/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Game/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(int id)
        {
            var game = await _repository.GetGameById(id);
            if (game == null) return HttpNotFound();
            return View(game);
        }

        // POST: Game/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeletePost(int id)
        {
            var game = await _repository.GetGameById(id);
            if (game == null) return HttpNotFound();

            var imagePath = Server.MapPath(game.ImageUrl);
            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }

            await _repository.DeleteGameById(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repository?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
