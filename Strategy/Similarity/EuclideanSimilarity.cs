using System;
using System.Collections.Generic;
using INFDTA01_1.Helper;

namespace INFDTA01_1.Strategy.Similarity
{
    public class EuclideanSimilarity : SimilarityInterface
    {
        public EuclideanSimilarity()
        {
        }

		public SortedDictionary<int, double> Compute(SortedDictionary<int, float> targetUser, SortedDictionary<int, SortedDictionary<int, float>> userItems)
		{
			// make sure all users have ranked the same products
			Normalizer normalizer = new Normalizer();
			userItems = normalizer.equalize(targetUser, userItems);

			var results = new SortedDictionary<int, double>();

            foreach (var userItem in userItems)
            {
                var sum = 0.0;
                foreach (var rating in userItem.Value)
                {
                    sum += Math.Pow(rating.Value - targetUser[rating.Key], 2);
                }

                results.Add(userItem.Key, (1 / (1 + Math.Sqrt(sum))));
            }

			return results;
		}
    }
}