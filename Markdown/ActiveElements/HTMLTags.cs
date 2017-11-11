using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Markdown
{
    public static class HTMLTags
    {
        // Тут HTML теги
        public static readonly string[] Bold = {"<strong>", "</strong>"};

        public static readonly string[] Italic = {"<em>", "</em>"};

        public static readonly string[] Code = {"<code>", "</code>"};

        public static readonly string[] Horizontal = {"<hr />"};
    }
}
