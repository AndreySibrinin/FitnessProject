using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessProject.BL.Model
{	
	/// <summary>
	///	Gender.
	/// </summary>
	[Serializable]
	public class Gender
	{
		/// <summary>
		/// Name.
		/// </summary>
		public String Name { get; }

		/// <summary>
		/// Create new Gender.
		/// </summary>
		/// <param name="name"> Name Gender.</param>
		public Gender(string name)
		{
			if(string.IsNullOrWhiteSpace(name))
			{
				throw new ArgumentNullException("Gender name can not be white space or null", nameof(name));
			}

			Name = name;
		}

		public override string ToString()
		{
			return Name;
		}

	}
}
