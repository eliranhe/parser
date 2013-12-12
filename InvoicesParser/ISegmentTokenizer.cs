using System.Linq;

namespace InvoicesParser
{
    public interface ISegmentTokenizer
    {
        ITokenizedSegment Tokenize(ISegment segment);
    }

    public class SegmentTokenizer : ISegmentTokenizer
    {
        public ITokenizedSegment Tokenize(ISegment segment)
        {
            var tokens =
                segment.Lines.SelectMany(line => line.Select((c, i) => new { Char = c, Index = i }))
                .GroupBy(x => x.Index / 3)
                .Select(x => new Token(x.Select(y => y.Char).ToList()))
                .ToList();
            return new TokenizedSegment(tokens);
        }
    }
}