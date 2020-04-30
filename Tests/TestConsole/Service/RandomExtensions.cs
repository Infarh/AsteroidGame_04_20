using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole.Service
{
    internal static class RandomExtensions
    {
        public static List<int> GetValues(this Random rnd, int Count, int Min, int Max)
        {
            var result = new List<int>(Count);

            for (var i = 0; i < Count; i++)
                result.Add(rnd.Next(Min, Max));

            return result;
        }

        public static TValue GetValue<TValue>(this Random rnd, params TValue[] Values)
        {
            return Values[rnd.Next(0, Values.Length)];
        }
    }
}
