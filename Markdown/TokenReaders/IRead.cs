using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Markdown.Readers
{
    public interface IRead
    {
        char Symbol { get; }
        Token Read(string input, int inputIndex);
    }
}
