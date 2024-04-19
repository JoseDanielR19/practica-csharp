using System;

namespace PracticaCSharp
{
	/// <summary>
	/// Clase que representa el resultado de un usuario.
	/// </summary>
	internal class UserResult
	{
		/// <summary>
		/// Género del usuario.
		/// </summary>
		public String Gender { get; set; }

		/// <summary>
		/// Título del usuario.
		/// </summary>
		public String Title { get; set; }

		/// <summary>
		/// Nombre del usuario.
		/// </summary>
		public Name Name { get; set; }

		/// <summary>
		/// Correo electrónico del usuario.
		/// </summary>
		public String Email { get; set; }

		/// <summary>
		/// Datos de inicio de sesión del usuario.
		/// </summary>
		public Login Login { get; set; }

		/// <summary>
		/// Fecha de nacimiento del usuario.
		/// </summary>
		public DateTime DateOfBirth { get; set; }

		/// <summary>
		/// Ubicación del usuario.
		/// </summary>
		public Location Location { get; set; }

		/// <summary>
		/// Identificación del usuario.
		/// </summary>
		public Id Id { get; set; }

		/// <summary>
		/// Fecha de nacimiento del usuario (DTO).
		/// </summary>
		public Dob Dob { get; set; }

		/// <summary>
		/// Número de documento del usuario, utilizado para generar nombres de archivo.
		/// </summary>
		public String DocumentNumber
		{
			get
			{
				// Reemplazar caracteres no válidos en el nombre de archivo con guiones bajos
				return this.Id?.Value?.Replace(".", "").Replace("-", "_").Replace(" ", "_");
			}
		}
	}
}
