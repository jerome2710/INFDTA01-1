using System;
using System.Collections.Generic;

namespace INFDTA01_1.Strategy.Similarity
{
    public class EuclideanSimilarity : SimilarityInterface
    {
        public EuclideanSimilarity()
        {
        }

		public SortedDictionary<int, double> Compute(SortedDictionary<int, float> targetUser, SortedDictionary<int, SortedDictionary<int, float>> userItems)
		{
            // @TODO: do not forget 1/1+d to get the similarity

			throw new NotImplementedException();
		}
    }
}
