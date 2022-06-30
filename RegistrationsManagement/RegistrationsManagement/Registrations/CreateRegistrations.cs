using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationsManagement.Registrations
{
    internal class CreateRegistrations
    {
        public static void CreateRegistrationsMethod(int number)
        {

            for (int i = 0; i < number; i++)
            {
                var uln = UlnHelper.GenerateUln().ToString();
                SqlQueries.CreateDbRegWithIpForLrs(uln, 3);
            }


        }

        public static void CreateRegistrationsParameterised(string CoreGrade, string SpecialismGrade, string Year)
        {         
            var uln = UlnHelper.GenerateUln().ToString();
            SqlQueriesParameterised.CreateRegistration(uln, CoreGrade, SpecialismGrade, Year);
        }
    }
}
