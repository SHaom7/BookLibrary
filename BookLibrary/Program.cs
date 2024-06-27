﻿using BookLibrary;

public class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Welcome admin!");
        string menuChoice = "Y";
        do
        {
            Library library = new Library();
            Console.WriteLine("\nLet's start\n\nTo add books press 1\n\nTo remove books press 2\n\nTo add members press 3\n\nTo remove members press 4\n\nTo borrow a book press 5\n\nTo return a book press 6\n\nTo view books lists press 7\n\nTo view members lists press 8\n\n");
            int choiceSwitch = int.Parse(Console.ReadLine());
            switch (choiceSwitch)
            {
                case 1:
                    //BOOKS ADDITION
                    List<Book> objList = new List<Book>();
                    string choice;
                    do
                    {
                        Console.WriteLine("Enter book's title:");
                        string title = Console.ReadLine();
                        Console.WriteLine("Enter book's author:");
                        string author = Console.ReadLine();
                        Console.WriteLine("Enter book's number of copies:");
                        int copies = int.Parse(Console.ReadLine());
                        Book obj = new Book(title, author, copies);
                        objList.Add(obj);
                        Console.WriteLine("\nWant to add more books? Y/N");
                        choice = Console.ReadLine();
                    }
                    while (choice.Equals("Y"));
                    foreach (Book objb in objList)
                    {
                        library.AddNewBook(objb);
                    }
                    Console.WriteLine("\nWant to return to the menu? Y/N\n");
                    menuChoice = Console.ReadLine();
                    break;
                case 2:
                case 3:
                case 4:
                default:
                    Console.WriteLine("\nLet's start\n\nTo add books press 1\n\nTo remove books press 2\n\nTo add members press 3\n\nTo remove members press 4\n\nTo borrow a book press 5\n\nTo return a book press 6\n\nTo view books lists press 7\n\nTo view members lists press 8\n\n");
                    break;
            }
        }
        while (menuChoice.Equals("Y"));
        
        


        
        int num = Library.BookCount;
        Console.WriteLine(num);



        //BOOKS REMOVAL
        Console.WriteLine("\nWant to remove any book? Y/N");
        string removec = Console.ReadLine();
        while (removec.Equals("Y"))
        {
            Console.WriteLine("What is the book title to remove?");
            string title = Console.ReadLine();
            library.RemoveBook(title);
            Console.WriteLine("\nWant to remove additional books? Y/N");
            removec = Console.ReadLine();
        }



        Console.WriteLine("\nNow let's check on members:\n\n");
        //MEMBERS ADDITION
        List<Member> memList = new List<Member>();
        string choicem;
        do
        {
            Console.WriteLine("Enter member's id:");
            string id = Console.ReadLine();
            Console.WriteLine("Enter member's name:");
            string name = Console.ReadLine();
            Member obj = new Member(id, name);
            memList.Add(obj);
            Console.WriteLine("\nWant to add more members? Y/N");
            choicem = Console.ReadLine();
        }
        while (choicem.Equals("Y"));


        foreach (Member objm in memList)
        {
            library.AddMember(objm);
        }



        //BOOKS BORROWING
        Console.WriteLine("\nWant to borrow any book? Y/N");
        string choiceb = Console.ReadLine();
        while (choiceb.Equals("Y"))
        {
            Console.WriteLine("What is your member id?");
            string id = Console.ReadLine();
            foreach (Member obj in library.GetMembers())
            {
                if (obj.GetId().Equals(id))
                {
                    Console.WriteLine("What is the title of the book you want to borrow?");
                    string title = Console.ReadLine();
                    library.BorrowBook(obj, title);
                }
            }
            Console.WriteLine("Want to borrow another book? Y/N");
            choiceb = Console.ReadLine();
        }



        //BOOKS RETURNING
        Console.WriteLine("\nWant to return any book? Y/N");
        string choicer = Console.ReadLine();
        while (choicer.Equals("Y"))
        {
            Console.WriteLine("What is your member id?");
            string id = Console.ReadLine();
            foreach (Member obj in library.GetMembers())
            {
                if (obj.GetId().Equals(id))
                {
                    Console.WriteLine("What is the title of the book you want to return?");
                    string title = Console.ReadLine();
                    obj.ReturnBook(title);
                }
            }
            Console.WriteLine("Want to return another book? Y/N");
            choicer = Console.ReadLine();
        }



        //BOOKS LIST
        Console.WriteLine("\nList of the avalible books:");
        foreach (Book book in library.GetBooks())
        {
            Console.WriteLine(book.ToString());
        }



        //MEMBERS LIST
        Console.WriteLine("\nMembers list:");
        foreach (Member mem in library.GetMembers())
        {
            Console.WriteLine(mem.ToString());
        }
    }
}