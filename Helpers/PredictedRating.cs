using System;
using System.Linq;
using System.Collections.Generic;

namespace INFDTA01_1.Helper
{
    public static class PredictedRating
    {
        public static double Compute(
            SortedDictionary<int, SortedDictionary<int, float>> userItems,
            SortedDictionary<int, double> similarities,
            Dictionary<int, double> nearestNeighbours,
            int predictedRatingItem
        )
        {
			// count sum for weighted values
			double sum = 0;
			foreach (var similarity in similarities)
			{
				sum += similarity.Value;
			}

            //// convert similarities to weighted values
            //var weightedSimilarities = new Dictionary<int, double>();
            //foreach (var similarity in similarities)
            //{
            //    weightedSimilarities.Add(similarity.Key, (similarity.Value / sum));
            //}

            var numerator = 0.0;
            var denominator = 0.0;
            foreach (var nearestNeighbour in nearestNeighbours)
            {
                numerator += userItems[nearestNeighbour.Key][predictedRatingItem] * similarities[nearestNeighbour.Key];
                denominator += similarities[nearestNeighbour.Key];
            }

            return (numerator / denominator);
		}
    }
}