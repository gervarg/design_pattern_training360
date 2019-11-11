namespace Facade
{
    class PurchasingDepartment : IPurchasingDepartment
    {
        private readonly Colleague Marika = new Colleague("Marika");

        public void RequestNewDevice(params Device[] devices)
        {
            Marika.AddToDo("Buy a new ASUS Zenbook.");
            Marika.AddToDo("Buy a new Android s10.");
        }
    }
}
