namespace AbstractFactory
{
    internal class MySqlFactory : IDbFactory
    {
        public DbConection GetConnection()
        {
            return new MySqlConnection();
        }

        public DbQuery GetQuery(string query)
        {
            return new MysqlQuery(query);
        }
    }
}