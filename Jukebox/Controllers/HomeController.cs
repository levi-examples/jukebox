using System.Web.Mvc;
using Jukebox.Data.Repositories;
using Ninject;
using Northwoods.Data.NHibernate;

namespace Jukebox.Controllers
{
    public class HomeController : Controller
    {
        [Inject] public UnitOfWorkFactory UnitOfWorkFactory { get; set; }
        [Inject] public ArtistRepository Repository { get; set; }

        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Artists()
        {
            using (UnitOfWorkFactory.StartUnitOfWork<Data.Config.Jukebox>())
            {
                return Json(Repository.All(), JsonRequestBehavior.AllowGet);
            }
        }
	}
}