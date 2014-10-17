using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jukebox.Models;

namespace Jukebox.Controllers
{
    public class ArtistController : Controller
    {
        public ActionResult Albums(int id)
        {
            var albums = new List<Album>
            {
                new Album() {AlbumName = "Weeee Die Young", ArtistId = 1},
                new Album() {AlbumName = "Jar of Flies", ArtistId = 1},
                new Album() {AlbumName = "Face LIFT", ArtistId = 1},
            };
            return View(albums);
        }
	}
}