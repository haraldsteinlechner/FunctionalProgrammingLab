using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ExamplesCSharp
{
    public static class MapReduceHandsOn
    {
        public static IEnumerable<TResult> MapReduce<TSource, TMapped, TKey, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, IEnumerable<TMapped>> map, Func<TMapped, TKey> keySelector, 
            Func<IGrouping<TKey, TMapped>, IEnumerable<TResult>> reduce)
        {
            return source.SelectMany(map).GroupBy(keySelector).SelectMany(reduce);
        }

        public static ParallelQuery<TResult> MapReduce<TSource, TMapped, TKey, TResult>(
            this ParallelQuery<TSource> source,
            Func<TSource, IEnumerable<TMapped>> map,
            Func<TMapped, TKey> keySelector,
            Func<IGrouping<TKey, TMapped>, IEnumerable<TResult>> reduce)
        {
            return source.SelectMany(map).GroupBy(keySelector).SelectMany(reduce);
        }

        static char[] delimiters =
            Enumerable.Range(0, 256).Select(i => (char)i)
            .Where(c => Char.IsWhiteSpace(c) || Char.IsPunctuation(c))
            .ToArray();

        public static void Run(string dirPath, string extension)
        {
            var files = 
                    Directory.EnumerateFiles(dirPath, "*" + extension, 
                                             SearchOption.AllDirectories);
            var counts =
                files
                .MapReduce(
                        path => File.ReadLines(path).SelectMany(line => line.Split(delimiters)),
                        word => word,
                        group => new[] { new KeyValuePair<string, int>(group.Key, group.Count()) }
                 );
            foreach (var c in counts.OrderByDescending(kvp => kvp.Value))
            {
                Console.WriteLine($"{c.Key} -> {c.Value}");
            }
        }
    }
}
