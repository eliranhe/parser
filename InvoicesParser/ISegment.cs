using System.Collections.Generic;

namespace InvoicesParser
{
    public interface ISegment
    {
        IReadOnlyList<string> Lines { get; }
    }

    public class Segment : ISegment
    {
        private readonly IReadOnlyList<string> _lines;

        public Segment(IReadOnlyList<string> lines)
        {
            _lines = lines;
        }

        public IReadOnlyList<string> Lines
        {
            get { return _lines; }
        }
    }
}