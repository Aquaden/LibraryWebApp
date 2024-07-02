using System.ComponentModel.DataAnnotations;

namespace LibraryWebApp.Entities
{
    public class Genres
    {
        [Key]
        public int Id { get; set; }
        public string GenreName { get; set; }

        public virtual ICollection<Books> Books { get; set; }

    }
}
