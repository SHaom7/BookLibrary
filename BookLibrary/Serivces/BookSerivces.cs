using BookLibrary.Models;
using BookLibrary.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Services
{
    public class BookService
    {
        private BookLibraryContext _context;

        public BookService(BookLibraryContext context)
        {
            _context = context;
        }

        public void AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public Book GetBook(Guid bookId)
        {
            return _context.Books.Find(bookId);
        }

        public List<Book> GetAllBooks()
        {
            return _context.Books.ToList();
        }


        public IEnumerable<Member> MembersBorrowedBook(Guid bookId)
        {
            return _context.Books
                .Where(b => b.BookId == bookId)
                .SelectMany(b => b.MemberBooks)
                .Select(mb => mb.Member)
                .ToList();
        }

        public void DeleteBook(Guid id)
        {
            var book = GetBook(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
                Console.WriteLine("The book: " + book.Title + " has been removed");
            }
            else
            {
                Console.WriteLine("Book with ID " + id.ToString() + " not found.");
            }
        }
    }
}
