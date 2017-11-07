using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using GameRater.Helpers;

namespace GameRater.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Banner()
        {
            var imageStream = await Task.Run(() => BannerCollageGenerator.CreateBanner(Server.MapPath("/Content/cover-images/")));
            return new FileStreamResult(imageStream, "image/jpeg");
        }
    }
}