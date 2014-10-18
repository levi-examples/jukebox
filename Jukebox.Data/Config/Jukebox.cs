using FluentNHibernate.Cfg;
using Jukebox.Data.Models.Mappings;
using NHibernate.Dialect;
using NHibernate.Driver;
using Northwoods.Data.NHibernate;

namespace Jukebox.Data.Config
{
    public class Jukebox : SessionConfiguration
    {
        private static string _databaseFile;

        public string Dialect
        {
            get { return typeof(SQLiteDialect).AssemblyQualifiedName; }
        }

        public string ConnectionDriver
        {
            get { return typeof(SQLite20Driver).AssemblyQualifiedName; }
        }

        public string ConnectionString
        {
            get { return string.Format("Data Source={0};Version=3;", DatabaseFile); }
        }

        public static string DatabaseFile
        {
            get { return _databaseFile ?? Properties.Settings.Default.DatabaseFile; }
            set { _databaseFile = value; }
        }

        public void ConfigureMappings(MappingConfiguration m)
        {
            m.FluentMappings
                .Add<AlbumMapping>()
                .Add<ArtistMapping>()
                .Add<TitleMapping>();
        }
    }
}
