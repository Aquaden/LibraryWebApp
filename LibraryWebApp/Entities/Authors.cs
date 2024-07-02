using System.ComponentModel.DataAnnotations;

namespace LibraryWebApp.Entities
{
    public class Authors
    {
        [Key]
        public int id {  get; set; }
        public string name { get; set; }

        public virtual ICollection<Books> Books { get; set; }
    }
}
