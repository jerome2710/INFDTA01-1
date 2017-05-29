using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace INFDTA01_1.Helper
{
    public static class Normalizer
    {
        public static SortedDictionary<int, double> GetCorratedRatings(SortedDictionary<int, double> targetUser, SortedDictionary<int, double> userItem)
        {
            var corratedRatings = new SortedDictionary<int, double>();

			var corratedItemIds = targetUser.Keys.Intersect(userItem.Keys);
			foreach (var userItemRanking in userItem)
			{
				if (corratedItemIds.Contains(userItemRanking.Key))
				{
					corratedRatings.Add(userItemRanking.Key, userItemRanking.Value);
				}
			}

            return corratedRatings;
        }
	}
}