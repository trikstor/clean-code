using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Markdown
{
    public static class BlocksDependencies
    {
        public static Dictionary<string, List<string>> Dependencies { get; }
        public static Dictionary<string, bool> BlocksConditions { get; set; }

        public static void ChangeDependence(IReplaceable block, bool condition)
        {

        }

        public static bool CheckDependence(IReplaceable block)
        {

        }
    }
}


