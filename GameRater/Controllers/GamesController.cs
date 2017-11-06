﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using GameRater.DAL;
using GameRater.Models;
using GameRater.Models.Games;

namespace GameRater.Controllers
{
    public class GamesController : Controller
    {
        private const int DefaultPageSize = 10;
        private readonly GameRaterRepository _repository;

        public GamesController(GameRaterRepository repository)
        {
            _repository = repository;
        }

        // GET: Game
        public async Task<ActionResult> Index(int? page, int? pageSize)
        {
            var currentPageSize = pageSize ?? DefaultPageSize;
            var currentPage = page ?? 1;

            var pagedGames = _repository.GetGamesPaged(currentPageSize);
            var games = await pagedGames.GetPage(currentPage).ToListAsync();
            var pageCount = await pagedGames.GetPageCountAsync();
            var model = new ListGamesViewModel(games,
                new PagingViewModel(pageCount, currentPage, p => Url.Action("Index", new {page = p})));
            return View(model);
        }

        // GET: Game/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var game = await _repository.GetGameById(id, true);
            if (game == null) return HttpNotFound();
            return View(game);
        }

        // GET: Game/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Game/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Game/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var game = await _repository.GetGameById(id, true);
            if (game == null) return HttpNotFound();
            return View(game);
        }

        // POST: Game/Edit/5
        [HttpPost]
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
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Game/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
