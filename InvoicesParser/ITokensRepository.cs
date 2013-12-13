using System.Collections.Generic;

namespace InvoicesParser
{
    public interface ITokensRepository
    {
        bool TryGetCharacter(IToken token, out char c);
    }

    public class TokensRepository : ITokensRepository
    {
        private readonly IReadOnlyDictionary<IToken, char> _tokens;

        public TokensRepository(IEqualityComparer<IToken> equalityComparer)
        {
            _tokens = new Dictionary<IToken, char>(equalityComparer)
                          {
                              {Zero, '0'},
                              {One, '1'},
                              {Two, '2'},
                              {Three, '3'},
                              {Four, '4'},
                              {Five, '5'},
                              {Six, '6'},
                              {Seven, '7'},
                              {Eight, '8'},
                              {Nine, '9'},
                          };
        }

        private readonly IToken Zero = new Token(" _ | ||_|");
        private readonly IToken One = new Token("     |  |");
        private readonly IToken Two = new Token(" _  _||_ ");
        private readonly IToken Three = new Token(" _  _| _|");
        private readonly IToken Four = new Token("   |_|  |");
        private readonly IToken Five = new Token(" _ |_  _|");
        private readonly IToken Six = new Token(" _ |_ |_|");
        private readonly IToken Seven = new Token(" _   |  |");
        private readonly IToken Eight = new Token(" _ |_||_|");
        private readonly IToken Nine = new Token(" _ |_| _|");

        public bool TryGetCharacter(IToken token, out char c)
        {
            return _tokens.TryGetValue(token, out c);
        }
    }
}