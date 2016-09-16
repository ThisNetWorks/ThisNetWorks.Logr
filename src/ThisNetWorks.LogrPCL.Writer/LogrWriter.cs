using System;
using ThisNetWorks.LogrPCL.Abstractions;

namespace ThisNetWorks.LogrPCL.Writer
{
	public class LogrWriter : ILogrWriter
	{

		public ILogrWriterSettings Settings { get; set; }
		public void LogrWrite(LogrLevel logrLevel, string message, Exception e = null, params object[] args)
		{

		}

	}
}

