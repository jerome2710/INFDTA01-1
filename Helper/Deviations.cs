using System;
using System.Linq;
using System.Collections.Generic;
using INFDTA01_1.DataType;

namespace INFDTA01_1.Helper {

    public static class Deviations {

        public static void Compute(
            SortedDictionary<int, SortedDictionary<int, double>> userItems,
            int itemCount,
            out Matrix<double> deviations,
            out Matrix<int> frequencies
        ) {
            
            deviations = new Matrix<double>(itemCount, itemCount);
            frequencies = new Matrix<int>(itemCount, itemCount);

            foreach (var userItem in userItems) {
                foreach (var userRatingsA in userItem.Value) {
                    foreach (var userRatingsB in userItem.Value) {
                        
                        deviations[userRatingsA.Key, userRatingsB.Key] += userRatingsA.Value - userRatingsB.Value;
                        frequencies[userRatingsA.Key, userRatingsB.Key] += 1;
                    }
                }
            }

            for (int i = 1; i <= itemCount; i++) {
                var index = i + 100;
                foreach (int j in frequencies[index]) {
                    deviations[index, j] /= frequencies[index, j];
                }
            }
        }
    }
}