using System;
using System.IO;

namespace InvoicesParser
{
    public interface IInvoiceConverter
    {
        void Convert(string inputFilename, string outputFilename);
    }

    public class InvoiceConverter : IInvoiceConverter
    {
        private readonly IInvoiceParser _invoiceParser;

        public InvoiceConverter(IInvoiceParser invoiceParser)
        {
            _invoiceParser = invoiceParser;
        }

        public void Convert(string inputFilename, string outputFilename)
        {
            if (!File.Exists(inputFilename))
                throw new ArgumentException("Filename does not exist.", "inputFilename");

            var inputLines = File.ReadAllLines(inputFilename);
            var parsedOutputLines = _invoiceParser.Parse(inputLines);
            File.WriteAllLines(outputFilename, parsedOutputLines);
        }

    }
}