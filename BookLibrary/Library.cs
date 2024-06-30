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

        public void RemoveBook(string id)
        {
            foreach (Book b in _books)
            {
                if (b.GetID().Equals(id))
                {
                    _books.Remove(b);
                    Console.WriteLine("The book: " + b.GetTitle() + " has been removed");
                    BookCount--;
                    break;
                }
            }
        }


        public void RemoveMember(string id)
        {
            foreach (Member m in _members)
            {
                if (m.GetId().Equals(id))
                {
                    _members.Remove(m);
                    Console.WriteLine("The member: " + m.GetName() + " has been removed");
                    BookCount--;
                    break;
                }
            }
        }

        public void BorrowBook(Member member, string id)
        {
            foreach(Book b in _books)
            {
                if(b.GetID().Equals(id))
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
