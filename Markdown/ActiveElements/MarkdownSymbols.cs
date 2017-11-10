using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Markdown.Parsers;

namespace Markdown
{
    public static class MarkdownSymbols
    {
        // Тут блоковые символы Маркдауна
        public static Dictionary<char, IParse> MdSymbols { get; }
    }
}
