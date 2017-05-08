using System;
using System.Collections.Generic;
using INFDTA01_1.Strategy.Similarity;

namespace INFDTA01_1
{
	class MainClass
	{
		public const string ImportFilePath = "Assets/userItem.data";

		/// <summary>
		/// The entry point of the program, where the program control starts and ends.
		/// </summary>
		/// <param name="args">The command-line arguments.</param>
		public static void Main(string[] args)
		{
			Context context;
			Dictionary<int, Dictionary<int, float>> userItems;

			// import the dataset
			userItems = Import.DoImport();

			// @TODO: do some magic here
			context = new Context(new PearsonSimilarity());
			context.compute();

			// log the result
			Log.DoLog(userItems);
		}
	}
}