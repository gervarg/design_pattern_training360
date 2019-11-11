using System;
using System.Diagnostics;
using WebApp.Models;

namespace WebApp.Services
{
    public class OperationService : IDisposable
    {
        // Services can be resolved by 
        // - Constructor injection (recommended)
        // - IServiceProvider
        // - ActivatorUtilities
        // Ctor can accept args not provided by DI but must have default values.
        // Ctor must be public.
        public OperationService(
            IOperationTransient transientOperation,
            IOperationScoped scopedOperation,
            IOperationSingleton singletonOperation,
            IOperationSingletonInstance instanceOperation)
        {
            Debug.WriteLine($"Create {this.GetType().Name}");


            TransientOperation = transientOperation;
            ScopedOperation = scopedOperation;
            SingletonOperation = singletonOperation;
            SingletonInstanceOperation = instanceOperation;
        }

        public IOperationTransient TransientOperation { get; }
        public IOperationScoped ScopedOperation { get; }
        public IOperationSingleton SingletonOperation { get; }
        public IOperationSingletonInstance SingletonInstanceOperation { get; }

        public void Dispose()
        {
            Debug.WriteLine($"Dispose {this.GetType().Name}");
        }
    }
}
