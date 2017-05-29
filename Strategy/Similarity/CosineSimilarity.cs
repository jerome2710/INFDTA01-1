using System;
using System.Collections.Generic;

namespace INFDTA01_1.Strategy.Similarity
{
	public class CosineSimilarity : SimilarityInterface
	{
		public CosineSimilarity()
		{}

		public SortedDictionary<int, double> Compute(SortedDictionary<int, SortedDictionary<int, double>> userItems, SortedDictionary<int, double> targetUser)
		{
			throw new NotImplementedException();
		}
    }
}