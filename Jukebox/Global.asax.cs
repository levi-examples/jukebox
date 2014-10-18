using System.IO;
using System.Web.Mvc;
using System.Web.Routing;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using Ninject;
using Northwoods.Data.NHibernate;
using Northwoods.Data.NHibernate.Config;

namespace Jukebox
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            InitializeDatabase(Server.MapPath("~/jukebox.db"));
        }

        private static void InitializeDatabase(string databasePath)
        {
            Data.Config.Jukebox.DatabaseFile = databasePath;
            if (File.Exists(Data.Config.Jukebox.DatabaseFile)) return;

            using (var kernel = new StandardKernel(new NhDataModule()))
            {
                Configuration config = null;
                kernel.Get<SessionFactoryContext>().Get<Data.Config.Jukebox>(x => config = x);

                using (kernel.Get<UnitOfWorkFactory>().StartUnitOfWork<Data.Config.Jukebox>())
                {
                    new SchemaExport(config).Execute(false, true, false, SessionDataContext.Get<Data.Config.Jukebox>().Connection, null);
                }
            }
        }
    }
}
