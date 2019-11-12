namespace Facade
{
    class AccountingDepartment : IAccountingDepartment
    {
        private readonly Colleague Gizike = new Colleague("Gizike");
        private readonly Colleague Jolika = new Colleague("Jolika");

        public void IntroduceNewColleague(Colleague colleague)
        {
            Gizike.AddToDo($"Add to salary list: {colleague.Name}.");
            Jolika.AddToDo($"Do the social security application process for: {colleague.Name}."); // TB bejelentés
        }

        public void RemoveSalary(Colleague colleague)
        {
            Gizike.AddToDo($"Remove salary from list: {colleague.Name}.");
        }
    }
}
