using System;
using Unity;
using Unity.Injection;
using Unity.Interception;
using Unity.Interception.ContainerIntegration;
using Unity.Interception.Interceptors.InstanceInterceptors.InterfaceInterception;

namespace Decorator
{
    // Summary:
    // Decorator pattern lets you dynamically change the behavior of an object at run time 
    // by wrapping them in an object of a decorator class.
    // The decorator pattern allows behavior to be added to an individual object, 
    // without affecting the behavior of other objects from the same class. 
    // The decorator pattern is often useful for adhering to the Single Responsibility Principle, 
    // as it allows functionality to be divided between classes with unique areas of concern.
    //
    // Plusz funkcionalitás hozzáadása "elegáns" módon, értsd betartva a SRP-t.
    class Program
    {
        static void Main(string[] args)
        {
            CoffeExample();
            Console.WriteLine();

            ServiceExample();
            Console.WriteLine();
            
            InterceptorExample();
            Console.WriteLine();
        }

        private static void CoffeExample()
        {
            ICoffee someCoffee = new SimpleCoffee();
            Console.WriteLine(someCoffee.Cost); // 10
            Console.WriteLine(someCoffee.Description); // Simple Coffee

            someCoffee = new MilkCoffee(someCoffee);
            Console.WriteLine(someCoffee.Cost); // 12
            Console.WriteLine(someCoffee.Description); // Simple Coffee, milk

            someCoffee = new WhippedCoffee(someCoffee);
            Console.WriteLine(someCoffee.Cost); // 17
            Console.WriteLine(someCoffee.Description); // Simple Coffee, milk, whip

            someCoffee = new VanillaCoffee(someCoffee);
            Console.WriteLine(someCoffee.Cost); // 20
            Console.WriteLine(someCoffee.Description); // Simple Coffee, milk, whip, vanilla
        }

        private static void ServiceExample()
        {
            ICurrencyService currencyService = new LoggedCurrencyService(new CachedCurrencyService(new CurrencyService()));

            decimal exchangeRate1 = currencyService.GetExchangeRate("EUR");
            Console.WriteLine($"Exchange rate for EUR: {exchangeRate1}");

            Console.WriteLine();

            decimal exchangeRate2 = currencyService.GetExchangeRate("EUR");
            Console.WriteLine($"Exchange rate for EUR: {exchangeRate2}");

            // TIP: sorrend kikényszerítése interface származtatással
        }

        private static void InterceptorExample()
        {
            // https://github.com/unitycontainer/interception/issues/16
            // https://en.wikipedia.org/wiki/Cross-cutting_concern
            // Logging, exception handling, caching, authN/authZ etc.

            IUnityContainer container = new UnityContainer().AddNewExtension<Interception>();
            container.RegisterType<ICurrencyService, CurrencyService>("CurrencyService");
            container.RegisterType<ICurrencyService, LoggedCurrencyService>(
                new InjectionConstructor(container.Resolve<ICurrencyService>("CurrencyService")),
                new Interceptor<InterfaceInterceptor>(),
                new InterceptionBehavior<LoggingBehavior>(),
                new InterceptionBehavior<LoggingBehavior2>());
            
            var currencyService = container.Resolve<ICurrencyService>();

            decimal exchangeRate = currencyService.GetExchangeRate("USD");
            Console.WriteLine($"Exchange rate for USD: {exchangeRate}");
        }
    }
}
