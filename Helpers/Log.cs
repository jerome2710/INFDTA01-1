using System;
using System.Collections.Generic;

namespace INFDTA01_1
{
	public static class Log
	{
		/// <summary>
		/// Logs the result.
		/// </summary>
		/// <param name="resultSet">Result set.</param>
		public static void DoLog(Dictionary<int, Dictionary<int, float>> resultSet)
		{
			foreach (var result in resultSet)
			{
				Console.WriteLine("\t Logging result for: " + result.Key);

				foreach (var value in result.Value)
				{
					Console.WriteLine("\t" + value);
				}
			}
		}
	}
}