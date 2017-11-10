using System;
using System.Collections.Generic;

namespace Markdown
{
    public class EnvironConditions
    {
        public List<List<EnvironCondition>> LeftConditions { get; }
        public List<List<EnvironCondition>> RightConditions { get; }

        public EnvironConditions(List<List<EnvironCondition>> leftConditions, List<List<EnvironCondition>> rightConditions)
        {
            
        }
        private bool CompareConditions(string inputOutput, int indexOfsymbol)
        {

        }
    }
}
