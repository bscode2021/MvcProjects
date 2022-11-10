namespace MyFirstDbTableConnection.Models.Entity
{
    public class BookCategories
    {
        public Guid BookID { get; set; }
        public Book Book { get; set; }
        public Guid CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
