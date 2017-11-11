using System.Collections.Generic;

namespace Markdown
{
    public class Environ
    {
        public EnvironConditions Conditions { get; set; }

        public Environ(List<List<EnvironCondition>> leftConditions, List<List<EnvironCondition>> rightConditions)
        {

        }

        public bool CheckEnviron(string input, int indexOfsymbol)
        {
        }
    }
}
