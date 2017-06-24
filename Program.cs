using System;

namespace INFDTA01_1
{
	class MainClass
	{
		public static void Main(string[] args)
		{
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n Part One: User-Item \n");

            Assignment.PartOne.AssignmentOne.Run();
            Assignment.PartOne.AssignmentTwo.Run();
            Assignment.PartOne.AssignmentThree.Run();
            Assignment.PartOne.AssignmentFour.Run();
            Assignment.PartOne.AssignmentFive.Run();
            //Assignment.PartOne.AssignmentSix.Run();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n Part Two: Item-Item \n");

            Assignment.PartTwo.AssignmentOne.Run();
            Assignment.PartTwo.AssignmentTwo.Run();
            //Assignment.PartTwo.AssignmentThree.Run();
		}
	}
}