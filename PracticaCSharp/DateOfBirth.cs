using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PracticaCSharp
{
	/// <summary>
	/// Clase que proporciona métodos para obtener y procesar fechas de nacimiento de usuarios.
	/// </summary>
	public class DateOfBirth
	{
		private const String DirectoryPath = "Users";
		private const String FileNamePrefix = "User";

		/// <summary>
		/// Obtiene y muestra las 10 fechas de nacimiento más tempranas de los usuarios almacenados.
		/// </summary>
		public void TopDateOfBirth()
		{
			String directoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DirectoryPath);

			try
			{
				if (Directory.Exists(directoryPath))
				{
					String[] files = Directory.GetFiles(directoryPath, $"{FileNamePrefix}_*.txt");

					if (files.Any())
					{
						List<DateTime> datesOfBirth = new List<DateTime>();

						foreach (String file in files)
						{
							String[] lines = File.ReadAllLines(file);

							String dateOfBirthString = lines[1].Split(',')[6].Trim();
							DateTime dateOfBirth;

							if (DateTime.TryParse(dateOfBirthString, out dateOfBirth))
							{
								datesOfBirth.Add(dateOfBirth);
							}
						}

						// Ordenar la lista de fechas de nacimiento
						datesOfBirth.Sort();

						// Imprimir las 10 primeras fechas de nacimiento
						for (Int32 index = 0; index < Math.Min(10, datesOfBirth.Count); index++)
						{
							Console.WriteLine("| {0}. {1}", index + 1, datesOfBirth[index].ToString("yyyy-MM-dd"));
						}
					}
					else
					{
						Console.WriteLine("============================");
						Console.WriteLine("| No se encontraron fechas |");
						Console.WriteLine("============================");
					}
				}
				else
				{
					Console.WriteLine("========================================");
					Console.WriteLine("| El directorio de usuarios no existe. |");
					Console.WriteLine("========================================");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error al intentar listar los usuarios: {ex.Message}");
			}
		}
	}
}
