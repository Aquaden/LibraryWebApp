using System.ComponentModel.DataAnnotations;

namespace LibraryWebApp.Entities
{
    public class Personal
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public virtual ICollection<BuyBook> BuyBook { get; set; }

    }
}
