namespace Facade
{
    class HrDepartment : IHrDepartment
    {
        private readonly Colleague Valika = new Colleague("Valika");

        public void ExitColleague(Colleague colleague)
        {
            Valika.AddToDo($"Make exit interview with {colleague.Name}.");
            Valika.AddToDo($"Create exit papers for {colleague.Name}.");
        }

        public void KickOff(Colleague colleague)
        {
            Valika.AddToDo($"Create new access card for {colleague.Name}.");
            Valika.AddToDo($"Send welcome email to {colleague.Name}.");
        }
    }
}
