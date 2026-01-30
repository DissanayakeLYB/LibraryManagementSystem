
public class Books
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public bool Available { get; set; }

    // constructor
    public Books(int id, string title, string author, string isbn, bool available)
    {
        Id = id;
        Title = title;
        Author = author;
        ISBN = isbn;
        Available = available;
    }

    public static List<Books> bookList = new List<Books>(); // list to store multiple books
    public static void ManageBooks()
    {
        while (true)
        {
            Console.WriteLine("\nManage Books:");
            Console.WriteLine("1 - Add a book");
            Console.WriteLine("2 - View all books");
            Console.WriteLine("3 - Remove a book");
            Console.WriteLine("0 - Back to main menu");

            Console.Write("\nChoose an option: ");
            var choice = Console.ReadLine();

            if (choice == "1")
            {
                AddBook();
            }
            else if (choice == "2")
            {
                ViewBooks();
            }
            else if (choice == "3")
            {
                RemoveBook();
            }
            else if (choice == "0")
            {
                break; 
            }
            else
            {
                Console.WriteLine("Invalid option.");
            }
        }
    }

    // addbook
    public static void AddBook()
    {
        int inputID = 0;
        string bookTitle = "";
        string bookAuthor = "";
        string bookISBN = "";

        try
        {
            Console.Write("Enter Book ID: ");
            if (!int.TryParse(Console.ReadLine(), out inputID))
            {
                Console.WriteLine("Invalid input. Please enter a valid Book ID.");
                return;
            }

            // Check if book with same ID already exists
            if (bookList.Any(b => b.Id == inputID))
            {
                Console.WriteLine("A book with this ID already exists.");
                return;
            }

            Console.Write("Enter Book Title: ");
            bookTitle = Console.ReadLine()?.Trim() ?? "";
            if (string.IsNullOrWhiteSpace(bookTitle))
            {
                Console.WriteLine("Book title cannot be empty.");
                return;
            }

            Console.Write("Enter Book Author: ");
            bookAuthor = Console.ReadLine()?.Trim() ?? "";
            if (string.IsNullOrWhiteSpace(bookAuthor))
            {
                Console.WriteLine("Book author cannot be empty.");
                return;
            }

            Console.Write("Enter Book ISBN: ");
            bookISBN = Console.ReadLine()?.Trim() ?? "";
            if (string.IsNullOrWhiteSpace(bookISBN))
            {
                Console.WriteLine("Book ISBN cannot be empty.");
                return;
            }

            var newBook = new Books(inputID, bookTitle, bookAuthor, bookISBN, true);
            bookList.Add(newBook);

            Console.WriteLine("Book added successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while adding the book: {ex.Message}");
        }
    }

    // viewbooks
    public static void ViewBooks()
    {
        try
        {
            if (bookList.Count == 0)
            {
                Console.WriteLine("\nNo books available in the library.");
                return;
            }

            Console.WriteLine("\n=== Library Books ===");
            foreach (var book in bookList)
            {
                Console.WriteLine($"ID: {book.Id}");
                Console.WriteLine($"Title: {book.Title}");
                Console.WriteLine($"Author: {book.Author}");
                Console.WriteLine($"ISBN: {book.ISBN}");
                Console.WriteLine($"Available: {(book.Available ? "Yes" : "No")}");
                Console.WriteLine("---");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while viewing books: {ex.Message}");
        }
    }

    // removebook
    public static void RemoveBook()
    {
        try
        {
            if (bookList.Count == 0)
            {
                Console.WriteLine("\nNo books available to remove.");
                return;
            }

            Console.Write("Enter Book ID to remove: ");
            if (!int.TryParse(Console.ReadLine(), out int bookIdToRemove))
            {
                Console.WriteLine("Invalid input. Please enter a valid Book ID.");
                return;
            }

            var bookToRemove = bookList.FirstOrDefault(b => b.Id == bookIdToRemove);
            if (bookToRemove == null)
            {
                Console.WriteLine("Book not found.");
                return;
            }

            bookList.Remove(bookToRemove);
            Console.WriteLine("Book removed successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while removing the book: {ex.Message}");
        }
    }

    // borrowbook
    public static void BorrowBook()
    {
        try
        {
            if (bookList.Count == 0)
            {
                Console.WriteLine("\nNo books available to borrow.");
                return;
            }

            Console.Write("Enter Book ID to borrow: ");
            if (!int.TryParse(Console.ReadLine(), out int bookIdToBorrow))
            {
                Console.WriteLine("Invalid input. Please enter a valid Book ID.");
                return;
            }

            var bookToBorrow = bookList.FirstOrDefault(b => b.Id == bookIdToBorrow);
            if (bookToBorrow == null)
            {
                Console.WriteLine("Book not found.");
                return;
            }

            if (!bookToBorrow.Available)
            {
                Console.WriteLine("Book is not available for borrowing.");
                return;
            }

            bookToBorrow.Available = false;
            Console.WriteLine($"Book '{bookToBorrow.Title}' borrowed successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while borrowing the book: {ex.Message}");
        }
    }

    // returnbook
    public static void ReturnBook()
    {
        try
        {
            if (bookList.Count == 0)
            {
                Console.WriteLine("\nNo books in the library.");
                return;
            }

            Console.Write("Enter Book ID to return: ");
            if (!int.TryParse(Console.ReadLine(), out int bookIdToReturn))
            {
                Console.WriteLine("Invalid input. Please enter a valid Book ID.");
                return;
            }

            var bookToReturn = bookList.FirstOrDefault(b => b.Id == bookIdToReturn);
            if (bookToReturn == null)
            {
                Console.WriteLine("Book not found.");
                return;
            }

            if (bookToReturn.Available)
            {
                Console.WriteLine("This book is already available in the library.");
                return;
            }

            bookToReturn.Available = true;
            Console.WriteLine($"Book '{bookToReturn.Title}' returned successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while returning the book: {ex.Message}");
        }
    }

}