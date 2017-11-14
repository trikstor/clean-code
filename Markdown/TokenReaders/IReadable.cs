using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Markdown.Readers
{
    public interface IReadable
    {
        Token Read(string input, int inputIndex);
    }
}
