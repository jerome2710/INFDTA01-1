using System;
using System.Linq;
using System.Collections.Generic;
using INFDTA01_1.Helper;
using INFDTA01_1.Strategy.Similarity;
using INFDTA01_1.DataType;

namespace INFDTA01_1.Assignment.PartTwo {
    
    public static class AssignmentOne {
        
        public const string importFilePath = "Assets/userItem.data";
		
        public const int targetUserAId = 7;
        public static readonly int[] targetUserAItems = { 101, 103, 106 };

        public const int targetUserBId = 3;
        public static readonly int[] targetUserBItems = { 103, 105 };

        public const int itemCount = 6;

		public static void Run() {
			// import the dataset
			var userItems = Import.DoImport(importFilePath);

            // get deviations matrix
            var deviations = new Matrix<double>(itemCount, itemCount);
            var frequencies = new Matrix<int>(itemCount, itemCount);
            Deviations.Compute(userItems, itemCount, out deviations, out frequencies);



            // user A
            var targetUserAPredictions = new List<double>();
			userItems.TryGetValue(targetUserAId, out SortedDictionary<int, double> targetUserA);
            foreach (var item in targetUserAItems) {
                targetUserAPredictions.Add(SlopeOne.Compute(targetUserA, item, deviations, frequencies));
            }

			// user B
			var targetUserBPredictions = new List<double>();
			userItems.TryGetValue(targetUserBId, out SortedDictionary<int, double> targetUserB);
			foreach (var item in targetUserBItems) {
				targetUserBPredictions.Add(SlopeOne.Compute(targetUserB, item, deviations, frequencies));
			}

            // check answer
            Asserter.AssignmentOne(targetUserAPredictions, targetUserBPredictions);
		}
    }
}