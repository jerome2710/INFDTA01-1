using System;
using System.Linq;
using System.Collections.Generic;
using INFDTA01_1.Helper;
using INFDTA01_1.Strategy.Similarity;

namespace INFDTA01_1.Assignment.PartOne
{
    public static class AssignmentOne
    {
        public const string ImportFilePath = "Assets/userItem.data";
        public const int targetUserAId = 2;
        public const int targetUserBId = 3;

        public static void Run()
		{
			// import the dataset
			var userItems = Import.DoImport();

			// pop our target user
            userItems.TryGetValue(targetUserAId, out SortedDictionary<int, double> targetUserA);
            userItems.TryGetValue(targetUserBId, out SortedDictionary<int, double> targetUserB);

            var targetUserDict = new SortedDictionary<int, SortedDictionary<int, double>>();
            targetUserDict.Add(0, targetUserA);

			// compute similarities
			var context = new Context(new PearsonSimilarity());
            var similarities = context.Compute(targetUserDict, targetUserB);

			Asserter.AssignmentOne(similarities);
		}
    }
}