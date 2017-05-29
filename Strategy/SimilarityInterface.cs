using System;
using System.Collections.Generic;

namespace INFDTA01_1.Strategy
{
	public interface SimilarityInterface
	{
		SortedDictionary<int, double> Compute(SortedDictionary<int, SortedDictionary<int, double>> userItems, SortedDictionary<int, double> targetUser);
	}
}