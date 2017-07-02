using System;
using ThisNetWorks.LogrPCL.Abstractions;

namespace ThisNetWorks.LogrPCL.Writer
{
	public class LogrWriterSettings : ILogrWriterSettings
	{
		public bool IsDebug { get; set; }
		public ILogrWriterInsightsSettings Insights { get; set; }
        public ILogrWriterMobileCentreSettings MobileCentre { get; set; }
	}
}

