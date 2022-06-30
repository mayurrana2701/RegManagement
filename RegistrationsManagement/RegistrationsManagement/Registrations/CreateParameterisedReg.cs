using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationsManagement.Registrations
{
    internal class CreateParameterisedReg
    {
        public static string CoreGrade = "";
        public static string SpecialismGrade = "";
        public static string Answer = "";
        public static string RegistrationYear = "";
        public static void CreateParamRegistration()
        {

            Console.WriteLine("\r\nWhich year would do you want the registration for? (2020 or 2021): \n");
            RegistrationYear = Convert.ToString(Console.ReadLine());

            while ((RegistrationYear != "2020") && (RegistrationYear != "2021"))
            {
                Console.WriteLine("\r\nPlease enter either 2020 or 2021 only: \n");
                RegistrationYear = Convert.ToString(Console.ReadLine());
            }

            Console.WriteLine("\r\nWould you like to add a core result?: (Y or N) \n");
            Answer = Convert.ToString(Console.ReadLine());

            if (Answer == "Y")
            {
                Console.WriteLine("Choose an option from the following list:");
                Console.WriteLine("\tA*");
                Console.WriteLine("\tA");
                Console.WriteLine("\tB");
                Console.WriteLine("\tC");
                Console.WriteLine("\tD");
                Console.WriteLine("\tE");
                Console.WriteLine("\tU");
                Console.Write("Please select an option: ");
                CoreGrade = Convert.ToString(Console.ReadLine());
                Console.Write("\r\nCore Grade: " + CoreGrade);
            }
            else 
            {
                CoreGrade = "N";
                Console.Write("\r\nCore Grade: " + CoreGrade);
            }

            Console.WriteLine("\r\nWould you like to add a specialism result?: (Y or N) \n");

            Answer = Convert.ToString(Console.ReadLine());

            if (Answer == "Y")
            {
                Console.WriteLine("Choose an option from the following list:");
                Console.WriteLine("\tD - Distinciton");
                Console.WriteLine("\tM - Merit");
                Console.WriteLine("\tP - Pass");
                Console.WriteLine("\tU - Unclassified");
                Console.Write("Please select an option: ");
                SpecialismGrade = Convert.ToString(Console.ReadLine());
                Console.Write("\r\nSpecialism Grade: " + SpecialismGrade + "\n");
            }
            else
            {
                SpecialismGrade = "N";
                Console.Write("\r\nSpecialism Grade: " + SpecialismGrade + "\n");
            }

            CreateRegistrations.CreateRegistrationsParameterised(CoreGrade, SpecialismGrade, RegistrationYear);
        }
    }
}
