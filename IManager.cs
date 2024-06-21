using System;
namespace CallCenter
{
	interface IManager
	{
		public void AddEmployee();
		public void AddTask(string taskName);
		public void KillEmployee();
		public void KillEmployee(int id);
		public int CountOfAllEmployee();
		public int CountOfFreeEmployee();
    }
}

