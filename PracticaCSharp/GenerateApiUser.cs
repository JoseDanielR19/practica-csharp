using System;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace PracticaCSharp
{
	/// <summary>
	/// Clase que proporciona métodos para generar datos de usuario a partir de una API externa.
	/// </summary>
	public class GenerateApiUser
	{
		private readonly HttpClient _client;

		/// <summary>
		/// Constructor de la clase GenerateApiUser.
		/// </summary>
		public GenerateApiUser()
		{
			this._client = new HttpClient();
		}

		/// <summary>
		/// Obtiene datos de usuario de una API externa y guarda la información en archivos.
		/// </summary>
		public async Task GetDataUser()
		{
			HttpResponseMessage response = await this._client.GetAsync("https://randomuser.me/api/");

			if (response.IsSuccessStatusCode)
			{
				JsonSerializerOptions jsonOptions = new JsonSerializerOptions
				{
					PropertyNameCaseInsensitive = true
				};

				Stream contentStream = await response.Content.ReadAsStreamAsync();
				UserResponse userResponse = await JsonSerializer.DeserializeAsync<UserResponse>(contentStream, jsonOptions);

				if (userResponse != null && userResponse.Results.Count > 0)
				{
					UserResult randomUser = userResponse.Results[0];
					DateTime dateOfBirth = DateTime.ParseExact(randomUser.Dob.Date, "yyyy-MM-ddTHH:mm:ss.fffZ", CultureInfo.InvariantCulture);

					User user = new User
					{
						Gender = randomUser.Gender,
						Title = randomUser.Name.Title,
						FirstName = randomUser.Name?.First,
						LastName = randomUser.Name?.Last,
						Email = randomUser.Email,
						Username = randomUser.Login?.Username,
						DateOfBirth = dateOfBirth.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
						Address = randomUser.Location != null ?
							  $"{randomUser.Location.Street.Number} {randomUser.Location.Street.Name}, {randomUser.Location.City}, {randomUser.Location.State}, {randomUser.Location.Country}" : null
					};

					this.PrintDataUser(user);

					SaveUserFiles saveUserFiles = new SaveUserFiles();

					await saveUserFiles.SaveUserToFile(user, randomUser.DocumentNumber);
				}
				else
				{
					Console.WriteLine("Error al realizar la solicitud: " + response.ReasonPhrase);
				}
			}
		}

		/// <summary>
		/// Imprime los datos del usuario en la consola.
		/// </summary>
		/// <param name="user">Objeto User que contiene los datos del usuario.</param>
		private void PrintDataUser(User user)
		{
			Console.WriteLine("=====================================================================");
			Console.WriteLine("|                    Datos del usuario guardados                    |");
			Console.WriteLine("---------------------------------------------------------------------");
			Console.WriteLine($"| Género: {user.Gender}");
			Console.WriteLine($"| Título: {user.Title}");
			Console.WriteLine($"| Nombre: {user.FirstName} {user.LastName}");
			Console.WriteLine($"| Apellido: {user.LastName}");
			Console.WriteLine($"| Correo electrónico: {user.Email}");
			Console.WriteLine($"| Nombre de usuario: {user.Username}");
			Console.WriteLine($"| Fecha de nacimiento: {user.DateOfBirth}");
			Console.WriteLine($"| Dirección: {user.Address}");
			Console.WriteLine("=====================================================================");
		}
	}
}
