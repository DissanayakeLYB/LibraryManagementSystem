using System;
using System.Collections.Generic;
using System.Linq;

class Book
{
    // Static list to store all books in memory
    private static List<Book> books = new List<Book>();
    private static int nextId = 1;

    // Properties
    public int ID { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public bool IsAvailable { get; set; }

    // Constructor
    public Book(string title, string author, string isbn)
    {
        ID = nextId++;
        Title = title;
        Author = author;
        ISBN = isbn;
        IsAvailable = true;
    }

    // Add a book to the collection
    public static void AddBook(string title, string author, string isbn)
    {
        if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(author) || string.IsNullOrWhiteSpace(isbn))
        {
            Console.WriteLine("Error: Title, Author, and ISBN cannot be empty.");
            return;
        }

        Book newBook = new Book(title, author, isbn);
        books.Add(newBook);
        Console.WriteLine($"✓ Book '{title}' added successfully with ID: {newBook.ID}");
    }

    // View all books
    public static void ViewAllBooks()
    {
        if (books.Count == 0)
        {
            Console.WriteLine("No books in the library.");
            return;
        }

        Console.WriteLine("\n--- Library Books ---");
        foreach (var book in books)
        {
            string status = book.IsAvailable ? "Available" : "Borrowed";
            Console.WriteLine($"ID: {book.ID} | Title: {book.Title} | Author: {book.Author} | ISBN: {book.ISBN} | Status: {status}");
        }
    }

    // Search books by title, author, or ISBN
    public static void SearchBooks(string searchTerm, string searchType = "title")
    {
        List<Book> results = new List<Book>();

        searchType = searchType.ToLower();

        if (searchType == "title")
        {
            results = books.Where(b => b.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
        }
        else if (searchType == "author")
        {
            results = books.Where(b => b.Author.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
        }
        else if (searchType == "isbn")
        {
            results = books.Where(b => b.ISBN.Contains(searchTerm)).ToList();
        }
        else
        {
            Console.WriteLine("Invalid search type. Use 'title', 'author', or 'isbn'.");
            return;
        }

        if (results.Count == 0)
        {
            Console.WriteLine($"No books found matching {searchType}: {searchTerm}");
            return;
        }

        Console.WriteLine($"\n--- Search Results ({results.Count} found) ---");
        foreach (var book in results)
        {
            string status = book.IsAvailable ? "Available" : "Borrowed";
            Console.WriteLine($"ID: {book.ID} | Title: {book.Title} | Author: {book.Author} | ISBN: {book.ISBN} | Status: {status}");
        }
    }

    // Update book details
    public static void UpdateBookDetails(int bookId, string newTitle = null, string newAuthor = null, string newISBN = null)
    {
        Book book = books.FirstOrDefault(b => b.ID == bookId);

        if (book == null)
        {
            Console.WriteLine($"Book with ID {bookId} not found.");
            return;
        }

        if (!string.IsNullOrWhiteSpace(newTitle))
            book.Title = newTitle;

        if (!string.IsNullOrWhiteSpace(newAuthor))
            book.Author = newAuthor;

        if (!string.IsNullOrWhiteSpace(newISBN))
            book.ISBN = newISBN;

        Console.WriteLine($"✓ Book ID {bookId} updated successfully.");
    }

    // Remove a book
    public static void RemoveBook(int bookId)
    {
        Book book = books.FirstOrDefault(b => b.ID == bookId);

        if (book == null)
        {
            Console.WriteLine($"Book with ID {bookId} not found.");
            return;
        }

        books.Remove(book);
        Console.WriteLine($"✓ Book '{book.Title}' (ID: {bookId}) removed successfully.");
    }
}