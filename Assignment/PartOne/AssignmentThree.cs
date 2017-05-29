﻿using System;
using System.Collections.Generic;
using INFDTA01_1.Helper;
using INFDTA01_1.Strategy;
using INFDTA01_1.Strategy.Similarity;

namespace INFDTA01_1.Assignment.PartOne
{
	public static class AssignmentThree
	{
        public const string ImportFilePath = "Assets/userItem.data";
		public const int targetUserId = 7;
		public const double similarityThreshold = 0.35d;
		public const int nearestNeighboursLimit = 3;
        public static readonly int[] predictedRatingItems = { 101, 103, 106 };

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

			// nearest neighbours
			var nearestNeighbours = NearestNeighbours.Compute(similarities, similarityThreshold, nearestNeighboursLimit);

			// predicted item ratings
            //foreach (var predictedRatingItem in predictedRatingItems)
            //{
            //    var predictedRating = PredictedRating.Compute(userItems, similarities, nearestNeighbours, predictedRatingItem);
            //    Console.WriteLine("Predicted rating for user " + targetUserId + " on item " + predictedRatingItem + ": " + predictedRating);
            //}

			//Asserter.AssignmentTwo(sortedNearestNeighbours, strategy.Key);
		}
	}
}