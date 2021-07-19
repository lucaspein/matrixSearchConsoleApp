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
            var matrix = Enumerable.Empty<string>();
            var words = Enumerable.Empty<string>();
            var found = Enumerable.Empty<string>();

            if (args.Length > 0)
            {
                Console.Clear();
                matrix = args[0].Split(',');                
                
                matrix = Mock.MatrixData.GetMatrix();

                words = args[1].Split(',');

                var finder = new WordFinder(matrix);
                found = finder.Find(words);
                                
                Console.WriteLine(found.Any()? "Words order by times: " + string.Join(',', found) : "No occurrence found.");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("No args found.");                
            }           

            
        }


    }
}
