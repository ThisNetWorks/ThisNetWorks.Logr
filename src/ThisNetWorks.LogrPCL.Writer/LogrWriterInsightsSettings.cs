using System;
using System.Reflection;
using ThisNetWorks.LogrPCL.Abstractions;

namespace ThisNetWorks.LogrPCL.Writer
{
	public class LogrWriterInsightsSettings : ILogrWriterInsightsSettings
	{
		public bool ShouldTryReportToInsights { get; set; }
		public MethodInfo InsightsReportMethod { get; }
		public bool ShouldSendLogFile { get; set; }
		public int LogNumberOfLines { get; set; }
		public bool OnlySendLogFileInDebug { get; set; }
	}
}

