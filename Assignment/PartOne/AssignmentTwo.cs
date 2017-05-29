using System;
using System.Collections.Generic;
using INFDTA01_1.Helper;
using INFDTA01_1.Strategy;
using INFDTA01_1.Strategy.Similarity;

namespace INFDTA01_1.Assignment.PartOne
{
	public static class AssignmentTwo
	{
        public const string ImportFilePath = "Assets/userItem.data";
		public const int targetUserId = 7;
        public const double similarityThreshold = 0.35d;
		public const int nearestNeighboursLimit = 3;

		public static void Run()
		{
			// import the dataset
			var userItems = Import.DoImport();

			// pop our target user
			userItems.TryGetValue(targetUserId, out SortedDictionary<int, double> targetUser);
			userItems.Remove(targetUserId);

            var strategies = new Dictionary<string, SimilarityInterface>();
            strategies.Add("Pearson", new PearsonSimilarity());
            strategies.Add("Cosine", new CosineSimilarity());
            strategies.Add("Euclidean", new EuclideanSimilarity());

            foreach (var strategy in strategies)
            {
				// compute similarities
                var context = new Context(strategy.Value);
                var similarities = context.Compute(userItems, targetUser);

				// nearest neighbours
				var nearestNeighbours = NearestNeighbours.Compute(similarities, similarityThreshold, nearestNeighboursLimit);
				var sortedNearestNeighbours = new SortedDictionary<int, double>(nearestNeighbours);

                Asserter.AssignmentTwo(sortedNearestNeighbours, strategy.Key);
            }
		}
	}
}