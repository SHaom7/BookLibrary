using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    public class Member
    {
        private string _id;
        private string _name;
        private List<Book> _borrowedList = new List<Book>();

        public Member(string id, string name)
        {
            SetId(id);
            SetName(name);
        }

        public void SetId(string id)
        {
            _id = id;
        }

        public string GetId()
        {
            return _id;
        }
        public void SetName(string name) 
        { 
            _name = name;
        }

        public string GetName() 
        {
            return _name;
        }

        public void BorrowNewBook(Book book)
        {
            _borrowedList.Add(book);
        }

        public List<Book> GetBorrowedList()
        {
            return _borrowedList;
        }

        public void ReturnBook(string title)
        {
            foreach (Book b in _borrowedList)
            {
                if (b.GetTitle().Equals(title))
                {
                    b.SetCopies(b.GetCopies() + 1);
                    _borrowedList.Remove(b);
                    Console.WriteLine("The book: " + title + " has been returned");
                    break;
                }
            }
        }

        public override string ToString()
        {
            StringBuilder finalString = new StringBuilder();
            finalString.AppendLine("ID: " + GetId());
            finalString.AppendLine("Name: " + GetName());
            finalString.AppendLine("List of borrowed books:");

            foreach (Book b in GetBorrowedList())
            {
                finalString.AppendLine(b.GetTitle()); 
            }

            return finalString.ToString();
        }
    }
}
