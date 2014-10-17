using System.Collections.Generic;
using System.Web.Mvc;
using Jukebox.Models;

namespace Jukebox.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Artists()
        {
            var id = 0;
            var artists = new List<Artist>
            {
                new Artist {Id = ++id, Name = "10,000 Maniacs"},
                new Artist {Id = ++id, Name = "2Pac"},
                new Artist {Id = ++id, Name = "Incubus"},
                new Artist {Id = ++id, Name = "Tool"},
                new Artist {Id = ++id, Name = "Your Mom"},
                new Artist {Id = ++id, Name = "Ward's Mom"},
            };

            return Json(artists, JsonRequestBehavior.AllowGet);
        }
	}
}