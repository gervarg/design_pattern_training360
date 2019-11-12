using System;

namespace Facade
{
    class CompanyFacade
    {
        private readonly IPurchasingDepartment purchasingDepartment;
        private readonly IAccountingDepartment accountingDepartment;
        private readonly IHrDepartment hrDepartment;

        public CompanyFacade(IPurchasingDepartment purchasingDepartment, IAccountingDepartment accountingDepartment, IHrDepartment hrDepartment)
        {
            this.purchasingDepartment = purchasingDepartment;
            this.accountingDepartment = accountingDepartment;
            this.hrDepartment = hrDepartment;
        }

        internal void Enter(Colleague colleague)
        {
            Console.WriteLine("New colleague arrived!");
            purchasingDepartment.RequestNewDevice(new Device("laptop"), new Device("mobile"));
            accountingDepartment.IntroduceNewColleague(colleague);
            hrDepartment.KickOff(colleague);
        }

        internal void Fire(Colleague colleague)
        {
            Console.WriteLine($"Fire {colleague.Name}");
            accountingDepartment.RemoveSalary(colleague);
            hrDepartment.ExitColleague(colleague);      
            
        }
    }
}