using System;

namespace ChainOfResponsibility
{
    // Summary:
    // * It helps building a chain of objects. Request enters from one end and keeps going from object to object till it finds the suitable handler.
    // * A minta arra szolgál, hogy elkerüljük a kérelem küldőjének a fogadóhoz való kötését.
    // Ezt úgy érjük el, hogy több objektumnak is jogot adunk a kérelem kezelésére. A fogadó
    // objektumokat láncba állítjuk, amelyen a kérlem addig halad, amíg el nem ér egy objektumot,
    // ami képes a kezelésére.
    class Program
    {
        static void Main(string[] args)
        {
            //AccountExample();

            JobDistributionExample();

            // see: asp.net core middlewares
            // exceptions and their order
        }

        private static void JobDistributionExample()
        {
            var jobDistributor = new JobDistributor();
            jobDistributor.Workers.Add(new Worker("Géza", Competence.Web));
            jobDistributor.Workers.Add(new Worker("Béla", Competence.Db));
            jobDistributor.Workers.Add(new Worker("Timi", Competence.Design));
            jobDistributor.Workers.Add(new Worker("Sanyi", Competence.Db));
            jobDistributor.Workers.Add(new Worker("Eszti", Competence.Web));
            jobDistributor.Workers.Add(new Worker("Tamás", Competence.Design));

            jobDistributor.Distribute(new Job("Create landing page", Competence.Design));
            jobDistributor.Distribute(new Job("Fix layout", Competence.Design));
            jobDistributor.Distribute(new Job("Create user webapi", Competence.Web));
            jobDistributor.Distribute(new Job("Create user related store procedures.", Competence.Db));
        }

        private static void AccountExample()
        {
            // Let's prepare a chain like below
            //      Bank -> Paypal -> Bitcoin
            //
            // First priority bank
            //      If bank can't pay then paypal
            //      If paypal can't pay then bit coin

            var bank = new Bank(100); // Bank with balance 100
            var paypal = new Paypal(200); // Paypal with balance 200
            var bitcoin = new Bitcoin(300); // Bitcoin with balance 300

            bank.Successor = paypal;
            paypal.Successor = bitcoin;

            // Let's try to pay using the first priority i.e. bank
            bank.Pay(259);
        }
    }
}
