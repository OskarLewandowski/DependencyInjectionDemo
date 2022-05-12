using Microsoft.AspNetCore.Mvc;

namespace DependencyInjectionDemo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OperationController : ControllerBase
    {
        private readonly OperationService _operationService;
        private readonly IOperationTransient _operationTransient;
        private readonly IOperationScoped _operationScoped;
        private readonly IOperationSingleton _operationSingleton;

        public OperationController(OperationService operationService,
            IOperationTransient operationTransient,
            IOperationScoped operationScoped,
            IOperationSingleton operationSingleton)
        {
            _operationService = operationService;
            _operationTransient = operationTransient;
            _operationScoped = operationScoped;
            _operationSingleton = operationSingleton;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var model = new
            {
                ControllerDependecies = new
                {
                    Transient = _operationTransient.OperationId,
                    Scoped = _operationScoped.OperationId,
                    Singelton = _operationSingleton.OperationId
                },

                ServiceDependecies = new
                {
                    Transient = _operationService.TransientOperation.OperationId,
                    Scoped = _operationService.ScopedOperation.OperationId,
                    Singelton = _operationService.SingletonOperation.OperationId
                }
            };

            return Ok(model);
        }
    }
}
