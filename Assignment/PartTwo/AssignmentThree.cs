using System;
using System.Linq;
using System.Collections.Generic;
using INFDTA01_1.Helper;
using INFDTA01_1.DataType;

namespace INFDTA01_1.Assignment.PartTwo {
    
    public static class AssignmentThree {
        
        public const string importFilePath = "Assets/movielens.data";
        public const int targetUserId = 186;
        public const int itemCount = 1682;
        public const int recommendationCount = 5;

        public static void Run() {
            // import the dataset
            var userItems = Import.DoImport(importFilePath);

			// get deviations matrix
			var deviations = new Matrix<double>(itemCount, itemCount);
			var frequencies = new Matrix<int>(itemCount, itemCount);
			Deviations.Compute(userItems, itemCount, out deviations, out frequencies);

			// calculate predictions
            var targetUserPredictions = new SortedDictionary<int, double>();
			userItems.TryGetValue(targetUserId, out SortedDictionary<int, double> targetUser);

			for (int i = 0; i <= itemCount; i++) {
                if (deviations.Contains(i)) {
                    targetUserPredictions.Add(i, SlopeOne.Compute(targetUser, i, deviations, frequencies));
                }
            }

            // take top
            var topPredictions = targetUserPredictions.Take(recommendationCount);

			// check answer
			Asserter.AssignmentThree(targetUserPredictions);
        }
    }
}