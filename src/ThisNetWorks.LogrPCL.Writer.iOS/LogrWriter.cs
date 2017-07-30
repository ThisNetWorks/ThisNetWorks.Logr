using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using ThisNetWorks.LogrPCL.Abstractions;
using ThisNetWorks.LogrPCL.Writer.Shared;

namespace ThisNetWorks.LogrPCL.Writer
{
	public class LogrWriter : LogrWriterBase, ILogrWriter
	{
        //TODO check out how tags work in MobileCenter
        private string _tag = "Logr";

		protected override void LogDebug(string message)
		{
			WriteToConsole(message);
		}

		protected override void LogInfo(string message)
		{
			WriteToConsole(message);
		}
		protected override void LogWarn(string message)
		{
			WriteToConsole(message);
		}

		protected void WriteToConsole(string message)
		{
			Console.WriteLine(message);
		}

		protected override void LogError(string message, Exception e)
		{
			LogrException logrException = null;

			if (e == null)
				logrException = new LogrException(message);
			else
				logrException = new LogrException(message, e);
            
			WriteToConsole(message);
			if (e != null && e.StackTrace != null)
				WriteToConsole(e.StackTrace);
            
			ReportToInsights(logrException, message, InsightsSeverity.Error);
			ReportToMobileCenter(_tag, logrException, message);
		}

		protected override string FormatMessage(string message, params object[] args)
		{
			var messageFormatted = string.Format(message, args);

			//droid needds to add time, ios doesn't
			//string messageWithTime = GetWithTime(messageFormatted);

			return messageFormatted;
		}

		protected override string AddLogFileToMobileCenter(string message)
		{
            //TODO not implemented on iOS
            return message;

		}
		protected override void AddLogFileToInsights(System.Collections.Generic.IDictionary<string, string> dict)
		{
			//TODO not implemented on iOS
			return;
		}
	}
}


