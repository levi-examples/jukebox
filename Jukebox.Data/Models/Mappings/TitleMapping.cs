using FluentNHibernate.Mapping;

namespace Jukebox.Data.Models.Mappings
{
    public class TitleMapping : ClassMap<Title>
    {
        public TitleMapping()
        {
            Table("Title");

            Id(x => x.Id).GeneratedBy.Identity();

            Map(x => x.Name).Column("Name")
                .Index("idxTitleName");

            References(x => x.Album).Column("AlbumId");
        }
    }
}