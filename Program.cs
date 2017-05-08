using System;
using System.Collections.Generic;

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
			// import the dataset
			Dictionary<int, Dictionary<int, float>> userItems = Import.DoImport();

			// @TODO: do some magic here

			// log the result
			Log.DoLog(userItems);
		}

		static private void EuclideanDistance()
		{ }

		static private void ManhattanDistance()
		{ }

		static private void PearsonCoefficient()
		{ }

		static private void CosineSimilarity()
		{ }
	}
}