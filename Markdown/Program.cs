using System;

namespace Markdown
{
	class Program
	{
		static void Main(string[] args)
		{
            Console.WriteLine(new Md().RenderToHtml("__aaa__"));
		    Console.ReadLine();
		}
	}
}
