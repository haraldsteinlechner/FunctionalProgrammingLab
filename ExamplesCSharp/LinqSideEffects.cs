using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamplesCSharp
{
    internal class LinqSideEffects
    {
        // from by Erik Meijer: Erik Meijer, Fundamentalist Functional Programming, https://dl.acm.org/citation.cfm?doid=1449913.1449929
        public static void OnDemandEvaluation()
        {
            Func<int, bool> lessThan30 = x =>
            {
                Console.WriteLine($"{x} less than 30?");
                return x < 30;
            };
            Func<int, bool> moreThan20 = x =>
            {
                Console.WriteLine($"{x} more than 20?");
                return x > 20;
            };

            var q0 = new int[] { 1, 25, 40, 5, 24 }
                .Where(lessThan30);

            var q1 =
                q0.Where(moreThan20);

            foreach (var r in q1) Console.WriteLine($"{r}");
            foreach (var r in q1) Console.WriteLine($"{r}");


        }
    }
}
