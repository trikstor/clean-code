﻿using System.Collections.Generic;

namespace Markdown
{
    public class Environ
    {
        public EnvironConditions OpenConditions { get; set; }
        public EnvironConditions CloseConditions { get; set; }

        public Environ(List<List<EnvironCondition>> leftConditions, List<List<EnvironCondition>> rightConditions)
        {

        }

        public bool CheckEnviron(string input, int indexOfsymbol, bool isOpenConditions)
        {
        }

        private bool CheckBoundaryEnviron(string input, int indexOfsymbol)
        {

        }
    }
}