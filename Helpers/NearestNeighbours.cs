using System;
using System.Linq;
using System.Collections.Generic;

namespace INFDTA01_1.Helper
{
    public static class NearestNeighbours
    {
        public static Dictionary<int, double> Compute(SortedDictionary<int, double> similarities, float threshold, int limit = 3)
        {
            // remove threshold exceedings
            var toRemove = similarities.Where(similarity => similarity.Value < threshold)
                                       .Select(similarity => similarity.Key)
                                       .ToList();
			foreach (var key in toRemove)
			{
                similarities.Remove(key);
			}

            // sort by value & take limit
            var nearestNeighbours = similarities.OrderBy(x => x.Value).Reverse().Take(limit).ToDictionary(x => x.Key, x => x.Value);

            return nearestNeighbours;
        }
    }
}