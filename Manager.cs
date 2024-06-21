using System;
using System.Collections.Concurrent;
namespace CallCenter
{
	public class Manager : IManager
	{
		private BlockingCollection<string> CollectionsQueue;
		private readonly IDictionary<int, Employee> EmployeeMap;
		public Manager()
		{
            CollectionsQueue = new BlockingCollection<string>();
			EmployeeMap = new SortedDictionary<int, Employee>();
        }

		public void AddEmployee()
		{
			int id = GetNewEmpId();
            Employee emp = new Operator($"Name - {id}", id);
			emp.Initiate<string>(CollectionsQueue);
			EmployeeMap.Add(id, emp);
        }

		public void AddTask(string taskName)
		{
			CollectionsQueue.Add(taskName);
		}

		public void KillEmployee()
		{
			foreach(KeyValuePair<int, Employee> item in EmployeeMap)
			{
				item.Value.KillEmployee();
            }
			EmployeeMap.Clear();
		}

		public void KillEmployee(int id)
		{
			if(!EmployeeMap.TryGetValue(id, out Employee emp))
			{
				throw new ArgumentException("Id not found");
			}

			emp.KillEmployee();
            EmployeeMap.Remove(id);
        }

		public int CountOfFreeEmployee()
		{
			return EmployeeMap.Where(e => e.Value.EmployeeStatus() == true).Count();
        }

		public int CountOfAllEmployee() => EmployeeMap.Count();

		private int GetNewEmpId()
		{
			if(EmployeeMap.Count == 0)
			{
				return 1;
			}

			return EmployeeMap.Last().Key + 1;
        }
    }
}

