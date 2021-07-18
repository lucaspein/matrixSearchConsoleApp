using matrixSearch.Features;
using System;
using System.Collections.Generic;
using System.Linq;

namespace matrixSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var matrix = Enumerable.Empty<string>();
            var words = Enumerable.Empty<string>();
            var found = Enumerable.Empty<string>();

            if (args.Length > 0)
            {
                Console.WriteLine("with args!");
                matrix = args[0].Split(',');
                words = args[1].Split(',');
            }
            else
            {
                matrix = new string[] { "chill", "fgwio", "chill", "pqnsd", "uvdxy" };
                words = new string[] { "chill", "fgwio", "wind" };
            }           

            var finder = new WordFinder(matrix);
            found = finder.Find(words).AsEnumerable<string>();
            Console.Write("Words found order by times: ");
            Console.WriteLine(found);
            Console.ReadLine();
        }


    }
}
