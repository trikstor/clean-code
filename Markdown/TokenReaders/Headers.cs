using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Markdown.Readers;

namespace Markdown.Parsers
{
    public class Headers : IReadable
    {
        public Token Read(string input, int inputIndex)
        {
            var headerToken = AbstractReader.Reader(input, inputIndex + 1, '\n');
            headerToken.Type = Token.TokenType.Header;
            return headerToken;
        }
    }
}