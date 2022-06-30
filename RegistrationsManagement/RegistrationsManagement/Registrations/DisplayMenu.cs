using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegistrationsManagement.Registrations;

namespace RegistrationsManagement.Registrations
{
    internal class DisplayMenu
    {
        public static int num1 = 0;
        //parameters
        public static string CoreGrade = "";
        public static string SpecialismGrade = "";

        public static void DisplayMenu1()
        {
            // Display title for the app.
            Console.WriteLine("\r");
            Console.WriteLine("Registration Management\r");
            Console.WriteLine("------------------------\n");

            // Ask the user to choose an option.
            Console.WriteLine("Choose an option from the following list:");
            Console.WriteLine("\t1 - Create Registrations");
            Console.WriteLine("\t2 - Delete All Registrations");
            Console.WriteLine("\t3 - Delete A Single Registration");
            Console.WriteLine("\t4 - Create A Paramaterised Registration");
            Console.WriteLine("\t5 - Exit Application");
            Console.Write("Please select an option: ");


            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Type the number of registrations you wish to create, and then press Enter");
                    num1 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("You chose: " + num1);
                    CreateRegistrations.CreateRegistrationsMethod(num1);
                    Console.WriteLine("Your " + num1 + " registration/s have been created");
                    DisplayMenu1();
                    break;
                case "2":
                    SqlQueries.DeleteFromRegistrationTables();
                    Console.WriteLine("All of the registrations within the Test Environment have now been deleted");
                    break;
                case "3":
                    Console.WriteLine("Type the ULN of the registration you want to delete and then press Enter");
                    string num3 = Convert.ToString(Console.ReadLine());
                    Console.WriteLine("You entered ULN: " + num3);
                    SqlQueries.DeleteSingleRegistration(num3);
                    Console.WriteLine("Your registration with ULN: " + num3 + " has been deleted");
                    DisplayMenu1();
                    break;
                case "4":
                    Console.WriteLine("Please complete the following questions:\n");
                    CreateParameterisedReg.CreateParamRegistration();
                    break;
                case "5":
                    Console.WriteLine("\r");
                    Console.WriteLine("\r");
                    Console.WriteLine("------------------------\n");
                    Console.WriteLine("Exiting App \n");
                    Console.WriteLine("------------------------\n\n\n");
                    break;
            }
        }
    }
}
