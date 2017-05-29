using System;
using System.Collections.Generic;
using System.Linq;

namespace INFDTA01_1.Assignment.PartOne
{
    public static class Asserter
    {
        public static void Pass(string description)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(description);
        }

        public static void Fail(string description)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(description);
        }

        public static void AssignmentOne(SortedDictionary<int, double> similarities)
        {
            similarities.TryGetValue(4, out double answer);

            if (answer != 1.0) {
                Fail("Assignment 1: failed!");
            } else {
                Pass("Assignment 1: success!");
            }
        }

        public static void AssignmentTwo(SortedDictionary<int, double> similarities, string similarity)
        {
            var answer = new SortedDictionary<int, double>();

            switch (similarity)
            {
                case "Pearson":
                    answer.Add(1, 0.99124070716193);
                    answer.Add(5, 0.924473451641905);
                    answer.Add(4, 0.893405147441564);
                    break;
                case "Cosine":
                    answer.Add(6, 0.80555004051484);
                    answer.Add(2, 0.770024275094105);
                    answer.Add(5, 0.734178651201811);
                    break;
                case "Euclidean":
                    answer.Add(5, 0.4);
                    answer.Add(3, 0.387425886722793);
                    answer.Add(4, 0.356789172325331);
                    break;
            }

            //answer.ToList().ForEach(x => Console.WriteLine(x));
            //similarities.ToList().ForEach(x => Console.WriteLine(x));

			if (
                similarities.Keys.Count == answer.Keys.Count &&
                similarities.Keys.All(k => answer.ContainsKey(k) && answer[k].ToString() == similarities[k].ToString())
            ) {
                Pass("Assignment 2: " + similarity + " success!");
            } else {
                Fail("Assignment 2: " + similarity + " failed!");
            }
        }
    }
}
