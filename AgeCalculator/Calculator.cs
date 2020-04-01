using System;

namespace AgeCalculator
{
    public class Calculator
    {
        public int CalculateAge(DateTime dob, DateTime currentDate)
        {
            var age = CalculateCurrentAge(dob, currentDate);

            var exactAge = AdjustAgeIfBirthDateIsUpcoming(dob, currentDate, age);

            ThrowExceptionIfPersonIsNotBorn(exactAge);

            return exactAge;
        }

        private static int AdjustAgeIfBirthDateIsUpcoming(DateTime dob, DateTime currentDate, int exactAge)
        {
            var currentBirthDate = dob.AddYears(exactAge);

            if (currentBirthDate > currentDate)
            {
                exactAge--;
            }

            return exactAge;
        }

        private static int CalculateCurrentAge(DateTime dob, DateTime currentDate)
        {
            var exactAge = currentDate.Year - dob.Year;
            return exactAge;
        }

        private static void ThrowExceptionIfPersonIsNotBorn(int exactAge)
        {
            if (exactAge < 0)
            {
                throw new Exception("The birth date supplied suggests the person is not born yet - cannot calculate age");
            }
        }
    }
}
