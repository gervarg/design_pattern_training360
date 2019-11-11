using System;
using System.Diagnostics;

namespace WebApp.Models
{
    public class Operation :    IOperationTransient,
                                IOperationScoped,
                                IOperationSingleton,
                                IOperationSingletonInstance
    {
        public Operation() : this(Guid.NewGuid())
        {            
        }

        public Operation(Guid id)
        {
            OperationId = id;
            Debug.WriteLine($"Create object with id: {OperationId}");
        }

        public Guid OperationId { get; private set; }

        public void Dispose()
        {
            Debug.WriteLine($"Dispose object with id: {OperationId}");
        }
    }

    public interface IOperation : IDisposable
    {
        Guid OperationId { get; }
    }

    public interface IOperationTransient : IOperation
    {
    }

    public interface IOperationScoped : IOperation
    {
    }

    public interface IOperationSingleton : IOperation
    {
    }

    public interface IOperationSingletonInstance : IOperation
    {
    }
}
