namespace LibraryWebApp.Entities
{
    public class BuyBook
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public virtual Books Book { get; set; }

        public int PersonalId { get; set; }
        public virtual Personal Personal { get; set; }

        public DateTime Date { get; set; }

    }
}
