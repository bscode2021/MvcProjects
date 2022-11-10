using System.ComponentModel.DataAnnotations;

namespace MyFirstDbTableConnection.Models.Entity
{
    public class Book
    {

        [Key]
        public Guid BookID { get; set; }
        public int Pages { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
    }
}
