using System;
using System.Collections.Generic;
using System.Linq;
using INFDTA01_1.Helper;

namespace INFDTA01_1.Strategy.Similarity
{
	public class PearsonSimilarity : SimilarityInterface
	{
		public PearsonSimilarity()
		{}

		public SortedDictionary<int, double> Compute(SortedDictionary<int, SortedDictionary<int, double>> userItems, SortedDictionary<int, double> targetUser)
		{
			var results = new SortedDictionary<int, double>();
			var targetUserAvg = targetUser.Values.Average();

			foreach (var userItem in userItems)
			{
                var corratedRatings = Normalizer.GetCorratedRatings(targetUser, userItem.Value);

                if (corratedRatings.Count() == 0) {
                    continue;
                }

				var userAverage = corratedRatings.Values.Average();

				// source: http://stackoverflow.com/a/17447920/1765404
				var sum1 = targetUser.Values.Zip(corratedRatings.Values, (x1, y1) => (x1 - targetUserAvg) * (y1 - userAverage)).Sum();

				var sumSqr1 = targetUser.Values.Sum(x => Math.Pow((x - targetUserAvg), 2.0));
				var sumSqr2 = corratedRatings.Values.Sum(y => Math.Pow((y - userAverage), 2.0));

				var result = sum1 / Math.Sqrt(sumSqr1 * sumSqr2);

				results.Add(userItem.Key, result);
			}

			return results;
		}
	}
}