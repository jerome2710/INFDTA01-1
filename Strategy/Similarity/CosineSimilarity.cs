using System;
using System.Linq;
using System.Collections.Generic;

namespace INFDTA01_1.Strategy.Similarity
{
	public class CosineSimilarity : SimilarityInterface
	{
		public CosineSimilarity()
		{}

		public SortedDictionary<int, double> Compute(SortedDictionary<int, SortedDictionary<int, double>> userItems, SortedDictionary<int, double> targetUser)
		{
			var results = new SortedDictionary<int, double>();

			foreach (var userItem in userItems)
			{
                // copy ratings to prevent references
                var normalizedTargetUserRatings = new SortedDictionary<int, double>();
                var normalizedUserItemRatings = new SortedDictionary<int, double>();

                targetUser.ToList().ForEach(x => normalizedTargetUserRatings.Add(x.Key, x.Value));
                userItem.Value.ToList().ForEach(x => normalizedUserItemRatings.Add(x.Key, x.Value));

                // find missing ratings
                var missingTargetUserRatings = userItem.Value.Keys.Except(targetUser.Keys);
                var missingUserItemRatings = targetUser.Keys.Except(userItem.Value.Keys);

                // fill missing ratings with 0
                missingTargetUserRatings.ToList().ForEach(x => normalizedTargetUserRatings.Add(x, 0));
                missingUserItemRatings.ToList().ForEach(x => normalizedUserItemRatings.Add(x, 0));

                // calculate numerator
                var numerator = 0.0;
                foreach (var rating in normalizedTargetUserRatings)
                {
                    numerator += rating.Value * normalizedUserItemRatings[rating.Key];
                }

                // calculate denominators
                var denominatorA = Math.Sqrt(normalizedTargetUserRatings.Values.Select(x => Math.Pow(x, 2)).Sum());
                var denominatorB = Math.Sqrt(normalizedUserItemRatings.Values.Select(x => Math.Pow(x, 2)).Sum());

                // add result
                results.Add(userItem.Key, (numerator / (denominatorA * denominatorB)));
			}

			return results;
		}
    }
}