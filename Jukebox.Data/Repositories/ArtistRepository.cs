using System.Collections.Generic;
using System.Linq;
using Jukebox.Data.Models;
using NHibernate.Linq;
using Northwoods.Data.NHibernate;

namespace Jukebox.Data.Repositories
{
    public class ArtistRepository
    {
        private readonly PersistenceBroker<Config.Jukebox> _broker;

        public ArtistRepository(PersistenceBroker<Config.Jukebox> broker)
        {
            _broker = broker;
        }

        public Artist AddOrGet(string name)
        {
            var artist = _broker.Query<Artist>().FirstOrDefault(x => x.Name.Equals(name));
            return artist ?? Create(name);
        }

        private Artist Create(string name)
        {
            return (Artist)_broker.Create(new Artist { Name = name });
        }

        public IQueryable<Artist> All()
        {
            return _broker.Query<Artist>()
                .OrderBy(x => x.Name)
                .AsQueryable();
        }

        public IList<Album> AlbumsFor(int id)
        {
            return _broker.Query<Album>()
                .Where(x => x.Artist.Id == id)
                .Fetch(x => x.Artist)
                .ToList();
        }
    }
}
