using System;
namespace PracticeApplication.MyLogging
{
	public class LogToDB : IMyLogger
	{
		public void Log(string message)
		{
			Console.WriteLine(message);
            Console.WriteLine("LogToDB");

        }
	}
}

