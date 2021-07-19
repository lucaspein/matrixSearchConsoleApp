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
                words = args[1].Split(',');
                //matrix = Mock.MatrixData.GetMatrix(); //for testing only

                try
                {
                    var finder = new WordFinder(matrix);
                    found = finder.Find(words);
                    Console.WriteLine(found.Any() ? "Found words ordered by number of occurrences: " + string.Join(',', found) : "the searched words were not found");
                    Console.ReadLine();
                }
                catch
                {
                    Console.WriteLine("Some rows don't have the same number of columns as the other rows.");
                }               
            }
            else
            {
                Console.WriteLine("No input data found.");                
            }           

            
        }


    }
}
