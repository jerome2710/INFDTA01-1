using System;
using System.Linq;
using System.Collections.Generic;
using INFDTA01_1.Helper;
using INFDTA01_1.Strategy.Similarity;

namespace INFDTA01_1
{
	class MainClass
	{
        // @TODO: fix prediction
        // @TODO: ask: why / when to weighten similarities?
		public static void Main(string[] args)
		{
            // run assignments
            Assignment.PartOne.AssignmentOne.Run();
            Assignment.PartOne.AssignmentTwo.Run();
            Assignment.PartOne.AssignmentThree.Run();
		}
	}
}