using System;
using System.Collections.Concurrent;

namespace CallCenter
{
	public class Operator : Employee
	{
		private bool IsFree;
		public Operator(string employeeName, int id): base(employeeName, id)
		{
			IsFree = true;
        }

		public override void Initiate<T>(BlockingCollection<T> Collection)
		{
			try
			{
                CancellationTokenSource source = new CancellationTokenSource();
                this.token = source;
                Thread thread = new Thread(() =>
                {
                    try
                    {
                        foreach (var item in Collection.GetConsumingEnumerable(source.Token))
                        {
                            IsFree = false;
                            Console.WriteLine($"Operator {this.GetId()} taking up {item.ToString()} - {Thread.CurrentThread.ManagedThreadId}");
                            Thread.Sleep(3000);
                            Console.WriteLine($"Operator {this.GetId()} has completed {item.ToString()} - {Thread.CurrentThread.ManagedThreadId}");
                            IsFree = true;
                        }
                    }
                    catch (OperationCanceledException ex)
                    {
                        Console.WriteLine($"Operator {this.GetId()} has Terminated - {Thread.CurrentThread.ManagedThreadId}");
                    }
                });

                thread.Start();
            }
            finally
            {

            }
        }

		public override bool EmployeeStatus() => IsFree;
	}
}

