using System.Linq;

namespace InvoicesParser
{
    public interface IInvoiceParser
    {
        string[] Parse(string[] inputLines);
    }

    public class InvoiceParser : IInvoiceParser
    {
        private readonly ISegmentsCreator _segmentsCreator;
        private readonly ISegmentTokenizer _segmentTokenizer;
        private readonly ISegmentParser _segmentParser;

        public InvoiceParser(ISegmentsCreator segmentsCreator, ISegmentTokenizer segmentTokenizer, ISegmentParser segmentParser)
        {
            _segmentsCreator = segmentsCreator;
            _segmentTokenizer = segmentTokenizer;
            _segmentParser = segmentParser;
        }

        public string[] Parse(string[] inputLines)
        {
            var segments = _segmentsCreator.GetSegments(inputLines);
            var tokenizedSegments = segments.Select(segment=> _segmentTokenizer.Tokenize(segment)).ToList();
            var parsedSegments =
                tokenizedSegments.Select(tokenizedSegment => _segmentParser.Parse(tokenizedSegment)).ToList();

            return parsedSegments.Select(x => x.AsLine()).ToArray();
        }
    }
}