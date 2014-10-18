using FluentNHibernate.Mapping;

namespace Jukebox.Data.Models.Mappings
{
    public class ArtistMapping : ClassMap<Artist>
    {
        public ArtistMapping()
        {
            Table("Artist");

            Id(x => x.Id).GeneratedBy.Identity();

            Map(x => x.Name).Column("Name")
                .Index("idxArtistName");
        }
    }
}