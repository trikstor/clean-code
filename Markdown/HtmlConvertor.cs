using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Markdown.Token;

namespace Markdown
{
    public static class HtmlConvertor
    {

        public static string Convert(Token token)
        {
            if (token.Tag == "")
                return token.Text;
            return token.Tag == "hr" ? 
                $"<{token.Tag}/>" : $"<{token.Tag}>{token.Text}</{token.Tag}>";
        }
    }
}
