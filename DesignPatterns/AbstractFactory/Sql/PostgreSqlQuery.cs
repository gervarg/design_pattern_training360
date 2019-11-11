namespace AbstractFactory
{
    internal class PostgreSqlQuery : DbQuery
    {
        private string query;

        public PostgreSqlQuery(string query)
        {
            this.query = query;
        }

        public override void Execute()
        {
            System.Console.WriteLine($"Execute postgres query: {query}");
        }

        public override string ToString()
        {
            return $"POSTGRESQL: {query}";
        }
    }
}