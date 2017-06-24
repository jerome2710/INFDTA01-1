using System;
using System.Linq;
using System.Collections.Generic;
using INFDTA01_1.Helper;
using INFDTA01_1.Strategy.Similarity;
using INFDTA01_1.DataType;

namespace INFDTA01_1.Assignment.PartTwo {
    
    public static class AssignmentTwo {
        
        public const string importFilePath = "Assets/userItem.data";
		
        public const int targetUserId = 7;
        public static readonly int[] targetUserItems = { 101, 103, 106 };

        public const int itemCount = 6;

		public static void Run() {
			// import the dataset
			var userItems = Import.DoImport(importFilePath);

            userItems[3].Add(105, 4.0);

            // get deviations matrix
            var deviations = new Matrix<double>(itemCount, itemCount);
            var frequencies = new Matrix<int>(itemCount, itemCount);
            Deviations.Compute(userItems, itemCount, out deviations, out frequencies);

            // calculate predictions
            var targetUserPredictions = new List<double>();
			userItems.TryGetValue(targetUserId, out SortedDictionary<int, double> targetUser);
            foreach (var item in targetUserItems) {
                targetUserPredictions.Add(SlopeOne.Compute(targetUser, item, deviations, frequencies));
            }

            // check answer
            Asserter.AssignmentTwo(targetUserPredictions);
		}
    }
}