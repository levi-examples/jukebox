using FluentNHibernate.Mapping;

namespace Jukebox.Data.Models.Mappings
{
    public class AlbumMapping : ClassMap<Album>
    {
        public AlbumMapping()
        {
            Table("Album");

            Id(x => x.Id).GeneratedBy.Identity();

            Map(x => x.Name).Column("Name")
                .Index("idxAlbumName");
            Map(x => x.Year).Column("Year");

            References(x => x.Artist).Column("ArtistId");
        }
    }
}