using System;

namespace Facade
{
    // Summary:
    // Facade pattern provides a simplified interface to a complex subsystem.
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Computer
            var computer = new ComputerFacade(new Computer());
            computer.TurnOn();
            computer.TurnOff();

            // 2. Vállalatirányítási rendszer, ERP
            var companyFacade = new CompanyFacade(new PurchasingDepartment(), new AccountingDepartment(), new HrDepartment());
            companyFacade.Enter(new Colleague("Pista"));
            // Accessing subsystem elements?!
        }
    }
}
