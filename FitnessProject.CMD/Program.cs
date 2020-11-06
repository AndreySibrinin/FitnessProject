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
			
			var userController = new UserController(name);
			

			if(userController.IsNewUser)
			{
				Console.WriteLine("Input user gender:");
				var gender = Console.ReadLine();

				DateTime birthDate;
				double weight = parseDouble("weight");
				double height = parseDouble("height");
				birthDate = ParseDateTime();
				userController.SetNewUserData(gender, birthDate, weight, height);
			}
			Console.WriteLine(userController.CurrentUser);
			Console.ReadLine();
		}

		private static DateTime ParseDateTime()
		{
			DateTime birthDate;
			while(true)
			{
				Console.WriteLine("Input user date of birth (dd.MM.yyyy): ");
				if(DateTime.TryParse(Console.ReadLine(), out birthDate))
				{
					break;
				}
				else
				{
					Console.WriteLine("Wrong format birth date");
				}
			}

			return birthDate;
		}

		private static double parseDouble(string name)
		{
			while(true)
			{
				Console.WriteLine($"Input {name}: ");
				if(double.TryParse(Console.ReadLine(), out double value))
				{
					return value;
				}
				else
				{
					Console.WriteLine($"Wrong format {name}");
				}
			}

		}
	}
}
