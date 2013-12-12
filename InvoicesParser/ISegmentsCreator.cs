using System.Collections.Generic;
using System.Linq;

namespace InvoicesParser
{
    public interface ISegmentsCreator
    {
        IReadOnlyList<ISegment> GetSegments(string[] inputLines);
    }

    public class SegmentsCreator : ISegmentsCreator
    {
        public IReadOnlyList<ISegment> GetSegments(string[] inputLines)
        {
            return inputLines.Select((line, i) => new { Line = line, LineNumber = i })
                .GroupBy(x => x.LineNumber / 4)
                .Select(s => new Segment(s.Select(x => x.Line).Take(3).ToList()))
                .ToList<ISegment>();
        }
    }
}