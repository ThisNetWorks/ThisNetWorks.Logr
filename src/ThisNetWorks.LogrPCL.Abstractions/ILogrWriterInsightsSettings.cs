using System;
using System.Reflection;

namespace ThisNetWorks.LogrPCL.Abstractions
{
	public interface ILogrWriterInsightsSettings
	{
		bool ShouldTryReportToInsights { get; set; }
		MethodInfo InsightsReportMethod { get; }
		bool ShouldSendLogFile { get; set; }
		int LogNumberOfLines { get; set; }
		bool OnlySendLogFileInDebug { get; set; }
	}
}

