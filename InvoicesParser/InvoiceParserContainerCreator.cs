using Autofac;

namespace InvoicesParser
{
    public class InvoiceParserContainerCreator
    {
        public IContainer GetContainer()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterAssemblyTypes(typeof (Program).Assembly).AsImplementedInterfaces().SingleInstance();
            return containerBuilder.Build();
        }
    }
}