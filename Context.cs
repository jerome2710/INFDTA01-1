using System;
using System.Collections.Generic;
using INFDTA01_1.Strategy;

namespace INFDTA01_1
{
	public class Context
	{
		/// <summary>
		/// The similarity interface.
		/// </summary>
		private SimilarityInterface _similarityInterface;

		/// <summary>
		/// Initializes a new instance and sets the SimilarityInterface.
		/// </summary>
		public Context(SimilarityInterface similarityInterface)
		{
			this._similarityInterface = similarityInterface;
		}

		/// <summary>
		/// Compute the similarity using the interface.
		/// </summary>
		public SortedDictionary<int, double> Compute(SortedDictionary<int, double> targetUser, SortedDictionary<int, SortedDictionary<int, double>> userItems)
		{
            return this._similarityInterface.Compute(targetUser, userItems);
		}
	}
}