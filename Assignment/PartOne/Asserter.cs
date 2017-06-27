using System;
using System.Collections.Generic;
using System.Linq;

namespace INFDTA01_1.Assignment.PartOne {
    
    public static class Asserter {
        
        public static void Pass(string description) {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t" + description);
        }

        public static void Fail(string description) {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t" + description);
        }

        public static void AssignmentOne(SortedDictionary<int, double> similarities) {
            similarities.TryGetValue(4, out double answer);

            if (answer != 1.0) {
                Fail("Assignment 1: failed!");
            } else {
                Pass("Assignment 1: success!");
            }
        }

        public static void AssignmentTwo(SortedDictionary<int, double> similarities, string similarity) {
            var answer = new SortedDictionary<int, double>();

            switch (similarity) {
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

            if (
                similarities.Keys.Count == answer.Keys.Count &&
                similarities.Keys.All(k => answer.ContainsKey(k) && answer[k].ToString() == similarities[k].ToString())
            ) {
                Pass("Assignment 2: " + similarity + " success!");
            } else {
                Fail("Assignment 2: " + similarity + " failed!");
            }
        }

        public static void AssignmentThree(SortedDictionary<int, double> predictedRatings) {
            var answer = new SortedDictionary<int, double>();
            answer.Add(101, 2.741286897472);
            answer.Add(103, 2.67090274535989);
            answer.Add(106, 3.47705617849087);

            if (
                predictedRatings.Keys.Count == answer.Keys.Count &&
                predictedRatings.Keys.All(k => answer.ContainsKey(k) && answer[k].ToString() == predictedRatings[k].ToString())
            ) {
                Pass("Assignment 3: success!");
            } else {
                Fail("Assignment 3: failed!");
            }
        }

        public static void AssignmentFour(SortedDictionary<int, double> predictedRatings) {
            var answer = new SortedDictionary<int, double>();
            answer.Add(101, 2.63284325835078);

            if (
                predictedRatings.Keys.Count == answer.Keys.Count &&
                predictedRatings.Keys.All(k => answer.ContainsKey(k) && answer[k].ToString() == predictedRatings[k].ToString())
            ) {
                Pass("Assignment 4: success!");
            } else {
                Fail("Assignment 4: failed!");
            }
        }

        public static void AssignmentFive(SortedDictionary<int, double> predictedRatings) {
            var answer = new SortedDictionary<int, double>();
            answer.Add(101, 2.757178);
            answer.Add(103, 2.676184);

            if (
                predictedRatings.Keys.Count == answer.Keys.Count &&
                predictedRatings.Keys.All(k => answer.ContainsKey(k) && answer[k].ToString() == predictedRatings[k].ToString())
            ) {
                Pass("Assignment 5: success!");
            } else {
                Fail("Assignment 5: failed!");
            }
        }
    }
}