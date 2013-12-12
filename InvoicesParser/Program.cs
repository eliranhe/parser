using Autofac;

namespace InvoicesParser
{
    class Program
    {
        static void Main(string[] args)
        {
            var containerCreator = new InvoiceParserContainerCreator();
            var container = containerCreator.GetContainer();

            var invoiceConverter = container.Resolve<IInvoiceConverter>();
            invoiceConverter.Convert(args[0], args[1]);
        }
    }
}
