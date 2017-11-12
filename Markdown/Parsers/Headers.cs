using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Markdown.Parsers
{
    public class Headers : IParseable
    {
        public Token Parse(string input, int inputIndex)
        {
            var headerToken = UntillStopSymbol.Parse(input, inputIndex + 1, '\n');
            headerToken.Type = Token.TokenType.Header;
            return headerToken;
        }
    }
}