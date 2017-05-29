using System;
using System.Collections.Generic;

namespace INFDTA01_1.Strategy.Similarity
{
	public class CosineSimilarity : SimilarityInterface
	{
		public CosineSimilarity()
		{}

		public SortedDictionary<int, double> Compute(SortedDictionary<int, double> targetUser, SortedDictionary<int, SortedDictionary<int, double>> userItems)
		{
			throw new NotImplementedException();
		}
    }
}