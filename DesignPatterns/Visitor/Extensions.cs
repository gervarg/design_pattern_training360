namespace Visitor
{
    internal static class EmployeeExtensions
    {
        internal static int GetHolidays(this Employee employee)
        {
            int holidays = 20;

            if (25 <= employee.Age && employee.Age < 30)
            {
                holidays += 3;
            }
            else if (30 <= employee.Age && employee.Age < 35)
            {
                holidays += 6;
            }
            else
            {
                holidays += 10;
            }

            if (employee.NumberOfChildren == 1)
            {
                holidays += 2;
            }
            else if (employee.NumberOfChildren == 2)
            {
                holidays += 5;
            }
            else if (employee.NumberOfChildren > 2)
            {
                holidays += 7;
            }

            return holidays;
        }

        internal static void SetAnnualBonus(this Developer developer)
        {
            developer.AnnualBonus = 1000;
        }

        internal static void SetAnnualBonus(this HrGeneralist hrGeneralist)
        {
            hrGeneralist.AnnualBonus = 250;
        }

        internal static void SetAnnualBonus(this Manager manager)
        {
            manager.AnnualBonus = 2000;
        }

        internal static void SetAnnualBonus(this SalesRepresentative salesRepresentative)
        {
            salesRepresentative.AnnualBonus = 2500;
        }
    }
}
