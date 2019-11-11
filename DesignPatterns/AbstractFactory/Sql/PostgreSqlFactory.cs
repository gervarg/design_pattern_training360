namespace AbstractFactory
{
    internal class PostgreSqlFactory : IDbFactory
    {
        public DbConection GetConnection()
        {
            return new PostgreSqlConnection();
        }

        public DbQuery GetQuery(string query)
        {
            return new PostgreSqlQuery(query);
        }
    }
}