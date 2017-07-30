using System;
namespace ThisNetWorks.LogrPCL.Writer.Shared
{
	public class LogrException : Exception
	{
		public LogrException(string message) : base(message)
		{
		}

        public LogrException(string message, Exception innerException) : base(message, innerException)
        {
            
        }
	}
}

