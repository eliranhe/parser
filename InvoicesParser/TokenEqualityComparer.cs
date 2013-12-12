using System.Collections.Generic;

namespace InvoicesParser
{
    public class TokenEqualityComparer : IEqualityComparer<IToken>
    {
        public bool Equals(IToken x, IToken y)
        {
            return x.TokenString == y.TokenString;
        }

        public int GetHashCode(IToken obj)
        {
            return obj.TokenString.GetHashCode();
        }
    }
}