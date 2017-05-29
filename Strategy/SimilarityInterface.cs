using System;
using System.Collections.Generic;

namespace INFDTA01_1.Strategy
{
	public interface SimilarityInterface
	{
		SortedDictionary<int, double> Compute(SortedDictionary<int, double> targetUser, SortedDictionary<int, SortedDictionary<int, double>> userItems);
	}
}