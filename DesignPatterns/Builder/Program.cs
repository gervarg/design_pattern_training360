using System;
using System.Data.SqlClient;
using System.IO;

namespace Builder
{
    // Summary:
    // The builder pattern is an object creation software design pattern 
    // with the intentions of finding a solution to the telescoping constructor anti-pattern.
    //
    // The key difference from the factory pattern is that 
    // factory pattern is to be used when the creation is a one step process 
    // while builder pattern is to be used when the creation is a multi step process.
    class Program
    {
        static void Main(string[] args)
        {            
            // 1.
            var burger = new BurgerBuilder(14)
                .AddCheese()
                .AddPepperoni()
                .AddLettuce()
                .Build();
            Console.WriteLine(burger);

            // 2. 
            var sqlConnectionStringBuilder = new SqlConnectionStringBuilder
            {
                IntegratedSecurity = true,
                InitialCatalog = "students",
                DataSource = "localhost",
                UserID = "bob",
                Password = "mypassword"
            };            
            Console.WriteLine(sqlConnectionStringBuilder.ToString());

            // 3.
            var fileNameBuilder = new FileNameBuilder()
                .AddDirectory(Directory.GetCurrentDirectory())
                .AddFileNameWithoutExtension("photo")
                .AddPrefix("user")
                .AddExtension(".jpg")
                .IsUnique(true);
            Console.WriteLine(fileNameBuilder.ToString());

            // 4.
            //System.Text.StringBuilder

            // 5. asp.net core example
        }
    }
}
