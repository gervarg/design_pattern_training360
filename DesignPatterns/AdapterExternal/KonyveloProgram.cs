using System.Collections.Generic;

namespace AdapterExternal
{
    public class KonyveloProgram
    {
        private readonly List<Szemely> szemelyek = new List<Szemely>();

        public void SzemelyHozzaadasa(Szemely szemely)
        {
            szemelyek.Add(szemely);
        }

        public List<Szemely> SzemelyekLekérdezése()
        {
            return szemelyek;
        }
    }
}