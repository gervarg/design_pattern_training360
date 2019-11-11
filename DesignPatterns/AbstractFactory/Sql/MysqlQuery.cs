namespace AbstractFactory
{
    internal class MysqlQuery : DbQuery
    {
        private string query;

        public MysqlQuery(string query)
        {
            this.query = query;
        }

        public override void Execute()
        {
            System.Console.WriteLine($"Execute mysql query: {query}");
        }

        public override string ToString()
        {
            return $"MYSQL: {query}";
        }
    }
}