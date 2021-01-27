using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FinalTask
{
	/// <summary>
	/// Написать программу-загрузчик данных из бинарного формата в текст.
	/// На вход программа получает бинарный файл, предположительно, это база данных студентов.
	/// Свойства сущности Student:
	/// Имя — Name(string);
	/// Группа — Group(string);
	/// Дата рождения — DateOfBirth(DateTime).
	/// Ваша программа должна:
	/// Создать на рабочем столе директорию Students.
	/// Внутри раскидать всех студентов из файла по группам (каждая группа-отдельный текстовый файл), 
	/// в файле группы студенты перечислены построчно в формате "Имя, дата рождения".
	/// </summary>
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Необходимо указать путь до бинарного файла Students.dat.");
			Console.WriteLine("При отсутствии файла по указанному пути будет выполнена попытка");
			Console.WriteLine("обнаружить файл на рабочем столе и в папке расположения программы...");
			Console.Write(": ");
			string path = Console.ReadLine();

			Separator doIt = new Separator(path);

			Console.WriteLine(doIt.fileName);

			doIt.Separate();

		}
	}
}
