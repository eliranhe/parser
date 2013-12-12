using System.Linq;

namespace InvoicesParser
{
    public interface ISegmentParser
    {
        IInvoice Parse(ITokenizedSegment tokenizedSegment);
    }

    public class SegmentParser : ISegmentParser
    {
        private readonly ITokenParser _tokenParser;

        public SegmentParser(ITokenParser tokenParser)
        {
            _tokenParser = tokenParser;
        }

        public IInvoice Parse(ITokenizedSegment tokenizedSegment)
        {
            var parsedTokens = tokenizedSegment.Tokens.Select(x => _tokenParser.Parse(x)).ToList();
            return new Invoice(parsedTokens);
        }
    }
}