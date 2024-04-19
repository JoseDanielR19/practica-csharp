using System;

namespace PracticaCSharp
{
	internal class UserResult
	{
		public String Gender { get; set; }
		public String Title { get; set; }
		public Name Name { get; set; }
		public String Email { get; set; }
		public Login Login { get; set; }
		public DateTime DateOfBirth { get; set; }
		public Location Location { get; set; }
		public Id Id { get; set; }
		public Dob Dob { get; set; }

		public String DocumentNumber
		{
			get
			{
				// Reemplazamos caracteres no válidos en el nombre de archivo con guiones bajos
				return this.Id?.Value?.Replace(".", "").Replace("-", "_").Replace(" ", "_");
			}
		}
	}
}
