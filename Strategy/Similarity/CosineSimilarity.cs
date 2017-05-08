using System;
using System.Collections.Generic;

namespace INFDTA01_1.Strategy.Similarity
{
	public class CosineSimilarity : SimilarityInterface
	{
		public CosineSimilarity()
		{}

		public SortedDictionary<int, double> compute(SortedDictionary<int, float> targetUser, SortedDictionary<int, SortedDictionary<int, float>> userItems)
		{
			throw new NotImplementedException();
		}
	}
}