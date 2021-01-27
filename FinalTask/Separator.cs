using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using static System.Environment;

namespace FinalTask
{
	class Separator
	{
		public string fileName { get; }
		public Separator(string incomingFilePath)
		{
			fileName = incomingFilePath + "\\Students.dat";
			if (!File.Exists(fileName))
			{
				fileName = Environment.GetFolderPath(SpecialFolder.Desktop) + "\\Students.dat";
				if (!File.Exists(fileName))
				{
					fileName = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + "\\Students.dat";
					if (!File.Exists(fileName))
						fileName = "";
				}
			}
		}
		/// <summary>
		/// чтение из бинарного файла структуры
		/// </summary>
		public void Separate()
		{
			if (fileName.Length != 0)
			{
				//ассоциируем объект с папкой "Рабочий стол"
				DirectoryInfo desktop = new DirectoryInfo(Environment.GetFolderPath(SpecialFolder.Desktop));
				//создаём папку Students на рабочем столе (если она существует, метод не выполняет никаких действий)
				DirectoryInfo students = desktop.CreateSubdirectory("Students");

				BinaryFormatter formatter = new BinaryFormatter();
				// десериализация
				using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
				{
					Student[] s = (Student[])formatter.Deserialize(fs);

					var groups = s.GroupBy(p => p.Group).Select(g => new { Name = g.Key }).OrderBy(u => u.Name);
					foreach (var g in groups)
					{
						string outgoingFile = String.Format("{0}\\{1}.txt", students.FullName, g.Name);
						if (!File.Exists(outgoingFile))
						{
							using (StreamWriter sw = File.CreateText(outgoingFile))
							{
								foreach (Student item in s.Where(u => u.Group == g.Name))
									sw.WriteLine("{0}, {1:dd.MM.yyyy}", item.Name, item.DateOfBirth);
							}
						}
					}
				}
			}
			else
			{
				Console.WriteLine("файл не найден");
			}
		}
	}
}
