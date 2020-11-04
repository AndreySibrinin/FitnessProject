using System;
using FitnessProject.BL.Controller;

namespace FitnessProject.CMD
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("This is application about Fitness");
			
			Console.WriteLine("Input user name");
			var name = Console.ReadLine();

			Console.WriteLine("Input user gender");
			var gender = Console.ReadLine();

			Console.WriteLine("Input user date of birth");
			var birthDate = DateTime.Parse(Console.ReadLine());

			Console.WriteLine("Input user weight");
			var weight = double.Parse(Console.ReadLine());

			Console.WriteLine("Input user height");
			var height = double.Parse(Console.ReadLine());

			var userController = new UserController(name, gender, birthDate, weight, height);
			userController.Save();
		}
	}
}
