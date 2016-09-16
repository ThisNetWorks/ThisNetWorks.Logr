using System;
namespace ThisNetWorks.LogrPCL.Abstractions
{
	public interface ILogrWriterSettings
	{
		bool IsDebug { get; set; }
		ILogrWriterInsightsSettings Insights { get; set; }
	}
}

