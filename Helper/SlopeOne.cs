using System;
using System.Collections.Generic;
using INFDTA01_1.DataType;

namespace INFDTA01_1.Helper {
    
    public static class SlopeOne {
        
        public static double Compute(
            SortedDictionary<int, double> userRatings,
            int targetItem,
            Matrix<double> deviations,
            Matrix<int> frequencies
        ) {

            double prediction = 0.0;
            int frequency = 0;

            foreach (var userRating in userRatings) {
                var ratingFrequency = frequencies[targetItem, userRating.Key];

                if (ratingFrequency != 0) {
                    prediction += (deviations[targetItem, userRating.Key] + userRating.Value) * ratingFrequency;
                    frequency += ratingFrequency;
                }
            }

            return (double) prediction / frequency;
        }
    }
}