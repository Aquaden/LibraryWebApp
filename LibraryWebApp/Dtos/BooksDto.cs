using LibraryWebApp.Entities;

namespace LibraryWebApp.Dtos
{
    public class BooksDto
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public int Count { get; set; }
        public int AuthorId { get; set; }
        

        public int GenreId { get; set; }
       
    }
}
