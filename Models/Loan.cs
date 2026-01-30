public class Loan
{
    public int Id { get; set; }
    public int BookId { get; set; }
    public int MemberId { get; set; }
    public DateTime LoanDate { get; set; }
    public DateTime? ReturnDate { get; set; }

    public Loan(int id, int bookId, int memberId, DateTime loanDate, DateTime? returnDate = null)
    {
        Id = id;
        BookId = bookId;
        MemberId = memberId;
        LoanDate = loanDate;
        ReturnDate = returnDate;
    }
}

public class Loans
{
    public static List<Loan> loanList = new List<Loan>();

    public static void ViewReports()
    {
        try
        {
            Console.WriteLine("\n=== Loan Reports ===");
            
            if (loanList.Count == 0)
            {
                Console.WriteLine("No loan records available.");
                return;
            }

            var activeLoans = loanList.Where(l => l.ReturnDate == null).ToList();
            var returnedLoans = loanList.Where(l => l.ReturnDate != null).ToList();

            Console.WriteLine($"\nActive Loans: {activeLoans.Count}");
            foreach (var loan in activeLoans)
            {
                Console.WriteLine($"  Book ID: {loan.BookId}, Member ID: {loan.MemberId}, Loan Date: {loan.LoanDate:yyyy-MM-dd}");
            }

            Console.WriteLine($"\nReturned Loans: {returnedLoans.Count}");
            foreach (var loan in returnedLoans.Take(5)) // Show last 5 for brevity
            {
                Console.WriteLine($"  Book ID: {loan.BookId}, Member ID: {loan.MemberId}, Returned Date: {loan.ReturnDate:yyyy-MM-dd}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while viewing reports: {ex.Message}");
        }
    }
}