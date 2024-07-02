using System.ComponentModel.DataAnnotations;

namespace LibraryWebApp.Entities
{
    public class Books
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year {  get; set; }
        public int Count { get; set; }
        public int AuthorId { get; set; }
        public virtual Authors Author { get; set; }

        public int GenreId { get; set; }
        public virtual Genres Genre { get; set; }

        public virtual ICollection<BuyBook> BuyBook { get; set; }

    }
}
