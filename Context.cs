using System;
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
		public void compute()
		{
			this._similarityInterface.compute();
		}
	}
}
