using System;
namespace PracticeApplication.MyLogging
{
	public class LogToFile : IMyLogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine("LogToFile");

        }
    }
}

