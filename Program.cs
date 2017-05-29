using System;
using System.Linq;
using System.Collections.Generic;
using INFDTA01_1.Helper;
using INFDTA01_1.Strategy.Similarity;

namespace INFDTA01_1
{
	class MainClass
	{
		public const string ImportFilePath = "Assets/userItem.data";
		public const int targetUserId = 7;
        public const float similarityThreshold = 0.35f;
        public const int nearestNeighboursLimit = 3;
        public static readonly int[] predictedRatingItems = { 101, 103, 106 };

        // @TODO: fix normalisation
        // @TODO: fix prediction
        // @TODO: ask: why / when to weighten similarities?

		/// <summary>
		/// The entry point of the program, where the program control starts and ends.
		/// </summary>
		/// <param name="args">The command-line arguments.</param>
		public static void Main(string[] args)
		{
			// import the dataset
			var userItems = Import.DoImport();

            // pop our target user
            userItems.TryGetValue(targetUserId, out SortedDictionary<int, float> targetUser);
            userItems.Remove(targetUserId);

			// compute similarities
            var context = new Context(new PearsonSimilarity());
			var similarities = context.Compute(targetUser, userItems);

            // nearest neighbours
            var nearestNeighbours = NearestNeighbours.Compute(similarities, similarityThreshold, nearestNeighboursLimit);

            // log
            Log.DoLog(nearestNeighbours);

    //        // predicted item ratings
    //        foreach (var predictedRatingItem in predictedRatingItems)
    //        {
				//var predictedRating = PredictedRating.Compute(userItems, similarities, nearestNeighbours, predictedRatingItem);
				//Console.WriteLine("Predicted rating for user " + targetUserId + " on item " + predictedRatingItem + ": " + predictedRating);
            //}
		}
	}
}