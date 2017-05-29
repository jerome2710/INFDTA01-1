using System;
using System.Collections.Generic;

namespace INFDTA01_1.Helper
{
	public static class Log
	{
		/// <summary>
		/// Logs the result.
		/// </summary>
		/// <param name="resultSet">Result set.</param>
		public static void DoLog(Dictionary<int, double> resultSet)
		{
			foreach (var result in resultSet)
			{
				Console.WriteLine("\t User-id " + result.Key + ": " + result.Value);
			}
		}
	}
}