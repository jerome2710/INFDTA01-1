using System;
using System.Collections.Generic;
using INFDTA01_1.Helper;

namespace INFDTA01_1.Strategy.Similarity
{
    public class ManhattanSimilarity : SimilarityInterface
    {
        public ManhattanSimilarity()
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
				var distance = 0.0;
				foreach (var rating in userItem.Value)
				{
                    distance += Math.Abs(rating.Value - targetUser[rating.Key]);
				}

				results.Add(userItem.Key, (1 / (1 + distance)));
			}

			return results;
		}
    }
}
