using System.Linq;
using Jukebox.Data.Models;
using Northwoods.Data.NHibernate;

namespace Jukebox.Data.Repositories
{
    public class ArtistRepository
    {
        private readonly PersistenceBroker<Jukebox> _broker;

        public ArtistRepository(PersistenceBroker<Jukebox> broker)
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
    }
}
