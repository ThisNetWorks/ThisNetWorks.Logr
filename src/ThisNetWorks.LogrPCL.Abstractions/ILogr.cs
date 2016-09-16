using System;
namespace ThisNetWorks.LogrPCL.Abstractions
{
	public interface ILogr
	{
		void Debug(string message);
		void Debug(string message, params object[] args);
		void Info(string message);
		void Info(string message, params object[] args);
		//TODO should probably allow exceptions to be passed here to
		void Warn(string message);
		void Warn(string message, params object[] args);
		void Error(string message);
		void Error(string message, params object[] args);
		void Error(Exception e, string message);
		void Error(Exception e, string message, params object[] args);
	}
}

