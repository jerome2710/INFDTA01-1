﻿using System;
using System.Collections.Generic;

namespace INFDTA01_1.Strategy
{
	public interface SimilarityInterface
	{
		SortedDictionary<int, double> compute(SortedDictionary<int, float> targetUser, SortedDictionary<int, SortedDictionary<int, float>> userItems);
	}
}