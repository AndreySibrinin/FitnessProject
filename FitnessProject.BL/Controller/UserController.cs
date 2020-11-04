using FitnessProject.BL.Model;

using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace FitnessProject.BL.Controller
{
	/// <summary>
	/// User controller.
	/// </summary>
	public class UserController
	{
		/// <summary>
		/// Application User.
		/// </summary>
		public User User { get; }

		/// <summary>
		/// Create new user controller.
		/// </summary>
		/// <param name="user"></param>
		public UserController(string userName, string genderName, DateTime birthDate, double weight, double height)
		{
			// checking
			var gender = new Gender(genderName);
			User = new User(userName, gender, birthDate, weight, height);
		}

		public UserController()
		{
			var formatter = new BinaryFormatter();
			using(var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
			{
				if(formatter.Deserialize(fs) is User user)
				{
					User = user;
				}
			}
		}

		/// <summary>
		/// Save user date.
		/// </summary>
		public void Save()
		{
			var formatter = new BinaryFormatter();
			using(var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
			{
				formatter.Serialize(fs, User);
			}
		}
	}
}
