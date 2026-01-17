class Program
{
    public static void Main( string[] args )
    {
        Boolean isLibraryOpen = true;

        Console.WriteLine( "Welcome to the Library!!!\n" );

        while (isLibraryOpen)
        {
            DisplayMenu();

            Console.Write( "> " );
            var userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    Books.ManageBooks();
                    break;
                
                case "2":
                    Members.ManageMembers();
                    break;

                case "3":
                    Books.BorrowBook();
                    break;

                case "4":
                    Books.ReturnBook();
                    break;

                case "5":
                    Loans.ViewReports();
                    break;

                case "0":
                    isLibraryOpen = false;
                    Console.WriteLine("Exiting the system. Goodbye!\n");
                    break;

                default:
                    Console.WriteLine("Invalid option. Please try again.\n");
                    break;
            }
        }
        
    }

    public static void DisplayMenu()
    {
        Console.WriteLine( "Enter a number to select an option:" );
        Console.WriteLine( "1 - Manage books" );
        Console.WriteLine( "2 - Manage members" );
        Console.WriteLine( "3 - Borrow book" );
        Console.WriteLine( "4 - Return book" );
        Console.WriteLine( "5 - View reports" );
        Console.WriteLine( "0 - Exit" );
    }

    
}