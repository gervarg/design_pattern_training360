namespace AbstractFactory
{
    internal class PostgreSqlConnection : DbConection
    {
        public override void Close()
        {
            System.Console.WriteLine("Close postgresql connection");
        }

        public override void Open()
        {
            System.Console.WriteLine("Open postgresql connection");
        }

        public override string ToString()
        {
            return $"POSTGRESQL: Open connection";
        }
    }
}