namespace Facade
{
    interface IAccountingDepartment
    {
        void IntroduceNewColleague(Colleague colleague);
        void RemoveSalary(Colleague colleague);
    }
}