using System.Collections.Generic;
using System.Linq;

namespace InvoicesParser
{
    public interface IInvoice
    {
        string AsLine();
    }

    public class Invoice : IInvoice
    {
        private readonly IReadOnlyList<IParsedToken> _parsedTokens;

        public Invoice(IReadOnlyList<IParsedToken> parsedTokens)
        {
            _parsedTokens = parsedTokens;
        }

        public string AsLine()
        {
            var invoiceNumber = new string(_parsedTokens.Select(t => t.ParsedSuccessfully ? t.Character : '?').ToArray());
            if (IsLegal)
                return invoiceNumber;
            return invoiceNumber + " ILLEGAL";
        }

        private bool IsLegal
        {
            get { return _parsedTokens.All(x => x.ParsedSuccessfully); }
        }
    }
}