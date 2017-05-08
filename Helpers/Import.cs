using System.Collections.Generic;

namespace INFDTA01_1
{
	public static class Import
	{
		public const string ImportFilePath = "Assets/userItem.data";

		/// <summary>
		/// Import the data from the given file path and put in a Dictionary.
		/// </summary>
		/// <returns>The data as a Dictionary.</returns>
		public static Dictionary<int, Dictionary<int, float>> DoImport()
		{
			System.Console.WriteLine("Importing data-set...");

			Dictionary<int, Dictionary<int, float>> userItems = new Dictionary<int, Dictionary<int, float>>();

			string[] lines = System.IO.File.ReadAllLines(ImportFilePath);
			foreach (string line in lines) {

				string[] lineValues = line.Split(',');
				int userId = int.Parse(lineValues[0]);
				int productId = int.Parse(lineValues[1]);
				float score = float.Parse(lineValues[2]);

				if (!userItems.ContainsKey(userId)) {
					userItems.Add(userId, new Dictionary<int, float>());
				}

				userItems[userId][productId] = score;
			}

			return userItems;
		}
	}
}
