namespace InvoicesParser
{
    public interface IParsedToken
    {
        bool ParsedSuccessfully { get; }
        char Character { get; }
    }

    public class ParsedToken : IParsedToken
    {
        private readonly char? _character;

        public ParsedToken(char? character)
        {
            _character = character;
        }

        public bool ParsedSuccessfully
        {
            get { return _character.HasValue; }
        }

        public char Character
        {
            get { return _character.Value; }
        }
    }
}