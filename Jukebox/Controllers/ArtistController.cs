using System.Web.Mvc;
using Jukebox.Data.Repositories;
using Ninject;
using Northwoods.Data.NHibernate;

namespace Jukebox.Controllers
{
    public class ArtistController : Controller
    {
        [Inject] public UnitOfWorkFactory UnitOfWorkFactory { get; set; }
        [Inject] public ArtistRepository ArtistRepository { get; set; }

        public ActionResult Albums(int id)
        {
            using (UnitOfWorkFactory.StartUnitOfWork<Data.Config.Jukebox>())
            {
                return Json(ArtistRepository.AlbumsFor(id), JsonRequestBehavior.AllowGet);
            }
        }
	}
}