using System;


namespace FitnessProject.BL.Model
{
	/// <summary>
	/// User.
	/// </summary>
	[Serializable]
	public class User

	{
		#region Attributes
		/// <summary>
		/// Name.
		/// </summary>
		public string Name { get; }
		
		/// <summary>
		/// Gender.
		/// </summary>
		public Gender Gender { get; set; }

		/// <summary>
		/// Date birth.
		/// </summary>
		public DateTime BirthDate { get; set; }

		/// <summary>
		/// Weight.
		/// </summary>
		public double Weight { get; set; }

		/// <summary>
		/// Height.
		/// </summary>
		public double Height { get; set; }
		#endregion

		public int Age { get { return DateTime.Now.Year - BirthDate.Year;}}
		/// <summary>
		/// Create new User.
		/// </summary>
		/// <param name="name"> Name.</param>
		/// <param name="gender"> Gender.</param>
		/// <param name="birthDate"> Date birth </param>
		/// <param name="weight"> Weight.</param>
		/// <param name="height"> Height.</param>
		public User (
			String name,
			Gender gender,
			DateTime birthDate, 
			double weight, 
			double height)
		{
			#region checking conditions
			if(string.IsNullOrWhiteSpace(name)) 
			{
				throw new ArgumentNullException("Name User can not be null or white space.");
			}

			if(gender == null)
			{
				throw new ArgumentNullException("Gender can not be null.", nameof(gender));
			}

			if (birthDate < DateTime.Parse("01.01.1900") || birthDate >= DateTime.Now)
			{
				throw new ArgumentException("impossible date birth.", nameof(birthDate));
			}

			if(weight <= 0) 
			{
				throw new ArgumentException("Weight can not be equally 0.", nameof(weight)); 
			}

			if(height <= 0)
			{
				throw new ArgumentException("Height can not be equally 0.", nameof(height));
			}
			#endregion

			Name = name;
			Gender = gender;
			BirthDate = birthDate;
			Weight = weight;
			Height = height;
		}

		public User(string name)
		{
			if(string.IsNullOrWhiteSpace(name))
			{
				throw new ArgumentNullException("User name can not be void", nameof(name));
			}

			Name = name;
		}

		public override string ToString()
		{
			return Name + " " + Age;
		}


	}
}
 