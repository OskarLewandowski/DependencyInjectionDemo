namespace DependencyInjectionDemo
{
    public class OperationService
    {
        public IOperationTransient TransientOperation { get; set; }
        public IOperationScoped ScopedOperation { get; set; }
        public IOperationSingleton SingletonOperation { get; set; }

        public OperationService(IOperationTransient transientOperation,
            IOperationScoped scopedOperation,
            IOperationSingleton singletonOperation)
        {
            TransientOperation = transientOperation;
            ScopedOperation = scopedOperation;
            SingletonOperation = singletonOperation;
        }
    }
}
