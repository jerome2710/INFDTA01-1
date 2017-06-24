using System;
using System.Collections.Generic;
using System.Linq;

namespace INFDTA01_1.Assignment.PartTwo {
    
    public static class Asserter {
        
        public static void Pass(string description) {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(description);
        }

        public static void Fail(string description) {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(description);
        }

        public static void AssignmentOne(List<double> targetUserAPredictions, List<double> targetUserBPredictions) {
			var predictionsA = new List<double>();
            predictionsA.Add(2.60714285714286);
            predictionsA.Add(2.16666666666667);
            predictionsA.Add(3.17647058823529);

            var predictionsB = new List<double>();
            predictionsB.Add(2.16666666666667);
            predictionsB.Add(2.33333333333333);

            // silly C# .Equals fails, let's do it manually ---> ugly

            var fail = false || (targetUserAPredictions.Count != predictionsA.Count || targetUserBPredictions.Count != predictionsB.Count);
            if (fail) {
                Fail("Assignment 1: failed!");
                return;
            }

            for (var i = 0; i < targetUserAPredictions.Count; i++) {
                if (targetUserAPredictions[i].ToString() != predictionsA[i].ToString()) {
                    fail = true;
                }
            }

            for (var i = 0; i < targetUserBPredictions.Count; i++) {
                if (targetUserBPredictions[i].ToString() != predictionsB[i].ToString()) {
					fail = true;
				}
			}

            if (!fail) {
				Pass("Assignment 1: success!");
			} else {
				Fail("Assignment 1: failed!");
            }
        }

		public static void AssignmentTwo(List<double> targetUserPredictions) {
			var predictions = new List<double>();
			predictions.Add(2.4);
			predictions.Add(2.16666666666667);
			predictions.Add(3.05555555555556);

			// silly C# .Equals fails, let's do it manually ---> ugly

			var fail = false || (targetUserPredictions.Count != predictions.Count);
			if (fail) {
				Fail("Assignment 1: failed!");
				return;
			}

			for (var i = 0; i < targetUserPredictions.Count; i++) {
				if (targetUserPredictions[i].ToString() != predictions[i].ToString()) {
					fail = true;
				}
			}

			if (!fail) {
				Pass("Assignment 2: success!");
			} else {
				Fail("Assignment 2: failed!");
			}
		}
    }
}