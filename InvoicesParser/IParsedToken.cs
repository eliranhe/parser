namespace InvoicesParser
{
    public interface IParsedToken
    {
        bool ParsedSuccessfully { get; }
        char? Char { get; }
    }

    public class ParsedToken : IParsedToken
    {
        private readonly bool _parsedSuccessfully;
        private readonly char? _c;

        public ParsedToken(bool parsedSuccessfully, char? c)
        {
            _parsedSuccessfully = parsedSuccessfully;
            _c = c;
        }

        public bool ParsedSuccessfully
        {
            get { return _parsedSuccessfully; }

        }

        public char? Char
        {
            get { return _c; }
        }
    }
}