using System;
using AdapterExternal;

namespace Adapter
{
    class Program
    {
        // Summary:
        // Adapter pattern lets you wrap an otherwise incompatible object in an adapter to make it compatible with another class.
        static void Main(string[] args)
        {
            // Example: Migrate data from one source to other.
            SapService sapService = new SapService();
            SapPerson sapPerson = sapService.GetPerson(Guid.Empty);
            
            // I can't modify that component...
            KonyveloProgram konyveloProgram = new KonyveloProgram();

            #region 1. Logic inline
            
            Szemely szemely1 = new Szemely
            {
                Név = $"{sapPerson.LastName} {sapPerson.FirstName}",
                SzületésiÉv = sapPerson.BornAt.Year,
                FizetésForintban = sapPerson.SalaryInEuro * 300
            };
            
            #endregion

            #region 2. Logic into convert method
            
            Szemely szemely2 = ConvertToSzemely(sapPerson);

            #endregion

            #region 3. Use Adapter/Wrapper pattern
            
            Szemely szemely3 = new SzemelyAdapter(sapPerson);
            
            #endregion
                        
            konyveloProgram.SzemelyHozzaadasa(szemely1);
            konyveloProgram.SzemelyHozzaadasa(szemely2);
            konyveloProgram.SzemelyHozzaadasa(szemely3);

            Console.WriteLine(string.Join(Environment.NewLine, konyveloProgram.SzemelyekLekérdezése()));
            // TIPP: also works with interfaces
        }

        private static Szemely ConvertToSzemely(SapPerson sapPerson)
        {
            return new Szemely
            {
                Név = $"{sapPerson.LastName} {sapPerson.FirstName}",
                SzületésiÉv = sapPerson.BornAt.Year,
                FizetésForintban = sapPerson.SalaryInEuro * 300
            };
        }
    }
}
