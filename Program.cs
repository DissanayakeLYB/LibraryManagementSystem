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
                    Console.WriteLine("");
                    break;

                case "2":
                    Console.WriteLine("");
                    break;

                case "3":
                    Console.WriteLine("");
                    break;

                case "4":
                    Console.WriteLine("");
                    break;

                case "5":
                    Console.WriteLine("");
                    break;

                case "6":
                    Console.WriteLine("");
                    break;

                case "7":
                    Console.WriteLine("");
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