using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Markdown
{
	class Program
	{
		static void Main(string[] args)
		{
		    Console.WriteLine(new Md().RenderToHtml("test\\_lol\\_d"));
		    Console.ReadLine();
		}
	}
}
