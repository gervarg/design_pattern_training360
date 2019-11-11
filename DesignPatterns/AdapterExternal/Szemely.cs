namespace AdapterExternal
{
    public class Szemely
    {
        public string Név { get; set; }

        public int SzületésiÉv { get; set; }

        public decimal FizetésForintban { get; set; }

        public override string ToString()
        {
            return $"{Név,-20}{SzületésiÉv,-15}{FizetésForintban,-6:N0} HUF";
        }
    }
}