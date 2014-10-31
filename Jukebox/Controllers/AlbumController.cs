using System.Web.Mvc;
using Jukebox.Data.Repositories;
using Ninject;
using Northwoods.Data.NHibernate;

namespace Jukebox.Controllers
{
    public class AlbumController : Controller
    {
        [Inject] public UnitOfWorkFactory UnitOfWorkFactory { get; set; }
        [Inject] public AlbumRepository AlbumRepository { get; set; }

        public ActionResult Titles(int id)
        {
            using (UnitOfWorkFactory.StartUnitOfWork<Data.Config.Jukebox>())
            {
                return Json(AlbumRepository.TitlesFor(id), JsonRequestBehavior.AllowGet);
            }
        }
    }
}