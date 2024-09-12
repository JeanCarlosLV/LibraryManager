namespace LibraryManager.Services
{
    public class BookService
    {
        private List<Book> books = new List<Book>();

        public void AddBook(Book book)
        {
            books.Add(book);
        }

        public List<Book> GetAllBooks()
        {
            return books;
        }

        public string GetBook(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);

            if (book != null)
            {                
                return book.Title;
            }
            else
            {
                throw new Exception("Book not found");
            }
        }

        public void RemoveBook(int id)
        {
            books.RemoveAll(book => book.Id == id);

        }

        public void UpdateBook(int id, Book updatedBook)
        {
            var book = books.FirstOrDefault(b => b.Id == id);

            if (book != null)
            {

                book.Title = updatedBook.Title;
                book.Author = updatedBook.Author;
                book.Price = updatedBook.Price;
                book.InStock = updatedBook.InStock;
                book.BookGenre = updatedBook.BookGenre;
            }
            else
            {
                throw new Exception("Book not found");
            }
        }

    }
}
