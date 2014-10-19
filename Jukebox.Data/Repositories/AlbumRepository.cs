using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Jukebox.Data.Models;
using NHibernate.Linq;
using Northwoods.Data.NHibernate;

namespace Jukebox.Data.Repositories
{
    public class AlbumRepository
    {
        private readonly PersistenceBroker<Config.Jukebox> _broker;

        public AlbumRepository(PersistenceBroker<Config.Jukebox> broker)
        {
            _broker = broker;
        }

        public Album AddOrGet(Artist artist, string albumName, string albumYear)
        {
            var album = _broker.Query<Album>()
                .FirstOrDefault(x => x.Artist == artist && x.Name.Equals(albumName));

            return album ?? Create(artist, albumName, albumYear);
        }

        public Title AddSong(Album album, string songTitle)
        {
            var title = _broker.Query<Title>()
                .FirstOrDefault(x => x.Album == album && x.Name.Equals(songTitle));

            return title ?? Create(album, songTitle);
        }

        public IList<Title> TitlesFor(int id)
        {
            return _broker.Query<Title>()
                .Where(x => x.Album.Id == id)
                .Fetch(x => x.Album)
                .ThenFetch(x => x.Artist)
                .ToList();
        }

        private Album Create(Artist artist, string albumName, string albumYear)
        {
            return (Album)_broker.Create(new Album { Artist = artist, Name = albumName, Year = albumYear });
        }

        private Title Create(Album album, string songTitle)
        {
            return (Title) _broker.Create(new Title {Name = songTitle, Album = album});
        }
    }
}