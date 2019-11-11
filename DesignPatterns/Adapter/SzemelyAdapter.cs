using AdapterExternal;

namespace Adapter
{
    internal class SzemelyAdapter : Szemely
    {
        public SzemelyAdapter(SapPerson sapPerson)
        {
            Név = $"{sapPerson.LastName} {sapPerson.FirstName}";
            SzületésiÉv = sapPerson.BornAt.Year;
            FizetésForintban = sapPerson.SalaryInEuro * 300;
        }
    }
}