using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    public class Book
    {
        private string _title;
        private string _author;
        private int _copies;
        public Book(string title, string author, int copies = 5)
        {
            SetTitle(title);
            SetAuthor(author);
            SetCopies(copies);
        }

        public void SetTitle(string title) 
        { this._title = title;}

        public string GetTitle() 
        { return this._title;}

        public void SetAuthor(string author)
        { this._author = author;}

        public string GetAuthor()
        { return this._author;}

        public void SetCopies(int copies)
        { this._copies = copies; }

        public int GetCopies()
        { return this._copies; }

        public override string ToString()
        {
            return "Title: " + GetTitle() + "\nAuthor: " + GetAuthor() + "\nCopies: " + GetCopies();
        }

    }
}
