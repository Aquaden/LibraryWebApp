using LibraryWebApp.Entities;

namespace LibraryWebApp.Dtos
{
    public class BuyBooksDto
    {
        public int BookId { get; set; }
        

        public int PersonalId { get; set; }

        public DateTime Date { get; set; }
    }
}
