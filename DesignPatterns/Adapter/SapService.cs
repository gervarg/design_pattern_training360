using System;

namespace Adapter
{
    internal class SapService
    {       
        internal SapPerson GetPerson(Guid empty)
        {
            return new SapPerson
            {
                FirstName = "Lajos",
                LastName = "Kovács",
                BornAt = new DateTime(1968, 04, 05),
                SalaryInEuro = 1500
            };
        }
    }
}