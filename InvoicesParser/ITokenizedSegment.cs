using System.Collections.Generic;

namespace InvoicesParser
{
    public interface ITokenizedSegment
    {
        IReadOnlyList<IToken> Tokens { get; }
    }

    public class TokenizedSegment : ITokenizedSegment
    {
        private readonly IReadOnlyList<IToken> _tokens;

        public TokenizedSegment(IReadOnlyList<Token> tokens)
        {
            _tokens = tokens;
        }

        public IReadOnlyList<IToken> Tokens
        {
            get { return _tokens; }
        }
    }
}