class Program
{
    public static void Main (string[] args)
    {
        bool isRunning = true; 

        while (isRunning)
        {
            
            Console.WriteLine("Library Management System\n");
            
            Console.WriteLine("1. Register");
            Console.WriteLine("2. Login");
            Console.WriteLine("3. Exit");

            Console.Write("Enter the number: ");
            var actionNumber = Console.ReadLine();

            actionNumber?.ToString();

            switch(actionNumber)
            {
                case "1":
                    Console.WriteLine("Registered Successfully!!!\n");
                    break;

                case "2":
                    Console.WriteLine("Logged In Successfuly!!!\n");
                    break;

                case "3":
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