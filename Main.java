import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        System.out.println("Library Management System\n");

        String actionNum = chooseAction();

        while ( !actionNum.equals("3")) {
            switch (actionNum) {
                case "1":
                    System.out.println("Registered successfully\n");
                    break;

                case "2":
                    System.out.println("Login successfully\n");
                    break;

                default:
                    System.out.println("Invalid input. Try again.\n");
            }

            actionNum = chooseAction();
        }

        System.out.println("Successfully exited!");

    }

    public static String chooseAction() {
        System.out.println("1. Register");
        System.out.println("2. Login");
        System.out.println("3. Exit");

        System.out.println("\nEnter your choice");
        Scanner input = new Scanner(System.in);
        String choice = input.next();

        return choice;
    }
}
