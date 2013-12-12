namespace InvoicesParser
{
    public interface ITokenParser
    {
        IParsedToken Parse(IToken token);
    }

    public class TokenParser : ITokenParser
    {
        private readonly ITokensRepository _tokensRepository;

        public TokenParser(ITokensRepository tokensRepository)
        {
            _tokensRepository = tokensRepository;
        }

        public IParsedToken Parse(IToken token)
        {
            char c;
            var parsedSuccessfully = _tokensRepository.TryGetCharacter(token, out c);
            return new ParsedToken(parsedSuccessfully, parsedSuccessfully ? (char?)c : null);
        }
    }
}