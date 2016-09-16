using System;
using ThisNetWorks.LogrPCL.Writer.Shared;

namespace ThisNetWorks.LogrPCL.Writer
{
	public class LogrWriterInsightsSettings : LogrWriterInsightsSettingsBase
	{
		public override bool ShouldSendLogFile { get; set; } = false;
	}
}

