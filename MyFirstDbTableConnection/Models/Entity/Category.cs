using System.ComponentModel.DataAnnotations;

namespace MyFirstDbTableConnection.Models.Entity
{
    public class Category
    {
        [Key]
        public Guid CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
    }
}
