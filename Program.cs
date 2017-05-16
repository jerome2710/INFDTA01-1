using System;
using System.Collections.Generic;
using INFDTA01_1.Helper;
using INFDTA01_1.Strategy.Similarity;

namespace INFDTA01_1
{
	class MainClass
	{
		public const string ImportFilePath = "Assets/userItem.data";
		public const int targetUserId = 7;

		/// <summary>
		/// The entry point of the program, where the program control starts and ends.
		/// </summary>
		/// <param name="args">The command-line arguments.</param>
		public static void Main(string[] args)
		{
			// import the dataset
			var userItems = Import.DoImport();

			// pop our target user
			SortedDictionary<int, float> targetUser;
			userItems.TryGetValue(targetUserId, out targetUser);
			userItems.Remove(targetUserId);

			// @TODO: do some magic here
			var context = new Context(new PearsonSimilarity());
			var results = context.compute(targetUser, userItems);

			// log the result
			Log.DoLog(results);
		}
	}
}