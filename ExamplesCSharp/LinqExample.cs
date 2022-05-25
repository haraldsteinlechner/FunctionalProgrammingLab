using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamplesCSharp
{
    internal class LinqExample
    {
        // prints all small files (<10 lines)
        public static void RunLinqExample(string path)
        {
            // recursively enumerate all files in path which have .cs file ending
            var files = Directory.EnumerateFiles(path, "*.cs", SearchOption.AllDirectories);

            var smallFiles =
                 files
                 .Select(filePath =>
                    {
                        // could be done more efficiently? how?
                        var lineCount = File.ReadAllLines(filePath).Length;
                        // remember the filePath and return lineCount as tuple
                        return (filePath, lineCount);
                    }
                  )
                 // filter small files using the lineCount
                 .Where((path, lineCount) => lineCount < 10);

            foreach(var (filePath,lineCount) in smallFiles)
            {
                Console.WriteLine($"{filePath} contains just {lineCount} lines");
            }
        }

        // count all small files (<10 lines)
        public static void CountSmallFiles(string path)
        {
            // recursively enumerate all files in path which have .cs file ending
            var files = Directory.EnumerateFiles(path, "*.cs", SearchOption.AllDirectories);

            var smallFiles =
                 files
                 .Select(filePath =>
                 {
                     // could be done more efficiently? how?
                     var lineCount = File.ReadAllLines(filePath).Length;
                     // remember the filePath and return lineCount as tuple
                     return (filePath, lineCount);
                 }
                  )
                 // filter small files using the lineCount
                 .Where((path, lineCount) => lineCount < 10)
                 .Count();

            Console.WriteLine($"there are {smallFiles} small files");
        }

        // print all small files sorted alphabetically. only use the first 10
        public static void OnDemandEvaluation(string path)
        {
            // recursively enumerate all files in path which have .cs file ending
            var files = Directory.EnumerateFiles(path, "*.cs", SearchOption.AllDirectories);

            var smallFiles =
                 files
                 .Select(filePath =>
                     {
                         // could be done more efficiently? how?
                         var lineCount = File.ReadAllLines(filePath).Length;
                         // remember the filePath and return lineCount as tuple
                         return (filePath, lineCount);
                     }
                  )
                 // filter small files using the lineCount
                 .Where((path, lineCount) => lineCount < 10)
                 .Take(10);


            foreach (var (filePath, lineCount) in smallFiles)
            {
                Console.WriteLine($"{filePath} contains just {lineCount} lines");
            }
        }
    }
}
