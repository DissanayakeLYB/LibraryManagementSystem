class Program
{
    public static void Main (string[] args)
    
    {
        bool isRunning = true; 

        while (isRunning)
        {
            
            Console.WriteLine("Library Management System\n");
            
            Console.WriteLine("1. Add books");
            Console.WriteLine("2. View available books");
            Console.WriteLine("3. Lend books");
            Console.WriteLine("4. Search books");
            Console.WriteLine("5. Return books");
            Console.WriteLine("6. Register members");
            Console.WriteLine("7. Search members");
            Console.WriteLine("8. Exit");

            Console.Write("Enter the number: ");
            var actionNumber = Console.ReadLine();

            actionNumber?.ToString();

            switch(actionNumber)
            {
                case "1":
                    Console.Write("Enter book title: ");
                    string title = Console.ReadLine();
                    Console.Write("Enter author name: ");
                    string author = Console.ReadLine();
                    Console.Write("Enter ISBN: ");
                    string isbn = Console.ReadLine();
                    Book.AddBook(title, author, isbn);
                    Console.WriteLine();
                    break;

                case "2":
                    Book.ViewAllBooks();
                    Console.WriteLine();
                    break;

                case "3":
                    Book.ViewAllBooks();
                    Console.Write("Enter book ID to lend: ");
                    if (int.TryParse(Console.ReadLine(), out int lendBookId))
                    {
                        // TODO: Implement lend functionality (mark book as unavailable)
                        Console.WriteLine("Lend functionality to be implemented.\n");
                    }
                    else
                    {
                        Console.WriteLine("Invalid book ID.\n");
                    }
                    break;

                case "4":
                    Console.Write("Search by (title/author/isbn): ");
                    string searchType = Console.ReadLine();
                    Console.Write("Enter search term: ");
                    string searchTerm = Console.ReadLine();
                    Book.SearchBooks(searchTerm, searchType);
                    Console.WriteLine();
                    break;

                case "5":
                    Book.ViewAllBooks();
                    Console.Write("Enter book ID to return: ");
                    if (int.TryParse(Console.ReadLine(), out int returnBookId))
                    {
                        // TODO: Implement return functionality (mark book as available)
                        Console.WriteLine("Return functionality to be implemented.\n");
                    }
                    else
                    {
                        Console.WriteLine("Invalid book ID.\n");
                    }
                    break;

                case "6":
                    Console.WriteLine("Register members - functionality to be implemented.\n");
                    break;

                case "7":
                    Console.WriteLine("Search members - functionality to be implemented.\n");
                    break;

                case "8":
                    Console.WriteLine("Exiting...\n");
                    Console.WriteLine("Successfully Exited!!!");
                    isRunning = false;
                    break;

                default:
                    Console.WriteLine("Invalid Action. Please reenter the number.\n");
                    break;
            }
        }
    }
}
