using System.Collections.Generic;
using System.Linq;

namespace InvoicesParser
{
    public interface IToken
    {
        string TokenString { get; }
    }

    public class Token : IToken
    {
        private readonly string _tokenString;

        public Token(string tokenString)
        {
            _tokenString = tokenString;
        }

        public Token(IReadOnlyList<char> tokenChars)
            : this(new string(tokenChars.ToArray()))
        {
        }

        public string TokenString
        {
            get { return _tokenString; }
        }


    }
}