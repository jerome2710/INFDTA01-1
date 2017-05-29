using System;
using System.Collections.Generic;

namespace INFDTA01_1.Strategy
{
	public interface SimilarityInterface
	{
		SortedDictionary<int, double> Compute(SortedDictionary<int, float> targetUser, SortedDictionary<int, SortedDictionary<int, float>> userItems);
	}
}