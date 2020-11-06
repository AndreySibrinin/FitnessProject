﻿using FitnessProject.BL.Model;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
		public List<User> Users { get; }
		public User CurrentUser { get; }
		public bool IsNewUser { get; } = false;

		/// <summary>
		/// Create new user controller.
		/// </summary>
		/// <param name="user"></param>
		public UserController(string userName)
		{
			// checking
			if(string.IsNullOrWhiteSpace(userName))
			{
				throw new ArgumentNullException("User name can not be void", nameof(userName)); 
			}

			Users = GetUsersData();

			CurrentUser = Users.SingleOrDefault(u => u.Name == userName);

			if(CurrentUser == null)
			{
				CurrentUser = new User(userName);
				Users.Add(CurrentUser);
				IsNewUser = true;
				Save();
			}

		}

		/// <summary>
		/// Get saving list users
		/// </summary>
		/// <returns></returns>
		private List<User> GetUsersData()
		{
			var formatter = new BinaryFormatter();
			using(var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
			{
				if(formatter.Deserialize(fs) is List<User> users)
				{
					return users;
				}
				else
				{
					return new List<User>();
				}
			}
		}
		
		public void SetNewUserData(string genderName , DateTime birthDate, double weight =1, double height = 1)
		{
			CurrentUser.Gender = new Gender(genderName);
			CurrentUser.BirthDate = birthDate;
			CurrentUser.Weight = weight;
			CurrentUser.Height = height;
			Save();
		}
		/// <summary>
		/// Save user date.
		/// </summary>
		public void Save()
		{
			var formatter = new BinaryFormatter();
			using(var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
			{
				formatter.Serialize(fs, Users);
			}
		}
	}
}
