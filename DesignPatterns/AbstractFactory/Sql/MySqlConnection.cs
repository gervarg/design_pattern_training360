namespace AbstractFactory
{
    internal class MySqlConnection : DbConection
    {
        public override void Close()
        {
            System.Console.WriteLine("Close mysql connection");
        }

        public override void Open()
        {
            System.Console.WriteLine("Open mysql connection");
        }

        public override string ToString()
        {
            return $"MYSQL: Open connection";
        }
    }
}