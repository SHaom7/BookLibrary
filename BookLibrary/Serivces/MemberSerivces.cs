using BookLibrary.Models;
using BookLibrary.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Services
{
    public class MemberService
    {
        private BookLibraryContext _context;

        public MemberService(BookLibraryContext context)
        {
            _context = context;
        }

        public void AddMember(Member member)
        {
            _context.Members.Add(member);
            _context.SaveChanges();
        }

        public Member GetMember(Guid memberId)
        {
            return _context.Members.Find(memberId);
        }

        public List<Member> GetAllMembers()
        {
            return _context.Members.ToList();
        }

        public IEnumerable<Book> BooksBorrowedByMember(Guid memberId)
        {
            return _context.Members
                .Where(m => m.MemberId == memberId)
                .SelectMany(m => m.MemberBooks)
                .Select(mb => mb.Book)
                .ToList();
        }


        public void DeleteMember(Guid id)
        {
            var member = GetMember(id);
            if (member != null)
            {
                _context.Members.Remove(member);
                _context.SaveChanges();
                Console.WriteLine("Member with ID " + member.MemberId.ToString() + " has been removed.");
            }
            else
            {
                Console.WriteLine("Member with ID " + member.MemberId.ToString() + " not found.");
            }
        }


        public void BorrowBook(Member member, Guid bookId)
        {
            var book = _context.Books.Find(bookId);

            if (book != null)
            {
                if (book.Copies > 0)
                {
                    book.Copies--;
                    MemberBook memberBook = new MemberBook { MemberId = member.MemberId, BookId = bookId };
                    _context.MemberBooks.Add(memberBook);
                    _context.SaveChanges();
                    Console.WriteLine($"{member.Name} of ID {member.MemberId} borrowed {book.Title}");
                }
                else
                {
                    Console.WriteLine($"The book: {book.Title} is not available.");
                }
            }
            else
            {
                Console.WriteLine($"Book with ID {bookId} not found.");
            }
        }

        public void ReturnBook(Member member, Guid bookId)
        {
            var memberBook = _context.MemberBooks.FirstOrDefault(mb => mb.MemberId == member.MemberId && mb.BookId == bookId);

            if (memberBook != null)
            {
                var book = _context.Books.Find(memberBook.BookId);
                if (book != null)
                {
                    book.Copies++;
                    _context.MemberBooks.Remove(memberBook);
                    _context.SaveChanges();
                    Console.WriteLine($"{member.Name} returned {book.Title}.");
                }
                else
                {
                    Console.WriteLine($"Book with ID {memberBook.BookId} not found.");
                }
            }
            else
            {
                Console.WriteLine($"{member.Name} did not borrow {bookId}.");
            }
        }
    }
}