using BookLibrary;

public class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Welcome admin!");
        string menuChoice = "Y";
        Library library = new Library();
        List<Book> objList = new List<Book>();
        List<Member> memList = new List<Member>();
        do
        {
            Console.WriteLine("\nLet's start\n\nTo add books press 1\n\nTo remove books press 2\n\nTo add members press 3\n\nTo remove members press 4\n\nTo borrow a book press 5\n\nTo return a book press 6\n\nTo view books lists press 7\n\nTo view members lists press 8\n\n");
            int choiceSwitch = int.Parse(Console.ReadLine());
            switch (choiceSwitch)
            {
                case 1:
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
                    string c = "Y";
                    do
                    {
                        Console.WriteLine("What is the book title to remove?");
                        string title = Console.ReadLine();
                        library.RemoveBook(title);
                        Console.WriteLine("\nWant to remove additional books? Y/N");
                        c = Console.ReadLine();
                    }
                    while (c.Equals("Y"));
                    Console.WriteLine("\nWant to return to the menu? Y/N\n");
                    menuChoice = Console.ReadLine();
                    break;

                case 3:
                    string choicem = "Y";
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
                    // Add members to the library using AddMember
                    foreach (Member objm in memList)
                    {
                        library.AddMember(objm);
                    }
                    Console.WriteLine("\nWant to return to the menu? Y/N\n");
                    menuChoice = Console.ReadLine();
                    break;
                case 4:
                    
                    Console.WriteLine("\nWant to return to the menu? Y/N\n");
                    menuChoice = Console.ReadLine();
                    break;
                case 5:
                    string b = Console.ReadLine();
                    do
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
                        b = Console.ReadLine();
                    }
                    while (b.Equals("Y"));
                    Console.WriteLine("\nWant to return to the menu? Y/N\n");
                    menuChoice = Console.ReadLine();
                    break;
                case 6:
                    string choicer;
                    do
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
                    while (choicer.Equals("Y"));
                    Console.WriteLine("\nWant to return to the menu? Y/N\n");
                    menuChoice = Console.ReadLine();
                    break;
                case 7:
                    Console.WriteLine("\nList of the avalible books:");
                    foreach (Book book in library.GetBooks())
                    {
                        Console.WriteLine(book.ToString());
                    }
                    Console.WriteLine("\nWant to return to the menu? Y/N\n");
                    menuChoice = Console.ReadLine();
                    break;
                case 8:
                    Console.WriteLine("\nMembers list:");
                    foreach (Member mem in library.GetMembers())
                    {
                        Console.WriteLine(mem.ToString());
                    }
                    Console.WriteLine("\nWant to return to the menu? Y/N\n");
                    menuChoice = Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("\nLet's start\n\nTo add books press 1\n\nTo remove books press 2\n\nTo add members press 3\n\nTo remove members press 4\n\nTo borrow a book press 5\n\nTo return a book press 6\n\nTo view books lists press 7\n\nTo view members lists press 8\n\n");
                    break;
            }
        }
        while (menuChoice.Equals("Y"));
        
    }
}