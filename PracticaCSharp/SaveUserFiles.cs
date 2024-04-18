using System;
using System.IO;
using System.Threading.Tasks;

namespace PracticaCSharp
{
    public class SaveUserFiles
    {
        private const String DirectoryPath = "Users";
        private const String FileNamePrefix = "User";

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
    }
}