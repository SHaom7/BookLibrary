using BookLibrary;
using BookLibrary.Models;
using BookLibrary.Services;
using BookLibrary.Data;
using System;
using System.Collections.Generic;

public class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Welcome admin!");
        string menuChoice = "Y";

        BookLibraryContext context = new BookLibraryContext();
        BookService bookService = new BookService(context);
        MemberService memberService = new MemberService(context);

        do
        {
            Console.WriteLine("\nLet's start\n\n1 To add books " +
                        "\n\n2 To remove books" +
                        "\n\n3 To add members" +
                        "\n\n4 To remove members" +
                        "\n\n5 To borrow a book" +
                        "\n\n6 To return a book" +
                        "\n\n7 To view books lists" +
                        "\n\n8 To view members lists" +
                        "\n\n9 To view books borrowed by a member" +
                        "\n\n10 To view members who borrowed a book\n\n");
            int choiceS = int.Parse(Console.ReadLine());
            

            switch (choiceS)
            {
                case 1:
                    AddBooks(bookService);
                    break;

                case 2:
                    RemoveBooks(bookService);
                    break;

                case 3:
                    AddMembers(memberService);
                    break;

                case 4:
                    RemoveMembers(memberService);
                    break;

                case 5:
                    BorrowBook(memberService);
                    break;

                case 6:
                    ReturnBook(memberService);
                    break;

                case 7:
                    ViewBooks(bookService);
                    break;

                case 8:
                    ViewMembers(memberService);
                    break;

                case 9:
                    ViewBooksBorrowedByMember(memberService);
                    break;

                case 10:
                    ViewMembersWhoBorrowedBook(bookService);
                    break;

                default:
                    Console.WriteLine("Invalid selection. Please choose a valid option.");
                    break;
            }

            Console.WriteLine("\nWant to return to the menu? Y/N\n");
            menuChoice = Console.ReadLine();
        }
        while (menuChoice.Equals("Y"));
    }

    private static void AddBooks(BookService bookService)
    {
        string choice;
        do
        {
            Console.WriteLine("Enter book's title:");
            string title = Console.ReadLine();
            Console.WriteLine("Enter book's author:");
            string author = Console.ReadLine();
            Console.WriteLine("Enter book's number of copies:");
            int copies = int.Parse(Console.ReadLine());
            Book book = new Book { Title = title, Author = author, Copies = copies };
            bookService.AddBook(book);
            Console.WriteLine("\nWant to add more books? Y/N");
            choice = Console.ReadLine();
        }
        while (choice.Equals("Y"));
    }

    private static void RemoveBooks(BookService bookService)
    {
        string choice;
        do
        {
            Console.WriteLine("What is the book ID you want to remove?");
            Guid id = Guid.Parse(Console.ReadLine());
            bookService.DeleteBook(id);
            Console.WriteLine("\nWant to remove additional books? Y/N");
            choice = Console.ReadLine();
        }
        while (choice.Equals("Y"));
    }

    private static void AddMembers(MemberService memberService)
    {
        string choice;
        do
        {
            Console.WriteLine("Enter member's name:");
            string name = Console.ReadLine();
            Member member = new Member { Name = name };
            memberService.AddMember(member);
            Console.WriteLine("\nWant to add more members? Y/N");
            choice = Console.ReadLine();
        }
        while (choice.Equals("Y"));
    }

    private static void RemoveMembers(MemberService memberService)
    {
        string choice;
        do
        {
            Console.WriteLine("What is the member ID you want to remove?");
            Guid id = Guid.Parse(Console.ReadLine());
            memberService.DeleteMember(id);
            Console.WriteLine("\nWant to remove additional members? Y/N");
            choice = Console.ReadLine();
        }
        while (choice.Equals("Y"));
    }

    private static void BorrowBook(MemberService memberService)
    {
        string choice;
        do
        {
            Console.WriteLine("What is your member ID?");
            Guid memberId = Guid.Parse(Console.ReadLine());
            Member member = memberService.GetMember(memberId);
            if (member != null)
            {
                Console.WriteLine("What is the ID of the book you want to borrow?");
                Guid bookId = Guid.Parse(Console.ReadLine());
                memberService.BorrowBook(member, bookId);
            }
            Console.WriteLine("Want to borrow another book? Y/N");
            choice = Console.ReadLine();
        }
        while (choice.Equals("Y"));
    }

    private static void ReturnBook(MemberService memberService)
    {
        string choice;
        do
        {
            Console.WriteLine("What is your member ID?");
            Guid memberId = Guid.Parse(Console.ReadLine());
            Member member = memberService.GetMember(memberId);
            if (member != null)
            {
                Console.WriteLine("What is the ID of the book you want to return?");
                Guid bookId = Guid.Parse(Console.ReadLine());
                memberService.ReturnBook(member, bookId);
            }
            Console.WriteLine("Want to return another book? Y/N");
            choice = Console.ReadLine();
        }
        while (choice.Equals("Y"));
    }

    private static void ViewBooks(BookService bookService)
    {
        Console.WriteLine("\nList of the available books:");
        foreach (Book book in bookService.GetAllBooks())
        {
            Console.WriteLine($"ID: {book.BookId}, Title: {book.Title}, Author: {book.Author}, Copies: {book.Copies}");
        }
    }

    private static void ViewMembers(MemberService memberService)
    {
        Console.WriteLine("\nMembers list:");
        foreach (Member member in memberService.GetAllMembers())
        {
            Console.WriteLine($"ID: {member.MemberId}, Name: {member.Name}");
        }
    }

    private static void ViewBooksBorrowedByMember(MemberService memberService)
    {
        Console.WriteLine("Enter the member ID:");
        Guid memberId = Guid.Parse(Console.ReadLine());
        var books = memberService.BooksBorrowedByMember(memberId);
        Console.WriteLine($"Books borrowed by member {memberId}:");
        foreach (var book in books)
        {
            Console.WriteLine($"ID: {book.BookId}, Title: {book.Title}, Author: {book.Author}");
        }
    }

    private static void ViewMembersWhoBorrowedBook(BookService bookService)
    {
        Console.WriteLine("Enter the book ID:");
        Guid bookId = Guid.Parse(Console.ReadLine());
        var members = bookService.MembersBorrowedBook(bookId);
        Console.WriteLine($"Members who borrowed book {bookId}:");
        foreach (var member in members)
        {
            Console.WriteLine($"ID: {member.MemberId}, Name: {member.Name}");
        }
    }
}