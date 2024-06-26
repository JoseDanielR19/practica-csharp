﻿using System;
using System.Threading.Tasks;

namespace PracticaCSharp
{
	/// <summary>
	/// Clase principal que contiene el método de entrada Main y el menú de opciones.
	/// </summary>
	internal class Program
	{
		/// <summary>
		/// Método de entrada principal que ejecuta el programa.
		/// </summary>
		/// <param name="args">Argumentos de la línea de comandos.</param>
		static async Task Main(String[] args)
		{
			Int32 opcion;
			Boolean cicloWhile = true;

			while (cicloWhile)
			{
				Menu();

				Console.Write("Escoge una opción: ");
				opcion = Convert.ToInt32(Console.ReadLine());

				Console.Clear();

				switch (opcion)
				{
					case 1:
						GenerateApiUser generateApiUser = new GenerateApiUser();
						await generateApiUser.GetDataUser();
						break;
					case 2:
						Console.WriteLine("================================");
						Console.WriteLine("| Lista de usuarios por nombre |");
						Console.WriteLine("--------------------------------");

						SaveUserFiles saveUserFiles = new SaveUserFiles();
						saveUserFiles.ListAllUser();
						break;
					case 3:
						Console.WriteLine("===============================");
						Console.WriteLine("| Top 10 fechas de nacimiento |");
						Console.WriteLine("-------------------------------");

						DateOfBirth dateOfBirth = new DateOfBirth();
						dateOfBirth.TopDateOfBirth();
						break;
					case 4:
						cicloWhile = false;
						break;
					default:
						Console.WriteLine("Opción Invalida, por favor intente nuevamente");
						Console.Clear();
						break;
				}

				if (opcion >= 1 && opcion <= 3)
				{
					PressKey();
				}
			}
		}

		/// <summary>
		/// Muestra el menú de opciones en la consola.
		/// </summary>
		static void Menu()
		{
			Console.WriteLine("==============================================");
			Console.WriteLine("|                    Menu                    |");
			Console.WriteLine("|--------------------------------------------|");
			Console.WriteLine("| 1. Guardar usuario aleatorio               |");
			Console.WriteLine("| 2. Mostrar usuarios por nombre             |");
			Console.WriteLine("| 3. Mostrar top 10 fechas de nacimiento     |");
			Console.WriteLine("| 4. Salir                                   |");
			Console.WriteLine("==============================================");
		}

		/// <summary>
		/// Muestra un mensaje para presionar una tecla antes de continuar.
		/// </summary>
		static void PressKey()
		{
			Console.Write("\nPresiona cualquier Tecla para Continuar....");
			Console.ReadKey();
			Console.Clear();
		}
	}
}
