using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace INFDTA01_1.Helper
{
	public class Normalizer
	{
		/// <summary>
		/// Equalize the rankings of specified targetUser and userItems.
		/// </summary>
		/// <returns>The equalize.</returns>
		/// <param name="targetUser">Target user.</param>
		/// <param name="userItems">User items.</param>
		public SortedDictionary<int, SortedDictionary<int, float>> equalize(SortedDictionary<int, float> targetUser, SortedDictionary<int, SortedDictionary<int, float>> userItems)
		{
			// remove users that do not contain all our targetUser's rankings
			var userItemsToRemove = new ArrayList();
			foreach (var ranking in targetUser)
			{
				foreach (var userItem in userItems)
				{
					if (!userItem.Value.ContainsKey(ranking.Key))
					{
						userItemsToRemove.Add(userItem.Key);
					}
				}
			}

			foreach (var key in userItemsToRemove) {
				userItems.Remove((int) key);
			}

			// remove rankings that are not present in our targetUser
			var userRankingsToRemove = new List<KeyValuePair<int, int>>();
			foreach (var userItem in userItems)
			{
				foreach (var ranking in userItem.Value)
				{
					if (!targetUser.Keys.Contains(ranking.Key))
					{
						userRankingsToRemove.Add(new KeyValuePair<int, int>(userItem.Key, ranking.Key));
					}
				}
			}

			foreach (var userRanking in userRankingsToRemove)
			{
				userItems[userRanking.Key].Remove(userRanking.Value);
			}

			return userItems;
		}
	}
}