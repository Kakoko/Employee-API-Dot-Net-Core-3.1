using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.API.Helpers
{
    public static class DateTimeOffsetExtensions
    {
        public static int GetCurrentAge(this DateTimeOffset dateTimeOffset)
        {
            var currentAge = DateTime.UtcNow;
            int age = currentAge.Year - dateTimeOffset.Year;

            if(currentAge < dateTimeOffset.AddYears(age))
            {
                age--;
            }

            return age;
        }
    }
}
