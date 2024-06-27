using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    public class Library
    {
        private List<Book> _books = new List<Book>();
        private List<Member> _members = new List<Member>();
        public static int BookCount = 0;
        public static int MemberCount = 0;
        
        public void AddNewBook(Book book)
        {
            _books.Add(book);
            BookCount++;
        }

        public void AddMember(Member member) 
        { 
            _members.Add(member);
            MemberCount++;
        }

        public List<Book> GetBooks() 
        {
            return _books;
        }

        public List<Member> GetMembers() 
        {
            return _members;
        }

        public void RemoveBook(string title)
        {
            foreach (Book b in _books)
            {
                if (b.GetTitle().Equals(title))
                {
                    _books.Remove(b);
                    Console.WriteLine("The book: " + title + " has been removed");
                    BookCount--;
                    break;
                }
            }
        }

        public void BorrowBook(Member member, string title)
        {
            foreach(Book b in _books)
            {
                if(b.GetTitle().Equals(title))
                { 
                    if(b.GetCopies() > 0)
                    {
                        b.SetCopies(b.GetCopies() - 1);
                        member.BorrowNewBook(b);
                        Console.WriteLine(member.GetName() + " of id " + member.GetId() + " borrowed " + b.GetTitle());
                        break;
                    }

                    else
                    {
                        Console.WriteLine("The book: " + b.GetTitle() + " isnt avalible");
                        break;
                    }
                }
                
            }
        }
    }
}
