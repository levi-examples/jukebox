namespace Jukebox.Data.Models
{
    public class Title
    {
        public virtual int Id { get; protected set; }
        public virtual Album Album { get; set; }
        public virtual string Name { get; set; }

        public override string ToString()
        {
            return string.Format("{0} ({1}) - {2}", Album.Artist.Name, Album.Name, Name);
        }
    }
}