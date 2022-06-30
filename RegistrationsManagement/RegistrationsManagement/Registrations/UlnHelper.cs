using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegistrationsManagement.Registrations;


namespace RegistrationsManagement.Registrations
{
    internal class UlnHelper
    {
        public static long GenerateUln()
        {
            // Step 1: Get all Ulns
            var existingUlns = GetExistingUlns();
            var random = new Random();
            // Step 2: Random number Generator
            var sameUln = true;
            long result = 0;
            while (sameUln)
            {
                result = 9800000000 + random.Next(10000000, 98999999);
                sameUln = existingUlns.Contains(result);
            }
            //Console.WriteLine("Random number is: " + result);
            return result;
        }

        private static List<long> GetExistingUlns()
        {
            return SqlQueries.UlnListFromDb();
        }
    }
}
