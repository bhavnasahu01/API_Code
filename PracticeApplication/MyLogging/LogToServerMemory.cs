﻿using System;
namespace PracticeApplication.MyLogging
{
	public class LogToServerMemory: IMyLogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine("LogToServerMemory");

        }
    }
}

