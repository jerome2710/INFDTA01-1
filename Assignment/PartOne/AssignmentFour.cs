﻿using System;
using System.Linq;
using System.Collections.Generic;
using INFDTA01_1.Helper;
using INFDTA01_1.Strategy;
using INFDTA01_1.Strategy.Similarity;

namespace INFDTA01_1.Assignment.PartOne {
    
    public static class AssignmentFour {
        
        public const string importFilePath = "Assets/userItem.data";
        public const int targetUserId = 4;
        public const double similarityThreshold = 0.35d;
        public const int nearestNeighboursLimit = 3;
        public static readonly int[] predictedRatingItems = { 101 };

        public static void Run() {
            // import the dataset
            var userItems = Import.DoImport(importFilePath);

            // pop our target user
            userItems.TryGetValue(targetUserId, out SortedDictionary<int, double> targetUser);
            userItems.Remove(targetUserId);

            // compute similarities
            var context = new Context(new PearsonSimilarity());
            var similarities = context.Compute(userItems, targetUser);

            // nearest neighbours
            var nearestNeighbours = NearestNeighbours.Compute(similarities, similarityThreshold, nearestNeighboursLimit);

            // predicted item ratings
            var predictedRatings = new SortedDictionary<int, double>();
            foreach (var predictedRatingItem in predictedRatingItems) {
                predictedRatings.Add(predictedRatingItem, PredictedRating.Compute(userItems, similarities, nearestNeighbours, predictedRatingItem));
            }

            Asserter.AssignmentFour(predictedRatings);
        }
    }
}