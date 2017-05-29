using System.Collections.Generic;

namespace INFDTA01_1.Helper
{
	public static class Import
	{
		public const string ImportFilePath = "Assets/userItem.data";

		/// <summary>
		/// Import the data from the given file path and put in a Dictionary.
		/// </summary>
		/// <returns>The data as a Dictionary.</returns>
		///
		public static SortedDictionary<int, SortedDictionary<int, double>> DoImport()
		{
			System.Console.WriteLine("Importing data-set...");

			var userItems = new SortedDictionary<int, SortedDictionary<int, double>>();

			var lines = System.IO.File.ReadAllLines(ImportFilePath);
			foreach (string line in lines) {

				var lineValues = line.Split(',');
				var userId = int.Parse(lineValues[0]);
				var productId = int.Parse(lineValues[1]);
				var score = double.Parse(lineValues[2]);

				if (!userItems.ContainsKey(userId)) {
					userItems.Add(userId, new SortedDictionary<int, double>());
				}

				userItems[userId][productId] = score;
			}

			return userItems;
		}
	}
}
