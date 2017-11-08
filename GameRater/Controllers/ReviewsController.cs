using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using GameRater.DAL;
using GameRater.DAL.Models;
using GameRater.Models.Reviews;
using Microsoft.AspNet.Identity;

namespace GameRater.Controllers
{
    public class AuthorizeAjaxAttribute : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext context)
        {
            if (context.HttpContext.Request.IsAjaxRequest())
            {
                context.Result = new HttpStatusCodeResult(HttpStatusCode.Forbidden, "Actually a 401, please log in!");
            }
            else
            {
                base.HandleUnauthorizedRequest(context);
            }
        }
    }

    public class ReviewsController : Controller
    {
        private readonly GameRaterRepository _repository;
        private readonly ApplicationUserManager _userManager;

        public ReviewsController(GameRaterRepository repository, ApplicationUserManager userManager)
        {
            _repository = repository;
            _userManager = userManager;
        }

        // POST: Review/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateReviewViewModel model)
        {
            if (!ModelState.IsValid) return RedirectToAction("Details", "Games", new {id = model.GameId});
            
            var review = new Review
            {
                GameId = model.GameId,
                Score = model.Score,
                Content = model.Content,
                UserId = User.Identity.GetUserId()
            };
            await _repository.AddReview(review);

            return RedirectToAction("Details", "Games", new {id = model.GameId});
        }

        // POST: Review/Delete/5
        [HttpPost]
        [AuthorizeAjax]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int reviewId)
        {
            var review = await _repository.GetReviewById(reviewId);

            if (review.UserId != User.Identity.GetUserId() && !User.IsInRole("Admin"))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            await _repository.DeleteReviewById(reviewId);
            if (HttpContext.Request.IsAjaxRequest())
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            return RedirectToAction("Details", "Games", new {id = review.GameId});
        }
    }
}
