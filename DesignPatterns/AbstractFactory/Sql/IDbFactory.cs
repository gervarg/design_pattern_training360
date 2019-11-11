namespace AbstractFactory
{
    // This is the Abstract Factory
    internal interface IDbFactory
    {
        DbConection GetConnection();
        DbQuery GetQuery(string query);
    }
}