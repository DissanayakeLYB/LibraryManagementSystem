public class Member
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime JoinDate { get; set; }

    public Member(int id, string name, string email, DateTime joinDate)
    {
        Id = id;
        Name = name;
        Email = email;
        JoinDate = joinDate;
    }
}

public class Members
{
    public static List<Member> memberList = new List<Member>();

    public static void ManageMembers()
    {
        while (true)
        {
            Console.WriteLine("\nManage Members:");
            Console.WriteLine("1 - Add a member");
            Console.WriteLine("2 - View all members");
            Console.WriteLine("3 - Remove a member");
            Console.WriteLine("0 - Back to main menu");

            Console.Write("\nChoose an option: ");
            var choice = Console.ReadLine();

            if (choice == "1")
            {
                AddMember();
            }
            else if (choice == "2")
            {
                ViewMembers();
            }
            else if (choice == "3")
            {
                RemoveMember();
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

    public static void AddMember()
    {
        try
        {
            Console.Write("Enter Member ID: ");
            if (!int.TryParse(Console.ReadLine(), out int memberId))
            {
                Console.WriteLine("Invalid input. Please enter a valid Member ID.");
                return;
            }

            if (memberList.Any(m => m.Id == memberId))
            {
                Console.WriteLine("A member with this ID already exists.");
                return;
            }

            Console.Write("Enter Member Name: ");
            string memberName = Console.ReadLine()?.Trim() ?? "";
            if (string.IsNullOrWhiteSpace(memberName))
            {
                Console.WriteLine("Member name cannot be empty.");
                return;
            }

            Console.Write("Enter Member Email: ");
            string memberEmail = Console.ReadLine()?.Trim() ?? "";
            if (string.IsNullOrWhiteSpace(memberEmail))
            {
                Console.WriteLine("Member email cannot be empty.");
                return;
            }

            var newMember = new Member(memberId, memberName, memberEmail, DateTime.Now);
            memberList.Add(newMember);
            Console.WriteLine("Member added successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while adding the member: {ex.Message}");
        }
    }

    public static void ViewMembers()
    {
        try
        {
            if (memberList.Count == 0)
            {
                Console.WriteLine("\nNo members available.");
                return;
            }

            Console.WriteLine("\n=== Library Members ===");
            foreach (var member in memberList)
            {
                Console.WriteLine($"ID: {member.Id}");
                Console.WriteLine($"Name: {member.Name}");
                Console.WriteLine($"Email: {member.Email}");
                Console.WriteLine($"Join Date: {member.JoinDate:yyyy-MM-dd}");
                Console.WriteLine("---");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while viewing members: {ex.Message}");
        }
    }

    public static void RemoveMember()
    {
        try
        {
            if (memberList.Count == 0)
            {
                Console.WriteLine("\nNo members available to remove.");
                return;
            }

            Console.Write("Enter Member ID to remove: ");
            if (!int.TryParse(Console.ReadLine(), out int memberIdToRemove))
            {
                Console.WriteLine("Invalid input. Please enter a valid Member ID.");
                return;
            }

            var memberToRemove = memberList.FirstOrDefault(m => m.Id == memberIdToRemove);
            if (memberToRemove == null)
            {
                Console.WriteLine("Member not found.");
                return;
            }

            memberList.Remove(memberToRemove);
            Console.WriteLine("Member removed successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while removing the member: {ex.Message}");
        }
    }
}