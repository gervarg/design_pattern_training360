using System;
using System.Data.Common;

namespace AbstractFactory
{
    // Summary:
    // To construct general lego-pieces.
    // Célja, hogy általános részegységeket gyártASSUNK le.
    class Program
    {
        static void Main(string[] args)
        {            
            // 1.
            //new DbProviderFactory().
            //DbProviderFactory dbProviderFactory = new SqlClientFactory();
            //DbProviderFactories

            // 2. 
            //IDbFactory dbFactory = new MySqlFactory();
            //IDbFactory dbFactory = new PostgreSqlFactory();
            IDbFactory dbFactory = DbFactories.GetFactory('M');
            DbConection connection = dbFactory.GetConnection();
            DbQuery query = dbFactory.GetQuery("Query database");

            Console.WriteLine(connection);
            Console.WriteLine(query);
            Console.WriteLine();

            connection.Open();
            query.Execute();
            connection.Close();

            Console.WriteLine();


            // 3.
            //IGuiFactory guiFactory = new GnomeFactory();
            IGuiFactory guiFactory = new WindowsFactory();
            IWindow window = guiFactory.CreateWindow();
            IButton button = guiFactory.CreateButton();

            window.Show();
            button.Show();
            window.Resize();
            button.Click();
        }
    }
}
