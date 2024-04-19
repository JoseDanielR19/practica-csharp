using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaCSharp
{
	/// <summary>
	/// Clase que proporciona métodos para guardar y listar usuarios en archivos.
	/// </summary>
	public class SaveUserFiles
	{
		private const String DirectoryPath = "Users";
		private const String FileNamePrefix = "User";

		/// <summary>
		/// Guarda los datos de un usuario en un archivo de texto.
		/// </summary>
		/// <param name="user">Objeto User que contiene los datos del usuario a guardar.</param>
		/// <param name="documentNumber">Número de documento del usuario.</param>
		/// <returns>Una tarea que representa la operación asincrónica.</returns>
		public async Task SaveUserToFile(User user, String documentNumber)
		{
			String directoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DirectoryPath);
			String filePath = Path.Combine(directoryPath, $"{FileNamePrefix}_{documentNumber}.txt");

			try
			{
				Directory.CreateDirectory(directoryPath);

				using (StreamWriter writer = File.CreateText(filePath))
				{
					await writer.WriteLineAsync("Género, Título, Nombre, Apellido, Correo electrónico, Nombre de usuario, Fecha de nacimiento, Dirección");
					await writer.WriteLineAsync($"{user.Gender}, {user.Title}, {user.FirstName}, {user.LastName}, {user.Email}, {user.Username}, {user.DateOfBirth}, {user.Address}");
				}

				Console.WriteLine($"Los datos del usuario se han guardado en el archivo: {filePath}");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error al intentar guardar los datos del usuario en el archivo: {ex.Message}");
			}
		}

		/// <summary>
		/// Lista todos los usuarios guardados en archivos.
		/// </summary>
		public void ListAllUser()
		{
			String directoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DirectoryPath);

			try
			{
				if (Directory.Exists(directoryPath))
				{
					String[] files = Directory.GetFiles(directoryPath, $"{FileNamePrefix}_*.txt");

					if (files.Any())
					{
						Int32 indice = 0;
						foreach (String file in files)
						{
							String[] lines = File.ReadAllLines(file);
							String name = lines[1].Split(',')[2].Trim(); // Obtener el nombre del usuario desde el archivo
							indice += 1;
							Console.WriteLine("| {0}. {1}", indice, name);
						}
					}
					else
					{
						Console.WriteLine("========================================");
						Console.WriteLine("| No se encontraron usuarios agregados |");
						Console.WriteLine("========================================");
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
