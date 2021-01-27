using System;

namespace FinalTask
{
	[Serializable]
	class Student
	{
		public string Name { get; set; }
		public string Group { get; set; }
		public DateTime DateOfBirth { get; set; }

		public Student(string name, string group, DateTime birthday)
		{
			Name = name;
			Group = group;
			DateOfBirth = birthday;
		}
	}
}
