using System;
namespace ThisNetWorks.LogrPCL.Abstractions
{
	public interface ILogrWriter 
	{
		void LogrWrite(LogrLevel logrLevel, string message, Exception e = null, params object[] args);
		ILogrWriterSettings Settings { get; set; }

	}
}

