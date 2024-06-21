using System;
using System.Collections.Concurrent;

namespace CallCenter
{
	public abstract class Employee
	{
		private string EmployeeName;
		private int Id;
        protected CancellationTokenSource? token;

        public Employee(string employeeName, int id)
		{
			this.EmployeeName = employeeName;
			this.Id = id;
		}

		public string GetName() => this.EmployeeName;

        public int GetId() => this.Id;

		public abstract void Initiate<T>(BlockingCollection<T> Collection);
        public abstract bool EmployeeStatus();

		public void KillEmployee()
		{
			this.token?.Cancel();
		}
	}
}

