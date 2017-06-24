using System;
using System.Collections.Generic;

namespace INFDTA01_1.Helper {
    
    public static class Log {
        
        public static void DoLog(Dictionary<int, double> resultSet) {
            foreach (var result in resultSet) {
                Console.WriteLine("\t User-id " + result.Key + ": " + result.Value);
            }
        }
    }
}