using System;

namespace TemplateMethod
{
    class Program
    {
        // Summary
        // Template method defines the skeleton of how a certain algorithm could be performed, 
        // but defers the implementation of those steps to the children classes.
        static void Main(string[] args)
        {
            new DotNetCicdPipeline().Run();
            
            Console.WriteLine();
            
            new NodeJsCicdPipeline().Run();
        }
    }
}
