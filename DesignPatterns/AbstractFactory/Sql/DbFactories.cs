using System;

namespace AbstractFactory
{
    internal class DbFactories
    {
        internal static IDbFactory GetFactory(char code)
        {
            if (code == 'M')
            {
                return new MySqlFactory();
            }
            else if (code == 'P')
            {
                return new PostgreSqlFactory();
            }
            else
            {
                throw new Exception($"Unknown code: {code}");
            }
        }
    }
}