﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Markdown.Parsers
{
    public interface IParse
    {
        Environ SymbolEnviron { get; }
        Token Parse(string input);
    }
}
