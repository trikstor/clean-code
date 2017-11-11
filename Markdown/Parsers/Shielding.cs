﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Markdown.Parsers
{
    public class Shielding : IParseable
    {
        public Token Parse(string input, int inputIndex)
        {
            return UntillStopSymbol.Parse(input, inputIndex + 1, MarkdownSymbols.Symbols);
        }
    }
}