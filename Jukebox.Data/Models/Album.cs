namespace Jukebox.Data.Models
{
    public class Album
    {
        public virtual int Id { get; protected set; }
        public virtual Artist Artist { get; set; }
        public virtual string Name { get; set; }
        public virtual string Year { get; set; }
    }
}