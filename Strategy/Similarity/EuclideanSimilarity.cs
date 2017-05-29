using System;
using System.Linq;
using System.Collections.Generic;
using INFDTA01_1.Helper;

namespace INFDTA01_1.Strategy.Similarity
{
    public class EuclideanSimilarity : SimilarityInterface
    {
        public EuclideanSimilarity()
        {
        }

		public SortedDictionary<int, double> Compute(SortedDictionary<int, double> targetUser, SortedDictionary<int, SortedDictionary<int, double>> userItems)
		{
			var results = new SortedDictionary<int, double>();

            foreach (var userItem in userItems)
            {
                var corratedRatings = Normalizer.GetCorratedRatings(targetUser, userItem.Value);

                var sum = 0.0;
                foreach (var rating in corratedRatings)
                {
                    sum += Math.Pow(rating.Value - targetUser[rating.Key], 2);
                }

                results.Add(userItem.Key, (1 / (1 + Math.Sqrt(sum))));
            }

			return results;
		}
    }
}