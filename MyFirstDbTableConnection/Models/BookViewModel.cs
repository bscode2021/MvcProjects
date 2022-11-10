using MyFirstDbTableConnection.Models.Entity;

namespace MyFirstDbTableConnection.Models
{
    public class BookViewModel
    {
        public BookViewModel()
        {
            Book = new Book();
            Categories = new List<Category>();
        }

        public BookViewModel(Book book, List<Category> categories)
        {
            Book = book ?? throw new ArgumentNullException(nameof(book));
            Categories = categories ?? throw new ArgumentNullException(nameof(categories));
        }

        public Book Book { get; set; }
        public List<Category> Categories { get; set; }
    }
}
