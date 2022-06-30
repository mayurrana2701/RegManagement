using RegistrationsManagement.Registrations;

//int num1 = 0;

DisplayMenu.DisplayMenu1();

//void DisplayMenu()
//{
//    // Display title as the C# console calculator app.
//    Console.WriteLine("\r");
//    Console.WriteLine("Registration Management\r");
//    Console.WriteLine("------------------------\n");

//    // Ask the user to choose an option.
//    Console.WriteLine("Choose an option from the following list:");
//    Console.WriteLine("\t1 - Create Registrations");
//    Console.WriteLine("\t2 - Delete All Registrations");
//    Console.WriteLine("\t3 - Delete A Single Registration");
//    Console.WriteLine("\t4 - Exit Application");
//    Console.Write("Please select an option: ");


//    switch (Console.ReadLine())
//    {
//        case "1":
//            // Ask the user to type the first number.
//            Console.WriteLine("Type the number of registrations you wish to create, and then press Enter");
//            num1 = Convert.ToInt32(Console.ReadLine());
//            Console.WriteLine("You chose: " + num1);
//            CreateRegistrations.CreateRegistrationsMethod(num1);
//            Console.WriteLine("Your " + num1 + " registration/s have been created");
//            break;
//        case "2":
//            SqlQueries.DeleteFromRegistrationTables();
//            Console.WriteLine("All of the registrations within the Test Environment have now been deleted");
//            break;
//        case "3":
//            Console.WriteLine("Type the ULN of the registration you want to delete and then press Enter");
//            string num3 = Convert.ToString(Console.ReadLine());
//            Console.WriteLine("You entered ULN: " + num3);
//            SqlQueries.DeleteSingleRegistration(num3);
//            Console.WriteLine("Your registration with ULN: " + num3 + " has been deleted");
//            DisplayMenu();
//            break;
//        case "4":
//            break;
//    }


    // Wait for the user to respond before closing.
    Console.Write("Press any key to close the app...");
    Console.ReadKey();
//}