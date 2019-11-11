using System.Diagnostics;
using WebApp.Services;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ServiceLifetimeController : Controller
    {
        private readonly OperationService operationService;
        private readonly IOperationTransient transientOperation;
        private readonly IOperationScoped scopedOperation;
        private readonly IOperationSingleton singletonOperation;
        private readonly IOperationSingletonInstance singletonInstanceOperation;

        public ServiceLifetimeController(
            OperationService operationService,
            IOperationTransient transientOperation,
            IOperationScoped scopedOperation,
            IOperationSingleton singletonOperation,
            IOperationSingletonInstance instanceOperation)
        {
            Debug.WriteLine($"Create {this.GetType().Name}");

            this.operationService = operationService;
            this.transientOperation = transientOperation;
            this.scopedOperation = scopedOperation;
            this.singletonOperation = singletonOperation;
            this.singletonInstanceOperation = instanceOperation;
        }

        public IActionResult Index()
        {
            return View(new ServiceLifetimeSamples
            { 
                FromService = new ServiceLifetimeValues
                {
                    Transient = operationService.TransientOperation.OperationId.ToString(),
                    Scoped = operationService.ScopedOperation.OperationId.ToString(),
                    Singleton = operationService.SingletonOperation.OperationId.ToString(),
                    SingletonInstance = operationService.SingletonInstanceOperation.OperationId.ToString(),
                },
                FromController = new ServiceLifetimeValues
                {
                    Transient = transientOperation.OperationId.ToString(),
                    Scoped = scopedOperation.OperationId.ToString(),
                    Singleton = singletonOperation.OperationId.ToString(),
                    SingletonInstance = singletonInstanceOperation.OperationId.ToString(),
                }
            });
        }

        protected override void Dispose(bool disposing)
        {
            Debug.WriteLine($"Dispose {this.GetType().Name}");
            base.Dispose(disposing);
        }
    }

    public struct ServiceLifetimeSamples
    {
        public ServiceLifetimeValues FromService { get; set; }

        public ServiceLifetimeValues FromController { get; set; }
    }

    public struct ServiceLifetimeValues
    {
        public string Transient { get; set; }
        public string Scoped { get; set; }
        public string Singleton { get; set; }
        public string SingletonInstance { get; set; }
    }
}