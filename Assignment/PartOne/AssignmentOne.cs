using System;
using System.Collections.Generic;
using INFDTA01_1.Helper;
using INFDTA01_1.Strategy.Similarity;

namespace INFDTA01_1.Assignment.PartOne
{
    public static class AssignmentOne
    {
        public const string ImportFilePath = "Assets/userItem.data";
        public const int targetUserId = 3;

        public static void Run()
		{
			// import the dataset
			var userItems = Import.DoImport();

			// pop our target user
			userItems.TryGetValue(targetUserId, out SortedDictionary<int, double> targetUser);
			userItems.Remove(targetUserId);

			// compute similarities
			var context = new Context(new PearsonSimilarity());
            var similarities = context.Compute(userItems, targetUser);

			Asserter.AssignmentOne(similarities);
		}
    }
}