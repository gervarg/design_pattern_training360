using System;
using System.Collections.ObjectModel;

namespace Visitor
{
    // Summary:
    // * Visitor pattern lets you add further operations to objects without having to modify them.
    // * The visitor design pattern is a way of separating an algorithm from an object structure on which it operates. 
    // A practical result of this separation is the ability to add new operations to existing object structures without modifying those structures. 
    // It is one way to follow the open/closed principle.
    class Program
    {
        static void Main(string[] args)
        {
            //CompanyExampleWithVisitorPattern();
            CompanyExampleWithExtensionMethods();
            try
            {
                ObservableCollection<int> o = null;
                o.Clear();
                o.AddRange(new[] { 1, 2, 3 });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);   
            }
            
        }

        private static void CompanyExampleWithVisitorPattern()
        {
            Employee developer = new Developer("Sanyi", 33) { NumberOfChildren = 1 };
            Employee hrGirl = new HrGeneralist("Eszti", 26) { NumberOfChildren = 0 };
            Employee hrLady = new HrGeneralist("Gizi", 36) { NumberOfChildren = 2 };
            Employee mrManager = new Manager("Tamás", 40) { NumberOfChildren = 0 };
            Employee mrSales = new SalesRepresentative("Józsi", 38) { NumberOfChildren = 0 };

            // What about holidays?
            Console.WriteLine("Holidays");
            IEmployeeOperation<int> getHolidays = new CalculateHolidays();
            Console.WriteLine($"{developer.Name}: {developer.Accept(getHolidays)}");
            Console.WriteLine($"{hrGirl.Name}: {hrGirl.Accept(getHolidays)}");
            Console.WriteLine($"{hrLady.Name}: {hrLady.Accept(getHolidays)}");
            Console.WriteLine($"{mrManager.Name}: {mrManager.Accept(getHolidays)}");
            Console.WriteLine($"{mrSales.Name}: {mrSales.Accept(getHolidays)}");
            Console.WriteLine();

            // What about the annual bonus?
            IEmployeeOperation setAnnualBonus = new SetBonus();
            developer.Accept(setAnnualBonus);
            hrGirl.Accept(setAnnualBonus);
            hrLady.Accept(setAnnualBonus);
            mrManager.Accept(setAnnualBonus);
            mrSales.Accept(setAnnualBonus);

            Console.WriteLine("Annual bonuses");
            Console.WriteLine($"{developer.Name}: {developer.AnnualBonus}");
            Console.WriteLine($"{hrGirl.Name}: {hrGirl.AnnualBonus}");
            Console.WriteLine($"{hrLady.Name}: {hrLady.AnnualBonus}");
            Console.WriteLine($"{mrManager.Name}: {mrManager.AnnualBonus}");
            Console.WriteLine($"{mrSales.Name}: {mrSales.AnnualBonus}");
            Console.WriteLine();


            // Visitor pattern
            // 
            // + Dinamikus lehet új funkciókat típusokhoz hozzáadni.
            // + Nem kell módosítani a meglévő osztályokat.
            // + A hasonló funkcionalitás egy helyre lesz szervezve
            //      * nem külön-külön minden osztályban implementálva
            //      * nem "teleszennyezve" az osztályokat mindenféle logikával
            //
            // - Előre fel kell készíteni a típus-hierarchiát erre
            // 
            // Alternatíva: .Net -> extension methods
        }

        private static void CompanyExampleWithExtensionMethods()
        {
            var developer = new Developer("Sanyi", 33) { NumberOfChildren = 1 };
            var hrGirl = new HrGeneralist("Eszti", 26) { NumberOfChildren = 0 };
            var hrLady = new HrGeneralist("Gizi", 36) { NumberOfChildren = 2 };
            var mrManager = new Manager("Tamás", 40) { NumberOfChildren = 0 };
            var mrSales = new SalesRepresentative("Józsi", 38) { NumberOfChildren = 0 };

            // What about holidays?
            Console.WriteLine("Holidays");
            Console.WriteLine($"{developer.Name}: {developer.GetHolidays()}");
            Console.WriteLine($"{hrGirl.Name}: {hrGirl.GetHolidays()}");
            Console.WriteLine($"{hrLady.Name}: {hrLady.GetHolidays()}");
            Console.WriteLine($"{mrManager.Name}: {mrManager.GetHolidays()}");
            Console.WriteLine($"{mrSales.Name}: {mrSales.GetHolidays()}");
            Console.WriteLine();

            // What about the annual bonus?
            Console.WriteLine("Annual bonuses");
            developer.SetAnnualBonus();
            hrGirl.SetAnnualBonus();
            hrLady.SetAnnualBonus();
            mrManager.SetAnnualBonus();
            mrSales.SetAnnualBonus();

            Console.WriteLine($"{developer.Name}: {developer.AnnualBonus}");
            Console.WriteLine($"{hrGirl.Name}: {hrGirl.AnnualBonus}");
            Console.WriteLine($"{hrLady.Name}: {hrLady.AnnualBonus}");
            Console.WriteLine($"{mrManager.Name}: {mrManager.AnnualBonus}");
            Console.WriteLine($"{mrSales.Name}: {mrSales.AnnualBonus}");
            Console.WriteLine();
        }
    }
}
